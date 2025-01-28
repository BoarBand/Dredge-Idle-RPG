using UnityEngine;

namespace BoarBand.Fishes
{
    public class Fish : MonoBehaviour
    {
        [SerializeField] private FishMovement _movement;

        public void Initialize(Vector3 pos, Quaternion rot, Transform point1, Transform point2)
        {
            transform.SetPositionAndRotation(pos, rot);

            _movement.Initialize(point1, point2);
        }
    }
}
