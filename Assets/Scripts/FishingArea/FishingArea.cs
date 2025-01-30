using System;
using UnityEngine;
using BoarBand.Fishes;
using System.Collections.Generic;
using BoarBand.Interfaces;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace BoarBand.Fishing
{
    public class FishingArea : MonoBehaviour, ISpawnable<Fish>
    {
        [SerializeField] private Transform _borderPoint1;
        [SerializeField] private Transform _borderPoint2;
        [SerializeField] private Transform _fishSpawnPoint;

        [SerializeField] private Canvas _buttonCanvas;
        [SerializeField] private Button _fishingButton;

        [SerializeField] private Fish[] _availableFishes;

        private Fish _selectedFish;
        private uint _fishesAmount;

        public event Action ClickedFishingButton;//

        private List<Fish> _spawnedFishes = new List<Fish>();

        private readonly uint MaxFishAmount = 10;
        private readonly uint MinFishAmount = 3;

        public void Initialize(Vector3 pos, Quaternion rot, Action clickedFishingButton)
        {
            transform.SetPositionAndRotation(pos, rot);

            ClickedFishingButton = clickedFishingButton;

            _selectedFish = _availableFishes[Random.Range(0, _availableFishes.Length)];
            _fishesAmount = (uint)Random.Range(MinFishAmount, MaxFishAmount);

            _fishingButton.onClick.AddListener(() => ClickedFishingButton.Invoke());

            for(int i = 0; i < _fishesAmount; i++)
            {
                Fish fish = Spawn();
                _spawnedFishes.Add(fish);
            }
        }

        public Fish Spawn()
        {
            Fish fish = Instantiate(_selectedFish);
            fish.Initialize(_fishSpawnPoint.position, Quaternion.identity, _borderPoint1, _borderPoint2);

            return fish;
        }

        public void Disactivate()
        {
            ClickedFishingButton = null;
            _fishingButton.onClick.RemoveAllListeners();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IResponsable responsable))
            {
                _buttonCanvas.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IResponsable responsable))
            {
                _buttonCanvas.gameObject.SetActive(false);
            }
        }
    }
}
