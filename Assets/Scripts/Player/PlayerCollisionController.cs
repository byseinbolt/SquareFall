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
        private UnityEvent _coinCollected;

        [SerializeField]
        private float _scaleChangeDuration;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(GlobalConstants.ALLY_TAG))
            {
                _squareCollected.Invoke();
                DestroyAnimation(other);
            }

            if (other.CompareTag(GlobalConstants.ENEMY_TAG))
            {
                _playerDied.Invoke();
                Destroy(other.gameObject);
            }

            if (other.CompareTag(GlobalConstants.COIN_TAG))
            {
                _coinCollected.Invoke();
                DestroyAnimation(other);
            }
        }

        private void DestroyAnimation(Collider2D other)
        {
            other.enabled = false;
            other.transform.DOScale(Vector3.zero, _scaleChangeDuration)
                .OnComplete(() => { Destroy(other.gameObject); });
        }
    }
}
