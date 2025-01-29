using UnityEngine;

namespace BoarBand.Actions
{
    public class LookAtMainCamera : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}