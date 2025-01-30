using BoarBand.Animations;
using System;
using UnityEngine;

namespace BoarBand.Fishing
{
    public class FishingWindow : MonoBehaviour
    {
        private PointerRotateAround _animator;

        public void Initialize(FishingArea fishingArea)
        {
            gameObject.SetActive(true);

            _animator = new PointerRotateAround();

            fishingArea.ClickedFishingButton += () => _animator.SetRunAnimation();
        }
    }
}
