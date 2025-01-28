using UnityEngine;
using BoarBand.Actions;
using BoarBand.ScriptableObjects.PlayerParams;
using BoarBand.Spawners;

namespace BoarBand.PlayerObject
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Joystick _joystick;
        private Player _player;

        private readonly MoveActions _movementAction = new MoveActions();

        public void Initialize(Joystick joystick, Player player)
        {
            _joystick = joystick;
            _player = player;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 moveDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;

            _movementAction.FixedMove(transform, moveDirection, _player.Parameters.MoveSpeed);

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation * Quaternion.Euler(0, 90, 0), Time.deltaTime * 10f); 
        }
    }
}