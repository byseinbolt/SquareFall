using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Square
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SquareController : MonoBehaviour
    {
        [SerializeField]
        private float _rotationPower;
        
        [SerializeField]
        private float _speed;
        
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rotationPower *= GetRandomMultiplier();
        }

        private void FixedUpdate()
        {
            _rigidbody.rotation += _rotationPower;
            _rigidbody.velocity = _direction * _speed;
        }

        private float GetRandomMultiplier()
        {
            var randomMultiplier = Random.Range(0, 2);
            return randomMultiplier == 1 ? 1 : -1;

        }
    }
}
