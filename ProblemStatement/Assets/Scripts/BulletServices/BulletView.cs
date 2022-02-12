using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Commans;

namespace BulletServices
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController { get; private set; }

        public GameObject BullectDestroyVFX;
        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        private void FixedUpdate()
        {
            bulletController.Movement();
        }
        private async void Start()
        {
            //write synchronous stuff for start() above this line --^
            await Task.Delay(TimeSpan.FromSeconds(2f));
            if (this != null)
                BulletService.instance.DestroyBullet(bulletController);
        }

        private void OnCollisionEnter(Collision other)
        {
            IDamagable iDamagable = other.gameObject.GetComponent<IDamagable>();
            if (iDamagable != null)
            {
                iDamagable.TakeDamage(bulletController.bulletModel.damage);
            }
            BulletService.instance.DestroyBullet(bulletController);
        }

        public void DestroyView()
        {
            bulletController = null;
            BullectDestroyVFX = null;
            Destroy(this.gameObject);
        }
    }
}