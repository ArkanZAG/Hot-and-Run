using UnityEngine;

namespace DefaultNamespace
{
    public class BurnExplodeIce : MonoBehaviour, IBurnable, IExplodeable
    {
        public void StartBurn()
        {
            
        }

        public bool IsBurning { get; }

        public void TriggerExplosion()
        {
            
        }
    }
}