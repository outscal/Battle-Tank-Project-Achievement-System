using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameServices;
namespace UIServices
{
    public class LobbyUI : MonoBehaviour
    {
        public Button StartButtonLobbyScene;
        public Button QuitButtonLobbyScene;
        public Button HighScoreButtonLobbyScene;

        public GameObject HighScorePanel;
        public GameObject Buttons;
        public TextMeshProUGUI highScoreText;
        public TextMeshProUGUI recordHolderText;
        public GameObject IntroPanel;
        public TextMeshProUGUI inputName;

        public void EnableButtonsOfLobbyScene()
        {
            if (StartButtonLobbyScene == null || QuitButtonLobbyScene == null || HighScoreButtonLobbyScene == null) return;

            StartButtonLobbyScene.enabled = true;
            QuitButtonLobbyScene.enabled = true;
            HighScoreButtonLobbyScene.enabled = true;
        }
        public void HighScore()
        {
            Buttons.SetActive(false);
            HighScorePanel.SetActive(true);
            highScoreText.text += " " + GameService.instance.GetHighScore();
            recordHolderText.text += " " + GameService.instance.GetRecordHolder();

        }
        public void Back()
        {
            Buttons.SetActive(true);
            HighScorePanel.SetActive(false);
        }
        public void EnterName()
        {
            IntroPanel.SetActive(false);
            Buttons.SetActive(true);
            GameService.instance.SetCurrentPlayerName(inputName.text);
        }
    }
}