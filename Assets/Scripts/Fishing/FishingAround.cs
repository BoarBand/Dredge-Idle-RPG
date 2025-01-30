using System.Collections;
using UnityEngine;

namespace BoarBand.Fishing
{
    public class FishingAround : MonoBehaviour
    {
        [SerializeField] private Transform _pointer;

        private Coroutine _rotatePointerCoroutine;

        private readonly float RotateSpeed = 100f; 

        public void Initialize(Vector3 pos, Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = pos;

            StartRotation();
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
            while (true)
            {
                yield return new WaitForFixedUpdate();
                _pointer.Rotate(-Vector3.forward * RotateSpeed * Time.fixedDeltaTime);
            }
        }

        private void OnDisable()
        {
            StopRotation();
        }
    }
}