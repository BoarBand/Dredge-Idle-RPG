using UnityEngine;
using BoarBand.Interfaces;

namespace BoarBand.Spawners
{
    public abstract class Spawner<T> : MonoBehaviour, ISpawnable<T> where T : class
    {
        public abstract T Spawn();
    }
}
