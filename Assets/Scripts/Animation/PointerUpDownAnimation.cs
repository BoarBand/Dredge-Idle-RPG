using UnityEngine;

namespace BoarBand.Animations
{
    public class PointerUpDownAnimation : MonoBehaviour
    {
        public void OnPointerDown(Transform obj)
        {
            obj.localScale = new Vector3(.9f, .9f, .9f);
        }

        public void OnPointerUp(Transform obj)
        {
            obj.localScale = Vector3.one;
        }
    }
}
