using UnityEngine;

namespace LSEKombat.Systems.Health
{
    public class Health : MonoBehaviour
    {
        /*
            This class holds the health amount for an entity.
        */

        [SerializeField]private float MaxHealth;
        private float m_currentHealth;

        private void OnEnable()
        {
            m_currentHealth = MaxHealth;
        }

        public void IncreaseHealth(float amount)
        {
            m_currentHealth += amount;
            m_currentHealth = Mathf.Clamp(m_currentHealth,0,MaxHealth);
        }

        public void DecreaseHealth(float amount)
        {
            m_currentHealth -= amount;
            m_currentHealth = Mathf.Clamp(m_currentHealth,0,MaxHealth);
        }
    }
}
