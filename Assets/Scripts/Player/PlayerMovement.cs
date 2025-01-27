using UnityEngine;
using BoarBand.Actions;

namespace BoarBand.PlayerObject
{
    public class PlayerMovement : MonoBehaviour
    {
        private Joystick _joystick;
        private Player _player;

        private readonly MoveActions _moveActions = new MoveActions();

        public void Initialize(Joystick joystick, Player player)
        {
            _joystick = joystick;
            _player = player;
        }

        private void FixedUpdate()
        {
            // movement
        }
    }
}
