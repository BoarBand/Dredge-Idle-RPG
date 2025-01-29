using UnityEngine;
using BoarBand.ScriptableObjects.PlayerParams;
using BoarBand.Interfaces;
using BoarBand.Animations;

namespace BoarBand.PlayerObject
{
    public class Player : MonoBehaviour, IResponsable
    {
        [SerializeField] private PlayerMovement _playerMovement;

        private AnimationManager _animator;

        [field: SerializeField] public PlayerParameters Parameters { get; private set; }

        public void Initialize(Vector3 pos, Quaternion rot, Joystick joystick)
        {
            transform.SetPositionAndRotation(pos, rot);

            _playerMovement.Initialize(joystick, this);

            _animator = new PlayerAnimationManager(transform);

            joystick.PointerDown += () => _animator.SetRunAnimation();
            joystick.PointerUp += () => _animator.SetIdleAnimation();
        }
    }
}
