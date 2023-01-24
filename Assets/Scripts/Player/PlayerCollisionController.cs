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
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.CompareTag(GlobalConstants.ALLY_TAG))
            {
                _squareCollected.Invoke();
                Destroy(other.gameObject);
            }

            if (other.CompareTag(GlobalConstants.ENEMY_TAG))
            {
                _playerDied.Invoke();
                Destroy(other.gameObject);
            }
        }
    }
}
