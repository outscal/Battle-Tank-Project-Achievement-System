
using UnityEngine;
using EnemyServices;
using BulletSO;


namespace EnemySO
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy/NewEnemykScriptableObject")]
    public class EnemyScriptableObject : ScriptableObject
    {
        [Header("Enemy Type Specific")]
        public EnemyType enemyType;

        [Header("MVC Essentials")]
        public EnemyView enemyView;

        [Header("Health Vars")]
        public float health;

        [Header("Movement Vars")]
        public float movementSpeed;
        public float rotationSpeed;
        public float patrollingRadius;
        public float patrolTime;

        [Header("Attack Vars")]
        public float fireRate;
        public float attackDistace;
        public BulletScriptableObject bulletType;
    }


}
