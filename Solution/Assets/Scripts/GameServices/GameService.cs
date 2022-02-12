using UnityEngine;
using Commons;
using EnemyServices;
using SFXServices;
using UIServices;
using TankServices;
using UnityEngine.SceneManagement;
namespace GameServices
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public bool gamePaused = false;
        public bool gameOver = false;
        private string currentPlayerName;
        private int highScore;
        private string recordHolderName;
        private float currentWave;


        private void Start()
        {
            currentWave = 0;
            highScore = PlayerPrefs.GetInt("highScore", 0);
            currentPlayerName = PlayerPrefs.GetString("currentPlayerName", "");
            recordHolderName = PlayerPrefs.GetString("recordHolderName", "-");
            SpawnWave();
        }

        async public void SpawnWave()
        {
            currentWave++;
            UIService.instance.ShowPopUpText("Wave " + currentWave.ToString() + " incomeing....", 3f);
            float enemyiesTobeSpawned = Mathf.Pow(2, (currentWave - 1));
            await new WaitForSeconds(2f);
            EnemyService.instance.SpawnWave(enemyiesTobeSpawned);
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GamePaused()
        {

            SFXService.instance.TurnOffSoundsExceptUI();
            EnemyService.instance.TurnOFFEnemies();
            TankService.instance.TurnOFFTanks();

            gamePaused = true;
        }
        public void SetCurrentPlayerName(string name)
        {
            currentPlayerName = name;
            PlayerPrefs.SetString("currentPlayerName", currentPlayerName);
        }
        public void CheckForHighScore()
        {
            if (UIService.instance.GetCurrentScore() > highScore)
            {
                PlayerPrefs.SetInt("highScore", UIService.instance.GetCurrentScore());
                PlayerPrefs.SetString("recordHolderName", PlayerPrefs.GetString("currentPlayerName"));
                recordHolderName = PlayerPrefs.GetString("recordHolderName");
                highScore = PlayerPrefs.GetInt("highScore");

            }
            RestartGame();
        }
        public void GameResumed()
        {
            SFXService.instance.ResetSounds();
            EnemyService.instance.TurnONEnmeis();
            TankService.instance.TurnONTanks();

            gamePaused = false;
        }
        public string GetHighScore()
        {

            return PlayerPrefs.GetInt("highScore").ToString();
        }
        public string GetRecordHolder()
        {
            return PlayerPrefs.GetString("recordHolderName");
        }

    }
}
