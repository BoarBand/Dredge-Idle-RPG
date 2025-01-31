using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace BoarBand.Fishing
{
    [RequireComponent(typeof(Slider))]
    public class FishingRodSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private Coroutine _fisingSliderCoroutine;

        private readonly float ChangeSpeed = .1f;
        private readonly float ChangeStep = .15f;

        public void Initialize(ref Action onHookSucces, ref Action onHookFail)
        {
            _slider.value = _slider.maxValue;

            onHookSucces += () => print("Success");
            onHookFail += () => print("Fail");

            onHookSucces += () => 
            {
                if (_slider.value - ChangeStep <= 0)
                {
                    _slider.value = 0;
                    return;
                }
                _slider.value -= ChangeStep;
            };
            onHookFail += () => 
            {
                if (_slider.value + ChangeStep >= 1)
                {
                    _slider.value = 1;
                    return;
                }
                _slider.value += ChangeStep;
            };

            StartFishing();
        }

        private void StartFishing()
        {
            if (_fisingSliderCoroutine != null)
                StopCoroutine(_fisingSliderCoroutine);
            _fisingSliderCoroutine = StartCoroutine(FishingSlider());
        }

        private IEnumerator FishingSlider()
        {
            WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

            while (_slider.value > _slider.minValue)
            {
                yield return waitForFixedUpdate;

                _slider.value -= ChangeSpeed * Time.fixedDeltaTime;
            }
        }
    }
}
