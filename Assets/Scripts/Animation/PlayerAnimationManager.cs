using UnityEngine;
using R3;
using System;

namespace BoarBand.Animations
{
    public class PlayerAnimationManager : AnimationManager
    {
        private Transform _objectTransform;

        private CompositeDisposable _disposableUpdate = new CompositeDisposable();

        private IDisposable _idleAnimation;
        private IDisposable _runAnimation;

        private float _swayTimer = 0.0f;

        private readonly float SwaySpeed = 3.0f;
        private readonly float SwayRange = 7.0f;

        public PlayerAnimationManager(Transform obj) : base()
        {
            _objectTransform = obj;
        }

        public override void SetIdleAnimation()
        {
            if (_runAnimation != null)
                _disposableUpdate.Remove(_runAnimation);

            if (_idleAnimation != null)
                _disposableUpdate.Remove(_idleAnimation);

            _idleAnimation = Observable.EveryUpdate().Subscribe(_ => 
            {
                _swayTimer += Time.fixedDeltaTime * SwaySpeed;

                float swayZ = Mathf.Sin(_swayTimer) * SwayRange;
                Vector3 currentRotation = _objectTransform.localEulerAngles;
                _objectTransform.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, swayZ);
            }).AddTo(_disposableUpdate);
        }

        public override void SetRunAnimation()
        {
            if (_runAnimation != null)
                _disposableUpdate.Remove(_runAnimation);

            if (_idleAnimation != null)
                _disposableUpdate.Remove(_idleAnimation);

            _runAnimation = Observable.EveryUpdate().Subscribe(_ =>
            {
                _swayTimer += Time.fixedDeltaTime * SwaySpeed;

                float swayX = Mathf.Sin(_swayTimer) * SwayRange;
                Vector3 currentRotation = _objectTransform.localEulerAngles;
                _objectTransform.localEulerAngles = new Vector3(swayX, currentRotation.y, currentRotation.z);
            }).AddTo(_disposableUpdate);
        }

        ~PlayerAnimationManager()
        {
            _objectTransform = null;

            if (_runAnimation != null)
                _disposableUpdate.Remove(_runAnimation);

            if (_idleAnimation != null)
                _disposableUpdate.Remove(_idleAnimation);
        }
    }
}
