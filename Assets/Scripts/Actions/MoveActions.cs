using UnityEngine;
using BoarBand.Interfaces;

namespace BoarBand.Actions
{
    public sealed class MoveActions : IMovable
    {
        public void FixedMove(Transform obj, Vector3 diraction, float speed)
        {
            obj.position += diraction * speed * Time.fixedDeltaTime;
        }

        public void Move(Transform obj, Vector3 diraction, float speed)
        {
            obj.position += diraction * speed * Time.deltaTime;
        }
    }
}
