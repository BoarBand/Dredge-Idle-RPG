using UnityEngine;
using BoarBand.Spawners;
using BoarBand.CameraObject;

namespace BoarBand.Bootstraps
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;

        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private CameraFollower _cameraFollower;
        [SerializeField] private FishAreaSpawner _fishAreaSpawner;

        private void Awake()
        {
            _playerSpawner.Initialize(_joystick);
            _cameraFollower.Initialize(_playerSpawner.CurrentPlayer.transform);
            _fishAreaSpawner.Initialize();
        }
    }
}
