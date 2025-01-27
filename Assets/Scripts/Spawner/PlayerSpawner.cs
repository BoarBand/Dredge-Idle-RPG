using UnityEngine;
using Cinemachine;
using BoarBand.PlayerObject;

namespace BoarBand.Spawners
{
    public class PlayerSpawner : Spawner<Player>
    {
        public static PlayerSpawner Instance { get; private set; }

        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Player _player;

        private Joystick _joystick;

        public Player CurrentPlayer { get; private set; }

        public void Initialize(Joystick joystick)
        {
            Instance = this;

            _joystick = joystick;

            CurrentPlayer = Spawn();

            _cinemachineVirtualCamera.Follow = CurrentPlayer.transform;
        }

        public override Player Spawn()
        {
            Player player = Instantiate(_player);
            player.Initialize(_spawnPoint.position, Quaternion.Euler(0f, 90f, 0f), _joystick);

            CurrentPlayer = player;

            return player;
        }
    }
}
