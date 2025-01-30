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
        [SerializeField] private Button _hookButton;

        private FishingAround _currentFishingAround;

        public void Initialize()
        {
            gameObject.SetActive(true);

            _currentFishingAround = Spawn();
        }

        public FishingAround Spawn()
        {
            FishingAround fishingAround = Instantiate(_fishingArounds[Random.Range(0, _fishingArounds.Length)]);
            fishingAround.Initialize(_spawnPointAround.localPosition, _container);
            return fishingAround;
        }
    }
}
