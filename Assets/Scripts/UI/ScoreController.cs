using Game;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using DG.Tweening;

namespace UI
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreLabel;

        [SerializeField]
        private int _scorePerSquare;

        [SerializeField]
        private float _scaleChangeDuration;
        
        [SerializeField]
        private float _scaleFactor;

        [SerializeField]
        private AudioSource _bestScoreSound;
        
        

        private int _currentScore;
        private int _bestScore;

        private void Awake()
        {
            _bestScore = PlayerPrefs.GetInt(GlobalConstants.BEST_SCORE);
        }

        [UsedImplicitly]
        public void AddScore()
        {
            _currentScore += _scorePerSquare;
            _scoreLabel.text = _currentScore.ToString();
            _scoreLabel.transform.DOPunchScale(Vector3.one * _scaleFactor, _scaleChangeDuration, 0)
                .OnComplete(() => _scoreLabel.transform.DOScale(Vector3.one, 0));
        }

        public int GetBestScore()
        {
            if (_currentScore>_bestScore)
            {
                _bestScore = _currentScore;
                PlayerPrefs.SetInt(GlobalConstants.BEST_SCORE, _bestScore);
                PlayerPrefs.Save();
                _bestScoreSound.Play();
            }

            return _bestScore;
        }

        public int GetCurrentScore()
        {
            return _currentScore;
        }
    }
}
