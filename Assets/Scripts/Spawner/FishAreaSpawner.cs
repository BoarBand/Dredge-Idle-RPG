using System.Collections.Generic;
using UnityEngine;
using BoarBand.Interfaces;
using BoarBand.Fishing;

namespace BoarBand.Spawners
{
    public class FishAreaSpawner : MonoBehaviour, ISpawnable<FishingArea>
    {
        [SerializeField] private FishingWindow _fishingWindow;
        [SerializeField] private FishingArea _fishingArea;

        private FishingWindow _currentFishingWindow;

        private List<FishingArea> _spawnedFishingAreas = new List<FishingArea>();

        public void Initialize()
        {
            _spawnedFishingAreas.Add(Spawn());
        }

        public FishingArea Spawn()
        {
            FishingArea fishingArea = Instantiate(_fishingArea);
            fishingArea.Initialize(new Vector3(0f, 0f, 19f), Quaternion.identity, CreateOrActivateFishingWindow);
            return fishingArea;
        }

        private void CreateOrActivateFishingWindow()
        {
            if(_currentFishingWindow != null)
            {
                _currentFishingWindow.Initialize();
                return;
            }

            _currentFishingWindow = Instantiate(_fishingWindow);
            _currentFishingWindow.Initialize();
        }
    }
}
