using Game;
using UnityEngine;

namespace Player
{
    public class PlayerBorderCollisionController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _reboundSound;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                _reboundSound.Play();
            }
        }
    }
}