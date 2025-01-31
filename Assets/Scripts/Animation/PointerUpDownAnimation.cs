using UnityEngine;
using UnityEngine.Events;

namespace BoarBand.Animations
{
    public class PointerUpDownAnimation : MonoBehaviour
    {
        public UnityEvent<Transform> OnPointerDownEvent;
        public UnityEvent<Transform> OnPointerUpEvent;

        public void OnPointerDown(Transform obj)
        {
            obj.localScale = new Vector3(.9f, .9f, .9f);
            OnPointerDownEvent?.Invoke(obj);
        }

        public void OnPointerUp(Transform obj)
        {
            obj.localScale = Vector3.one;
            OnPointerUpEvent?.Invoke(obj);
        }
    }
}
