using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using TankServices;
using Commans;
namespace EnemyServices
{
    public class EnemyView : MonoBehaviour, IDamagable
    {
        public GameObject TankDestroyVFX;
        public Transform shootingPoint;
        private EnemyController controller;
        public NavMeshAgent navMeshAgent { get; private set; }

        public bool playerDetected; //{ get; private set; }


        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        public void SetEnemyController(EnemyController _controller)
        {
            controller = _controller;
        }

        private void Update()
        {
            Debug.Log(controller.currentState);
            controller.Movement();
            if (playerDetected)
                controller.Attack();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<TankView>() != null)
                playerDetected = true;
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<TankView>() != null)
            {
                playerDetected = false;
            }
        }
        public Transform GetTank()
        {
            return TankService.instance.tankScriptable.tankView.transform;
        }
        public void DestroyView()
        {

            shootingPoint = null;
            controller = null;
            navMeshAgent = null;
            TankDestroyVFX = null;
            Destroy(this.gameObject);
        }

        public void TakeDamage(float damage)
        {
            controller.ApplyDamage(damage);
        }
    }
}