using UnityEngine;

namespace Square
{
    public class SquareDestructionTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            Destroy(col.gameObject);
        }
    }
}
