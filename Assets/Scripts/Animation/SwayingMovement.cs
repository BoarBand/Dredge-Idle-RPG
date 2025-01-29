using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoarBand.Animation
{
    public class SwayingMovement : MonoBehaviour
    {
        private float _swaySpeed = 3.0f;
        private float _swayRange = 7.0f;
        private bool _isMoving = false;
        private float _swayTimer = 0.0f;

        private void OnEnable()
        {
            FloatingJoystick.OnMovementStart += OnMovementStart;
            FloatingJoystick.OnMovementEnd += OnMovementEnd;
        }

        private void OnDisable()
        {
            FloatingJoystick.OnMovementStart -= OnMovementStart;
            FloatingJoystick.OnMovementEnd -= OnMovementEnd;
        }

        private void Update()
        {
            _swayTimer += Time.deltaTime * _swaySpeed;

            if (_isMoving)
            {
                float swayX = Mathf.Sin(_swayTimer) * _swayRange;
                Vector3 currentRotation = transform.localEulerAngles;
                transform.localEulerAngles = new Vector3(swayX, currentRotation.y, currentRotation.z);
            }
            else
            {
                float swayZ = Mathf.Sin(_swayTimer) * _swayRange;
                Vector3 currentRotation = transform.localEulerAngles;
                transform.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, swayZ);
            }
        }

        private void OnMovementStart()
        {
            _isMoving = true;
        }

        private void OnMovementEnd()
        {
            _isMoving = false;
        }
    }
}
