using System.Collections;
using JetBrains.Annotations;
using Square;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private SquareSpawner _squareSpawner;

        [SerializeField]
        private float _delayBeforeChangeScene;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        [UsedImplicitly]
        public void OnPlayerDied()
        {
            _squareSpawner.enabled = false;
            StartCoroutine(ShowGameOver());
        }

        private IEnumerator ShowGameOver()
        {
            yield return new WaitForSeconds(_delayBeforeChangeScene);
            SceneManager.LoadSceneAsync(GlobalConstants.GAME_OVER_SCENE);
        }
    }
}