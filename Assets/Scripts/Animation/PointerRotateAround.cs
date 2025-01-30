using UnityEngine;
using R3;
using System;

namespace BoarBand.Animations
{
    public class PointerRotateAround : MonoBehaviour
    {
        [SerializeField] GameObject _pivotObject;
        private float _rotateSpeed = -20f;

        private CompositeDisposable _disposable = new CompositeDisposable();

        private IDisposable _runAnimation;

        public  void SetRunAnimation()
        {
            if (_runAnimation != null)
                _disposable.Dispose();

            _runAnimation = Observable.EveryUpdate().Subscribe(_ =>
            {
                transform.RotateAround(_pivotObject.transform.position, new Vector3(0, 0, 1), _rotateSpeed * Time.deltaTime);
            }).AddTo(_disposable);
        }

        private float FindAngle()
        {
            Vector2 targetDirectional = _pivotObject.transform.position - transform.position;

            float angle = Vector2.SignedAngle(targetDirectional, Vector2.up);

            return angle;
        }

        ~PointerRotateAround()
        {
            if (_runAnimation != null)
                _disposable.Dispose();
        }
    }
}
