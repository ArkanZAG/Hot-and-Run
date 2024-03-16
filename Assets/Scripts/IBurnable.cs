using UnityEngine;

namespace DefaultNamespace
{
    public interface IBurnable
    {
        public void StartBurn();
        public bool IsBurning { get; }

    }
}