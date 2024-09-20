using UnityEngine;

namespace LSEKombat.Systems.Movement
{
    public class GroundChecker : MonoBehaviour
    {
        /*
            This class checks for solid ground underneath a GameObject
        */

        [Header("SETTINGS")]
        [SerializeField][Range(1,2)] private float GroundCheckDistance;                 //how far do we check for solid ground?
        [SerializeField] private LayerMask GroundLayerMask;                                      //what layers do we consider as solid ground?

        [Space(10f)]

        //debug
        private bool m_IsGrounded;

        //event delegates
        public delegate void GroundCheckUpdateHandler(bool IsGrounded);

        //events
        public event GroundCheckUpdateHandler OnGroundCheckUpdate;

        // Start is called before the first frame update
        private void Start()
        {
            //I assume the player starts on the ground
            m_IsGrounded = true;
        }

        // Update is called once per frame
        private void Update()
        {
            HandleGroundChecks();
        }

        private void HandleGroundChecks()
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance, GroundLayerMask))
            {
                //if the raycast returns true,we are grounded
                m_IsGrounded = true;
            }
            else
            {
                m_IsGrounded = false;
            }

            OnGroundCheckUpdate?.Invoke(m_IsGrounded);
        }
    }
}
