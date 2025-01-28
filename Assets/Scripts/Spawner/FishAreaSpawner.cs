using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoarBand.Interfaces;
using BoarBand.FishingAreas;

namespace BoarBand.Spawners
{
    public class FishAreaSpawner : MonoBehaviour, ISpawnable<FishingArea>
    {
        public void Initialize()
        {

        }

        public FishingArea Spawn()
        {
            throw new System.NotImplementedException();
        }
    }
}
