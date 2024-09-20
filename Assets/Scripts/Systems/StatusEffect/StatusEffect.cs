using LSEKombat.Systems.Tick;
using UnityEngine;

namespace LSEKombat.Systems.StatusEffect
{
    public abstract class StatusEffect : MonoBehaviour
    {
        /*
            This class serves as a base for all status effects (ex: Heal,Damage AOE,Slowness,etc).


            Naming convention for derived classes:
            "*Status Effect Name*-StatusEffect"

            For example:
            "Heal_StatusEffect"
        */

        private void Start()
        {
            TickManager.Instance.OnTickInvoke += Tick;
        }

        public abstract void Tick();

        public abstract void Execute(StatusEffectHandler StatusEffectHandler);      //When certain conditions are met,the execute method should apply the status effect on the StatusEffectHandler

        private void OnDisable()
        {
            TickManager.Instance.OnTickInvoke -= Tick;
        }
    }
}
