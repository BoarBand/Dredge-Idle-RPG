using UnityEngine;
using BoarBand.Actions;

namespace BoarBand.PlayerObject
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider), typeof(Player))]
    public class PlayerMovement : MonoBehaviour
    {
        private Joystick _joystick;
        private Player _player;

        private readonly MoveActions MoveActions = new MoveActions();
        private readonly float RotateSpeed = 15f;

        public void Initialize(Joystick joystick, Player player)
        {
            if (joystick == null || player == null)
                return;

            _joystick = joystick;
            _player = player;
        }

        private void FixedUpdate()
        {
            if (_joystick == null)
                return;

            Vector3 moveDirection = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);

            MoveActions.FixedMove(transform, moveDirection, _player.Parameters.MoveSpeed);

            if (Vector3.Angle(Vector3.forward, moveDirection) > 1f || Vector3.Angle(Vector3.forward, moveDirection) == 0)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, moveDirection, 1f, 0.0f);
                Quaternion rotateAngles = Quaternion.LookRotation(direct);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateAngles, RotateSpeed);
            }
        }
    }
}
