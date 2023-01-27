using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class ShopScreen : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _coinsLabel;

        private void Awake()
        {
            _coinsLabel.text = PlayerPrefs.GetInt(GlobalConstants.ALL_COINS).ToString();
        }

        // from exit button
        [UsedImplicitly]
        public void ExitToMainMenu()
        {
            SceneManager.LoadSceneAsync(GlobalConstants.GAME_START_SCENE);
        }
    }
}