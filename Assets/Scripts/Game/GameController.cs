using JetBrains.Annotations;
using Square;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class MagicBoosts : MonoBehaviour
    {
        
    }
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameStartScreen;
        
        [SerializeField]
        private GameObject _gameScreen;
        
        [SerializeField]
        private GameObject _gameOverScreen;

        [SerializeField]
        private SquareSpawner _squareSpawner;

        [SerializeField]
        private float _delayBeforeShowGameOverScreen;

        private bool _isGameOver;

        private void Awake()
        {
            _gameStartScreen.SetActive(true);
            _gameScreen.SetActive(false);
            _gameOverScreen.SetActive(false);
        }

        [UsedImplicitly]
        public void StartGame()
        {
            _gameStartScreen.SetActive(false);
            _gameScreen.SetActive(true);
        }
        
        [UsedImplicitly]
        public void RestartGame()
        {
            var sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(sceneName);
        }

        [UsedImplicitly]
        public void OnPlayerDied()
        {
            _isGameOver = true;
            _squareSpawner.enabled = false;
        }

        private void Update()
        {
            if (_isGameOver)
            {
                _delayBeforeShowGameOverScreen -= Time.deltaTime;
                if (_delayBeforeShowGameOverScreen <=0 )
                {
                    ShowGameOverScreen();
                }
            }
        }

        private void ShowGameOverScreen()
        {
            _gameScreen.SetActive(false);
            _gameOverScreen.SetActive(true);
        }
    }
}