using UnityEngine;
using BoarBand.ScriptableObjects.PlayerParams;
using BoarBand.Interfaces;

namespace BoarBand.PlayerObject
{
    public class Player : MonoBehaviour, IResponsable
    {
        [SerializeField] private PlayerMovement _playerMovement;

        [field: SerializeField] public PlayerParameters Parameters { get; private set; }

        public void Initialize(Vector3 pos, Quaternion rot, Joystick joystick)
        {
            transform.SetPositionAndRotation(pos, rot);

            _playerMovement.Initialize(joystick, this);
        }
    }
}
