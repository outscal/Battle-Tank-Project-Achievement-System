using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Commons;
using EnemySO;
using System;
using System.Threading.Tasks;

namespace EnemyServices
{
    public class EnemyService : GenericMonoSingleton<EnemyService>
    {
        public EnemykScriptableObjectList enemyTypes;
        [HideInInspector] public EnemyScriptableObject enemy;
        private List<EnemyController> enemies = new List<EnemyController>();
        private Coroutine respawn;

        private async void Start()
        {
            await new WaitForEndOfFrame();
            CreateEnemy();
        }

        private void CreateEnemy()
        {
            enemy = enemyTypes.enemies[0];
            EnemyModel enemyModel = new EnemyModel(enemy);
            EnemyController controller = new EnemyController(enemy.enemyView, enemyModel);
            enemies.Add(controller);
        }

        public void DestroyEnemy(EnemyController enemy)
        {
            enemy.DestoryController();

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemy == enemies[i])
                {
                    enemies[i] = null;
                    enemies.Remove(enemies[i]);
                }
            }
            respawn = StartCoroutine(RespawnEnemy());

        }

        private IEnumerator RespawnEnemy()
        {
            yield return new WaitForSeconds(4f);
            CreateEnemy();
            if (respawn != null)
            {
                StopCoroutine(respawn);
                respawn = null;
            }
        }
    }
}