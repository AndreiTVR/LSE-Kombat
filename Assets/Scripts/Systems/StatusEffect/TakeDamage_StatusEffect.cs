using UnityEngine;

namespace LSEKombat.Systems.StatusEffect
{
    public class TakeDamage_StatusEffect : StatusEffect
    {
        [Header("SETTINGS")]
        [SerializeField]private float RaycastSize;
        [SerializeField]private bool DrawDebug = true;

        [SerializeField]private int DamageAmount;

        //debug
        private Vector2 m_raycastPosition;
        private Vector2 m_raycastSize;

        public override void Tick()
        {

            m_raycastPosition = new Vector2(transform.position.x , transform.position.y);
            m_raycastSize = Vector2.one * RaycastSize;

            Collider2D[] colliders = Physics2D.OverlapBoxAll(m_raycastPosition,m_raycastSize,0f);

            foreach (Collider2D collider in colliders)
            {

                StatusEffectHandler statusEffectHandler = collider.gameObject.GetComponent<StatusEffectHandler>();
                if(statusEffectHandler != null)
                {
                    this.Execute(statusEffectHandler);
                }
            }
        }

        public override void Execute(StatusEffectHandler StatusEffectHandler)
        {
            StatusEffectHandler.TakeDamage(DamageAmount);
        }

        private void OnDrawGizmos()
        {
            if(DrawDebug)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(transform.position , Vector3.one * RaycastSize);
            }
        }
    }
}
