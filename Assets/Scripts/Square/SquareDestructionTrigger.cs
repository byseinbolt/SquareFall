using DG.Tweening;
using UnityEngine;

namespace Square
{
    public class SquareDestructionTrigger : MonoBehaviour
    {
        [SerializeField]
        private float _scaleChangeDuration;

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            otherCollider.enabled = false;
            otherCollider.transform.DOScale(Vector3.zero, _scaleChangeDuration)
                .OnComplete(() => Destroy(otherCollider.gameObject));
        }
    }
}
