using UnityEngine;
using Cinemachine;

namespace BoarBand.CameraObject
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        public void Initialize(Transform followObj)
        {
            _cinemachineVirtualCamera.Follow = followObj;
            _cinemachineVirtualCamera.LookAt = followObj;
        }
    }
}
