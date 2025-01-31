using System;
using UnityEngine;
using UnityEngine.UI;
using BoarBand.Interfaces;
using Random = UnityEngine.Random;

namespace BoarBand.Fishing
{
    public class FishingWindow : MonoBehaviour, ISpawnable<FishingAround>
    {
        [SerializeField] private FishingRodSlider _fishingRodSlider;
        [SerializeField] private FishingAround[] _fishingArounds;
        [SerializeField] private RectTransform _spawnPointAround;
        [SerializeField] private Transform _container;
        [SerializeField] private Button _hookButton;

        public event Action OnHookSuccess;
        public event Action OnHookFail;

        private Func<bool> _checkAngle;

        private FishingAround _currentFishingAround;

        public void Initialize()
        {
            gameObject.SetActive(true);

            _currentFishingAround = Spawn();

            _fishingRodSlider.Initialize(ref OnHookSuccess, ref OnHookFail);

            _hookButton.onClick.AddListener(() => 
            {
                if (_checkAngle())
                {
                    OnHookSuccess?.Invoke();
                    return;
                }

                OnHookFail?.Invoke();
            });
        }

        public FishingAround Spawn()
        {
            FishingAround fishingAround = Instantiate(_fishingArounds[Random.Range(0, _fishingArounds.Length)]);
            fishingAround.Initialize(_spawnPointAround.localPosition, _container, out _checkAngle);

            return fishingAround;
        }

        private void OnDisable()
        {
            OnHookSuccess = null;
            OnHookFail = null;
            _hookButton.onClick?.RemoveAllListeners();
            Destroy(_currentFishingAround);
        }
    }
}
