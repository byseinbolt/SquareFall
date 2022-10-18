using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
   [SerializeField] private Transform _start;
   [SerializeField] private Transform _end;
   [SerializeField] private float _speed;

   private float _currentTime;
   private bool _isMovingForward;

   

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         _isMovingForward = !_isMovingForward;
      }

      _currentTime += _isMovingForward ? Time.deltaTime : -Time.deltaTime;
      var progress = Mathf.PingPong(_currentTime, _speed) / _speed;
      var newPosition = Vector3.Lerp(_start.position, _end.position, progress);
      transform.position = newPosition;
   }
}
