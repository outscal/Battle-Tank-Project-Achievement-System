using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Commons;
using EnemySO;
using TankServices;
using GameServices;
using UIServices;
using AchievementServices;

namespace EnemyServices
{
    public class EnemyService : GenericMonoSingleton<EnemyService>
    {
        public EnemySOList enemyTypes;
        [HideInInspector] public EnemyScriptableObject enemy;
        public List<EnemyController> enemies = new List<EnemyController>();
        private EnemyController enemyController;


        public void SpawnWave(float enemyCount)
        {

            for (int i = 0; i < enemyCount; i++)
            {
                CreateEnemy();
            }
            SubEvent();
        }
        private void SubEvent()
        {
            EventService.instance.OnEnemyDeath += UpdateEnemiesKilledCount;
        }
        private void UpdateEnemiesKilledCount()
        {
            TankService.instance.GetCurrentTankModel().EnemiesKilled += 1;
            PlayerPrefs.SetInt("EnemiesKilled", TankService.instance.GetCurrentTankModel().EnemiesKilled);
            Debug.Log(TankService.instance.GetCurrentTankModel().EnemiesKilled);
            UIService.instance.UpdateScoreText();
            AchievementService.instance.GetAchievementController().CheckForEnemiesKilledAchievement();
        }

        private void CreateEnemy()
        {

            enemy = enemyTypes.enemies[0];

            EnemyModel enemyModel = new EnemyModel(enemy);
            enemyController = new EnemyController(enemy.enemyView, enemyModel);

            enemies.Add(enemyController);
        }
        public EnemyController GetEnemyController()
        {
            return enemyController;
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
            if (enemies.Count == 0)
            {
                UnsubscribeEvents();
                GameService.instance.SpawnWave();
            }

        }
        private void UnsubscribeEvents()
        {
            Debug.Log("Unscub");
            EventService.instance.OnEnemyDeath -= UpdateEnemiesKilledCount;
        }


        public void TurnOFFEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].view.gameObject.SetActive(false);
                }
            }
        }
        public void TurnONEnmeis()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].view.gameObject.SetActive(true);
                }
            }
        }
    }
}