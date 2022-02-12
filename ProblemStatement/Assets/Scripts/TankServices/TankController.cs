using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BulletServices;
using BulletSO;
using VFXServices;


namespace TankServices
{
    public class TankController
    {
        public TankModel tankModel { get; private set; }
        public TankView tankView { get; private set; }
        private Rigidbody rigidbody;

        public TankController(TankModel _tankModel, TankView _tankView) //constructor
        {
            tankModel = _tankModel;
            tankView = GameObject.Instantiate<TankView>(_tankView);
            CameraController.instance.SetTarget(tankView.transform);
            rigidbody = tankView.GetComponent<Rigidbody>();

            tankView.SetTankController(this);
            tankModel.SetTankController(this);
            tankView.ChangeColor(tankModel.material);
        }

        public void Move(float movement, float movementSpeed)
        {
            Vector3 move = tankView.transform.transform.position += tankView.transform.forward * movement * movementSpeed * Time.fixedDeltaTime;
            rigidbody.MovePosition(move);
        }

        public void Rotate(float rotation, float rotateSpeed)
        {
            Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
            Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        }

        public void ShootBullet()
        {
            BulletService.instance.CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }
        public Vector3 GetFiringPosition()
        {
            return tankView.BulletShootPoint.position;
        }
        public Quaternion GetFiringAngle()
        {
            return tankView.transform.rotation;
        }
        public BulletScriptableObject GetBullet()
        {
            return tankModel.bulletType;
        }

        public void DestroyController()
        {
            VFXService.instance.InstantiateEffects(tankView.TankDestroyVFX, tankView.transform.position);
            tankModel.DestroyModel();
            tankView.DestroyView();
            tankModel = null;
            tankView = null;
            rigidbody = null;
        }

        private void Dead()
        {
            //bullets referece is passed for later use like adding damage to Tank kind of something
            TankService.instance.DestroyTank(this);
        }
        public void ApplyDamage(float damage)
        {
            if (tankModel.health - damage <= 0)
                Dead();
            else
                tankModel.health -= damage;
        }
    }
}