using UnityEngine;
using System.Threading.Tasks;
using System;
using Commons;
using SFXServices;

namespace BulletServices
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController { get; private set; }

        public GameObject BullectDestroyVFX;
        public AudioClip BulletDestorySFX;
        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        private void FixedUpdate()
        {
            bulletController.Movement();
        }

        private void OnCollisionEnter(Collision other)
        {
            SFXService.instance.PlaySoundAtTrack1(BulletDestorySFX, 2, 20, true);
            if (bulletController != null)
            {
                IDamagable iDamagable = other.gameObject.GetComponent<IDamagable>();
                if (iDamagable != null)
                {
                    iDamagable.TakeDamage(bulletController.bulletModel.damage);
                }
                BulletService.instance.DestroyBullet(bulletController);
            }
        }

        public void DestroyView()
        {
            if (this == null) return;
            bulletController = null;
            BullectDestroyVFX = null;
            Destroy(this.gameObject);
        }
    }
}