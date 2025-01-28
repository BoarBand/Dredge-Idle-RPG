using UnityEngine;
using BoarBand.Actions;
using Random = UnityEngine.Random;

namespace BoarBand.Fishes
{
    [RequireComponent(typeof(Fish))]
    public class FishMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private Transform _point1;
        private Transform _point2;

        private Vector3 _targetPoint;
        private Vector3 _diraction;

        private readonly MoveActions MoveActions = new MoveActions();

        private readonly float RotateDiraction = 3.5f;

        public void Initialize(Transform point1, Transform point2)
        {
            _point1 = point1;
            _point2 = point2;

            _targetPoint = GetRandomPointInArea();
            _diraction = (_targetPoint - transform.position).normalized;
        }

        private void FixedUpdate()
        {
            RotateToTarget(_targetPoint);
            MoveActions.FixedMove(transform, _diraction, _moveSpeed);

            if((_targetPoint - transform.position).magnitude < 0.1f)
            {
                _targetPoint = GetRandomPointInArea();
                _diraction = (_targetPoint - transform.position).normalized;
            }

        }

        private void RotateToTarget(Vector3 point)
        {
            Vector3 diraction = point - transform.position;
            Quaternion rotateAngles = Quaternion.LookRotation(diraction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateAngles, RotateDiraction);
        }

        private Vector3 GetRandomPointInArea()
        {
            return new Vector3(Random.Range(_point1.position.x, _point2.position.x), -2f, Random.Range(_point1.position.z, _point2.position.z));
        }
    }
}
