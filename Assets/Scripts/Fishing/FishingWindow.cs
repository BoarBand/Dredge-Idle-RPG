using BoarBand.Animations;
using System;
using UnityEngine;
using UnityEngine.UI;
using BoarBand.Interfaces;
using Random = UnityEngine.Random;

namespace BoarBand.Fishing
{
    public class FishingWindow : MonoBehaviour, ISpawnable<FishingAround>
    {
        [SerializeField] private Slider _fishingRodSlider;
        [SerializeField] private FishingAround[] _fishingArounds;
        [SerializeField] private RectTransform _spawnPointAround;
        [SerializeField] private Transform _container;
        [SerializeField] private PointerUpDownAnimation _pointerAnimation;

        private FishingAround _currentFishingAround;

        private readonly float FillAmountFishingRodSlider = 1f;

        private void OnEnable()
        {
            if (_currentFishingAround != null)
            {
                Initialize();
            }
        }

        private void OnDisable()
        {
            if (_currentFishingAround != null)
            {
                _currentFishingAround.FillAmountValue -= UpdateAmount;
            }
        }

        public void Initialize()
        {
            gameObject.SetActive(true);

            _currentFishingAround = Spawn();

            _fishingRodSlider.value = 1f;

            _pointerAnimation.OnPointerDownEvent.AddListener(OnPointerDown);

            UpdateAmount(_currentFishingAround.CurrentAmount);
            _currentFishingAround.FillAmountValue += UpdateAmount;
        }

        private void OnPointerDown(Transform obj)
        {
            if (_currentFishingAround != null)
            {
                _currentFishingAround.CheckAngle();
            }
        }

        private void UpdateAmount(float newAmount)
        {
            UpdateVisuals(newAmount / FillAmountFishingRodSlider);
        }

        protected void UpdateVisuals(float fillAmount)
        {
            if (_fishingRodSlider != null)
            {
                _fishingRodSlider.value = fillAmount;
            }
        }

        public FishingAround Spawn()
        {
            FishingAround fishingAround = Instantiate(_fishingArounds[Random.Range(0, _fishingArounds.Length)]);
            fishingAround.Initialize(_spawnPointAround.localPosition, _container);

            return fishingAround;
        }
    }
}
