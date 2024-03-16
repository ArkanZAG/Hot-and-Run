using UnityEngine;

namespace DefaultNamespace
{
    public class BurnExplodeFire : MonoBehaviour, IBurnable, IExplodeable
    {
        public void StartBurn()
        {
            //countdown & explode
        }

        public bool IsBurning { get; }

        public void TriggerExplosion()
        {
            
        }
    }
}