using GameServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIServices
{
    public class UIButtons : MonoBehaviour
    {
        public AudioClip click;
        public AudioSource audioSource;
        private LobbyUI lobbyUI;
        private void Start()
        {
            lobbyUI = GetComponent<LobbyUI>();
        }


        public void LoadLevel(int index)
        {
            audioSource.clip = click;
            audioSource.Play();
            SceneManager.LoadScene(index);

        }
        public void Quit()
        {
            audioSource.clip = click;
            audioSource.Play();
            Application.Quit();

        }
        public void Resume()
        {
            audioSource.clip = click;
            audioSource.Play();
            GameService.instance.GameResumed();
            UIService.instance.PausePanel.SetActive(false);
        }
        public void Restart()
        {
            audioSource.clip = click;
            audioSource.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }
}
