using DG.Tweening;
using Game;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerCollisionController : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _squareCollected;
        
        [SerializeField]
        private UnityEvent _playerDied;

        [SerializeField]
        private float _scaleChangeDuration;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.CompareTag(GlobalConstants.ALLY_TAG))
            {
                DestroyAllySquare(other);
            }

            if (other.CompareTag(GlobalConstants.ENEMY_TAG))
            {
                _playerDied.Invoke();
                Destroy(other.gameObject);
            }
        }

        private void DestroyAllySquare(Collider2D other)
        {
            other.enabled = false;
            other.transform.DOScale(Vector3.zero, _scaleChangeDuration)
                .OnComplete(() =>
                {
                    _squareCollected.Invoke();
                    Destroy(other.gameObject);
                });
        }
    }
}
