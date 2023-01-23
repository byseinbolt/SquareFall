using System;
using Game;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreController : MonoBehaviour
    {
       
        
        [SerializeField]
        private TextMeshProUGUI _scoreLabel;

        [SerializeField]
        private int _scorePerSquare;

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
