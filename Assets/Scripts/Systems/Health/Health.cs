using UnityEngine;

namespace LSEKombat.Systems.Health
{
    public class Health : MonoBehaviour
    {
        /*
            This class holds the health amount for an entity.
        */

        [SerializeField]private int MaxHealth;
        private int m_currentHealth;

        private void OnEnable()
        {
            m_currentHealth = MaxHealth;
        }

        public void IncreaseHealth(int amount)
        {
            m_currentHealth += amount;       
        }

        public void DecreaseHealth(int amount)
        {
            m_currentHealth -= amount;
        }
    }
}
