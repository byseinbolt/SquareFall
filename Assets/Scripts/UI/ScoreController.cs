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
        
        private int _currentScore;

        private void Awake()
        {
            _scoreLabel.text = "0";
        }

        [UsedImplicitly]
        public void AddScore()
        {
            _currentScore += _scorePerSquare;
            _scoreLabel.text = _currentScore.ToString();
            _changeScoreSound.Play();
            ShowAddScoreAnimation();
        }
        
        private void ShowAddScoreAnimation()
        {
            _scoreLabel.transform.DOPunchScale(Vector3.one * _scaleFactor, _scaleChangeDuration, 0)
                .OnComplete(() => _scoreLabel.transform.DOScale(Vector3.one, 0));
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetInt(GlobalConstants.SCORE, _currentScore);
            PlayerPrefs.Save();
        }
    }
}
