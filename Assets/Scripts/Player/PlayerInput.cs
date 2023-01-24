using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _directionChanged;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
               _directionChanged.Invoke();
            }
            
            if (Input.touches.Length > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    _directionChanged.Invoke();
                }
            }
        }
    }
}
