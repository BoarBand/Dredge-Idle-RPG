using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoarBand.Animations
{
    public abstract class AnimationManager
    {
        public AnimationManager(){}

        public abstract void SetIdleAnimation();
        public abstract void SetRunAnimation();

        ~AnimationManager() { }
    }
}
