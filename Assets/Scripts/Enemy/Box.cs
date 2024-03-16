using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Box : MonoBehaviour,  IDamageable
    {
        public void OnDamage()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            OnDamage();
        }
    }
}