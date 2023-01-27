using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _currentScore;

        [SerializeField]
        private TextMeshProUGUI _bestScore;
        
        [Header("Animation and Sound")]
        [SerializeField]
        private float _newBestScoreAnimationDuration;

        [SerializeField]
        private AudioSource _bestScoreSound;

        private void Awake()
        {
            var currentScore = PlayerPrefs.GetInt(GlobalConstants.SCORE);
            var bestScore = PlayerPrefs.GetInt(GlobalConstants.BEST_SCORE);

            if (currentScore>bestScore)
            {
                bestScore = currentScore;
                SetNewBestScore(bestScore);
                ShowNewBestScoreAnimation();
            }

            _currentScore.text = currentScore.ToString();
            _bestScore.text = $"BEST {bestScore.ToString()}";
        }

        // from restart button
        [UsedImplicitly]
        public void RestartGame()
        {
            SceneManager.LoadSceneAsync(GlobalConstants.GAME_SCENE);
        }

        // from exit button
        [UsedImplicitly]
        public void ExitToMainMenu()
        {
            SceneManager.LoadSceneAsync(GlobalConstants.GAME_START_SCENE);
        }

        private void SetNewBestScore(int bestScore)
        {
            PlayerPrefs.SetInt(GlobalConstants.BEST_SCORE, bestScore);
            PlayerPrefs.Save();
        }

        private void ShowNewBestScoreAnimation()
        {
            _bestScore.transform.DOPunchScale(Vector3.one, _newBestScoreAnimationDuration, 0);
            _bestScoreSound.Play();
        }
    }
}
