using UnityEngine;

namespace BoarBand.Interfaces
{
    public interface IMovable
    {
        public void FixedMove(Transform obj, Vector3 diraction, float speed);

        public void Move(Transform obj, Vector3 diraction, float speed);
    }
}
