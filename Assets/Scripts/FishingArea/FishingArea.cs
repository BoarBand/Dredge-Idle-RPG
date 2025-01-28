using UnityEngine;
using BoarBand.Fishes;
using System.Collections.Generic;
using BoarBand.Interfaces;

namespace BoarBand.FishingAreas
{
    public class FishingArea : MonoBehaviour, ISpawnable<Fish>
    {
        [SerializeField] private Transform _borderPoint1;
        [SerializeField] private Transform _borderPoint2;
        [SerializeField] private Transform _fishSpawnPoint;

        [SerializeField] private Fish[] _availableFishes;

        private Fish _selectedFish;
        private uint _fishesAmount;

        private List<Fish> _spawnedFishes = new List<Fish>();
        private readonly uint MaxFishAmount = 10;
        private readonly uint MinFishAmount = 3;

        private void OnEnable()
        {
            Initialize();
        }

        public void Initialize()
        {
            _selectedFish = _availableFishes[Random.Range(0, _availableFishes.Length)];
            _fishesAmount = (uint)Random.Range(MinFishAmount, MaxFishAmount);

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
    }
}
