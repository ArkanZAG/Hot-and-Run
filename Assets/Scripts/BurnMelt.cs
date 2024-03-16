using UnityEngine;

namespace DefaultNamespace
{
    public class BurnMelt : MonoBehaviour, IBurnable
    {
        private bool isOnFire;
        private bool isMelting;
        public void StartBurn()
        {
            // melt and burn
        }

        public bool IsBurning => !isMelting && isOnFire; 
    }
}