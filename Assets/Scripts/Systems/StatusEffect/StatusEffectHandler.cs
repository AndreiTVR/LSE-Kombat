using UnityEngine;

namespace LSEKombat.Systems.StatusEffect
{
    public class StatusEffectHandler : MonoBehaviour
    {
        //This class has the role of applying the different status effects on an entity.


        public void TakeDamage(float amount)
        {
            Health.Health health = this.gameObject.GetComponent<Health.Health>();

            if(health != null)
            {
                health.DecreaseHealth(amount);
            }
        }

        public void Heal(float amount)
        {
            Health.Health health = this.gameObject.GetComponent<Health.Health>();

            if(health != null)
            {
                health.IncreaseHealth(amount);
            }
        }
    }
}
