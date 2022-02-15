using UnityEngine;
using UnityEngine.AI;
using TankServices;
using Commons;
namespace EnemyServices
{
    public class EnemyView : MonoBehaviour, IDamagable
    {
        [Header("VFX")]
        public GameObject TankDestroyVFX;

        [Header("Shooting")]
        public Transform shootingPoint;

        [Header("States")]
        public EnemyPatrollingState patrollingState;
        public EnemyChasingState chasingState;
        public EnemyAttackingState attackingState;
        public EnemyState initialState;
        public EnemyState activeState;
        public EnemyStates currentState;

        public EnemyController controller { get; private set; }
        public NavMeshAgent navMeshAgent { get; private set; }
        private TankView tankView;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
            InitializeState();
        }

        public void SetEnemyController(EnemyController _controller)
        {
            controller = _controller;
        }
        public void SetTankView(TankView tank)
        {
            tankView = tank;
        }
        public Transform GetTankTransform()
        {
            return tankView.transform;
        }

        private void InitializeState()
        {
            switch (initialState)
            {
                case EnemyState.Attacking:
                    currentState = attackingState;
                    break;
                case EnemyState.Chasing:
                    currentState = chasingState;
                    break;
                case EnemyState.Patrolling:
                    currentState = patrollingState;
                    break;
                default:
                    currentState = null;
                    break;
            }
            currentState.OnStateEnter();
        }

        public void DestroyView()
        {
            shootingPoint = null;
            controller = null;
            navMeshAgent = null;
            TankDestroyVFX = null;
            currentState = null;
            patrollingState = null;
            chasingState = null;
            attackingState = null;
            Destroy(this.gameObject);
        }

        public void TakeDamage(float damage)
        {
            controller.ApplyDamage(damage);
        }

    }
}