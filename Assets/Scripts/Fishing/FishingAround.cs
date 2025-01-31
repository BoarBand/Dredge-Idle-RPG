using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace BoarBand.Fishing
{
    public class FishingAround : MonoBehaviour
    {
        [SerializeField] private Transform _pointer;

        [SerializeField] private List<string> _greenAreaAngleLimitsString = new List<string>();

        private List<int[]> _greenAreaAngleLimits = new List<int[]>();

        private Coroutine _rotatePointerCoroutine;

        private readonly float RotateSpeed = 50f; // 100f

        public void Initialize(Vector3 pos, Transform parent, out Func<bool> checkAngle)
        {
            FromStringToIntAngles(_greenAreaAngleLimitsString, out _greenAreaAngleLimits);

            transform.SetParent(parent);
            transform.localPosition = pos;

            StartRotation();

            checkAngle = CheckIfPointerInGreenArea;
        }

        private bool CheckIfPointerInGreenArea()
        {
            foreach (int[] angleLimit in _greenAreaAngleLimits)
            {
                if (Mathf.Cos(angleLimit[0]) < Mathf.Cos(_pointer.localEulerAngles.z) && Mathf.Cos(angleLimit[1]) > Mathf.Cos(_pointer.localEulerAngles.z))
                    return true;
            }
            return false;
        }

        private void FromStringToIntAngles(List<string> angleLimitsString, out List<int[]> angleLimits)
        {
            angleLimits = new List<int[]>();

            foreach (string str in angleLimitsString)
            {
                int[] angles = new int[2];
                string[] anglesString;
                _ = new string[2];
                anglesString = str.Split(" ");
                angles[0] = Convert.ToInt32(anglesString[0]);
                angles[1] = Convert.ToInt32(anglesString[1]);

                angleLimits.Add(angles);
            }
        }

        private void StartRotation()
        {
            if (_rotatePointerCoroutine != null)
                StopCoroutine(_rotatePointerCoroutine);

            _rotatePointerCoroutine = StartCoroutine(RotatePointer());
        }

        private void StopRotation()
        {
            if (_rotatePointerCoroutine != null)
                StopCoroutine(_rotatePointerCoroutine);

            _rotatePointerCoroutine = null;
        }

        private IEnumerator RotatePointer()
        {
            WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

            while (true)
            {
                yield return waitForFixedUpdate;

                _pointer.Rotate(-Vector3.forward * RotateSpeed * Time.fixedDeltaTime);
            }
        }

        private void OnDisable()
        {
            StopRotation();
        }
    }
}
