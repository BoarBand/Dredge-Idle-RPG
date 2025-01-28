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

        public float MovementSpeed { get; set; }

        public void Initialize(Joystick joystick, Player player, float speed)
        {
            _joystick = joystick;
            _player = player;
            MovementSpeed = speed;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 moveDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;

            _rigidbody.velocity = moveDirection * MovementSpeed;

            if (moveDirection.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation * Quaternion.Euler(0, 90, 0), Time.deltaTime * 10f); 
            }
        }
    }
}
