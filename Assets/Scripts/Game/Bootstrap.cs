using UnityEngine;
using BoarBand.Spawners;

namespace BoarBand.Bootstraps
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private PlayerSpawner _playerSpawner;

        private void Awake()
        {
            _playerSpawner.Initialize(_joystick);
        }
    }
}
