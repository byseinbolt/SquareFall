using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField]
        private ScoreController _scoreController;
        
        [SerializeField]
        private TextMeshProUGUI _currentScore;

        [SerializeField]
        private TextMeshProUGUI _bestScore;

        private void OnEnable()
        {
            _currentScore.text = _scoreController.GetCurrentScore().ToString();
            _bestScore.text = $"BEST {_scoreController.GetBestScore().ToString()}";
        }
    }
}
