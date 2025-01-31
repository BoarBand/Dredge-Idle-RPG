using System;
using System.Collections;
using UnityEngine;

namespace BoarBand.Fishing
{
    public class FishingAround : MonoBehaviour
    {
        [SerializeField] private Transform _pointer;
        [SerializeField] private Transform _pivotPointer;

        [SerializeField] private float _currentAmountFishingRodSlider;

        private Coroutine _rotatePointerCoroutine;

        private readonly float RotateSpeed = 100f;

        private readonly float FillAmountFishingRodSlider = 1f;

        public float MaxAmount => FillAmountFishingRodSlider;
        public float CurrentAmount => _currentAmountFishingRodSlider;

        public event Action<float> FillAmountValue;

        public void Initialize(Vector3 pos, Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = pos;

            StartRotation();
        }

        private void Start()
        {
            _currentAmountFishingRodSlider = FillAmountFishingRodSlider;
            FillAmountValue?.Invoke(_currentAmountFishingRodSlider);
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
            WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

            while (true)
            {
                yield return _waitForFixedUpdate;

                _pointer.Rotate(-Vector3.forward * RotateSpeed * Time.fixedDeltaTime);
            }
        }

        private float FindAngleBetweenObjects(Transform obj1, Transform obj2)
        {
            Vector2 direction = obj2.position - obj1.position;
            float angle = Vector2.SignedAngle(Vector2.right, direction);

            return angle;
        }

        public void CheckAngle()
        {
            float angle = FindAngleBetweenObjects(_pointer, _pivotPointer);

            if (angle >= -30f && angle < 30f)
            {
                DecreaseSlider();
            }
        }

        private void DecreaseSlider()
        {
            _currentAmountFishingRodSlider -= 0.1f; 

            if (_currentAmountFishingRodSlider < 0)
                _currentAmountFishingRodSlider = 0;

            FillAmountValue?.Invoke(_currentAmountFishingRodSlider);
        }

        private void OnDisable()
        {
            StopRotation();
        }
    }
}
