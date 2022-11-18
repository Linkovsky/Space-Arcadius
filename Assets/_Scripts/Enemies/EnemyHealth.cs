using Arcade.UI.Score;
using UnityEngine;

namespace Arcade.Enemy.Health
{
    public class EnemyHealth : MonoBehaviour
    {
        public int CurrentHealth { get; private set; }


        internal void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            if (CurrentHealth <= 0)
            {
                Score.instance.AddScore(100);
                Destroy(transform.parent.gameObject);
            }
                
        }

        internal void SetHealth(int amount)
        {
            CurrentHealth = amount;
        }
    }
}