using System.Collections;
using System.Collections.Generic;
using TankServices;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyServices
{
    public class EnemyChasingState : EnemyStates
    {
        private bool canChase;
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            Debug.Log("Entering Chase");
            enemyView.activeState = EnemyState.Chasing;
            Chase();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Debug.Log("Exiting Chase");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                enemyView.SetTankView(other.gameObject.GetComponent<TankView>());
                ChangeState(this);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (enemyView.activeState == EnemyState.Attacking || !canChase) return;

            if (other.gameObject.GetComponent<TankView>() != null)
                Chase();

        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {

                ChangeState(enemyView.patrollingState);
            }
        }
        async private void Chase()
        {
            canChase = false;

            enemyView.navMeshAgent.isStopped = true;
            enemyView.navMeshAgent.ResetPath();
            enemyView.navMeshAgent.SetDestination(enemyView.GetTankTransform().position);
            await new WaitForSeconds(2f);

            canChase = true;
        }
    }
}