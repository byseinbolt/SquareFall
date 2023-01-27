using System;
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

        [Header("Animation")]
        [SerializeField]
        private float _scaleChangeDuration;
        
        [SerializeField]
        private float _scaleFactor;

        [Header("Sound")]
        [SerializeField]
        private AudioSource _changeScoreSound;

        [SerializeField]
        private AudioSource _coinCollectedSound;
        
        private int _currentScore;
        private int _currentCoinsCount;
        private int _allCoins;

        private void Awake()
        {
            _scoreLabel.text = "0";
            _allCoins = PlayerPrefs.GetInt(GlobalConstants.ALL_COINS);

        }

        [UsedImplicitly]
        public void AddScore()
        {
            _currentScore += _scorePerSquare;
            _scoreLabel.text = _currentScore.ToString();
            _changeScoreSound.Play();
            ShowAddScoreAnimation();
        }

        [UsedImplicitly]
        public void AddCoins()
        {
            _currentCoinsCount += 1;
            _coinCollectedSound.Play();
        }
        
        private void ShowAddScoreAnimation()
        {
            _scoreLabel.transform.DOPunchScale(Vector3.one * _scaleFactor, _scaleChangeDuration, 0)
                .OnComplete(() => _scoreLabel.transform.DOScale(Vector3.one, 0));
        }

        private void OnDestroy()
        {
            _allCoins += _currentCoinsCount;
            PlayerPrefs.SetInt(GlobalConstants.ALL_COINS, _allCoins);
            PlayerPrefs.SetInt(GlobalConstants.CURRENT_SCORE, _currentScore);
            PlayerPrefs.SetInt(GlobalConstants.CURRENT_COINS, _currentCoinsCount);
            PlayerPrefs.Save();
        }
    }
}
