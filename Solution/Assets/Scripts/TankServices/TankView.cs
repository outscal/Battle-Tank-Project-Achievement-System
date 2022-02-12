using UnityEngine;
using SFXServices;
using UIServices;
using GameServices;

using Commons;

namespace TankServices
{
    public class TankView : MonoBehaviour, IDamagable
    {

        [Header("VFX and SFX References")]
        public GameObject TankDestroyVFX;
        public AudioClip TankDestroySFX;
        public AudioClip BulletShootSFX;
        public AudioClip TankIdleSFX;
        public AudioClip TankMovingSFX;


        private float rotation;
        private float movement;
        private float canFire = 0f;
        [Header("Movement and Shooting")]
        public Transform BulletShootPoint;
        public MeshRenderer[] childs;

        private TankController tankController;

        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        private void Update()
        {
            Movement();
            ShootBullet();
        }
        private void FixedUpdate()
        {
            if (movement != 0)
            {
                tankController.Move(movement, tankController.tankModel.movementSpeed);
                SFXService.instance.MovingSoundTrack(TankMovingSFX, 0.1f, 256, false);
            }
            else
            {
                SFXService.instance.MovingSoundTrack(TankIdleSFX, 0.1f, 256, false);
            }

            if (rotation != 0)
                tankController.Rotate(rotation, tankController.tankModel.rotationSpeed);
        }

        private void Movement()
        {
            rotation = Input.GetAxis("Horizontal");
            movement = Input.GetAxis("Vertical");
        }

        private void ShootBullet()
        {
            if (Input.GetButton("Fire1") && canFire < Time.time)
            {
                canFire = tankController.tankModel.fireRate + Time.time;
                tankController.ShootBullet();
            }
        }
        public void ChangeColor(Material material)
        {
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i].material = material;
            }
        }

        public void DestroyView()
        {
            for (int i = 0; i < childs.Length; i++)
                childs[i] = null;
            tankController = null;
            BulletShootPoint = null;
            TankDestroyVFX = null;
            Destroy(this.gameObject);
        }


        public void TakeDamage(float damage)
        {
            tankController.ApplyDamage(damage);
        }
    }
}