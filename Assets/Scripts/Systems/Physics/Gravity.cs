using UnityEngine;

namespace LSEKombat.Systems.Physics
{
    [RequireComponent(typeof(Movement.GroundChecker))]
    [RequireComponent(typeof(VelocityHandler))]
    public class Gravity : MonoBehaviour
    {
        /*
            This class enables gravity for a GameObject
        */
        [SerializeField]private float GravityAcceleration;              //acceleration in m/s^2

        //debug
        private bool m_isGrounded;
        private float m_fallingSpeed;

        //references
        private VelocityHandler m_velocityHandler;

        // Start is called before the first frame update
        private void OnEnable()
        {
            GetComponent<Movement.GroundChecker>().OnGroundCheckUpdate += SetGroundedState;
            m_velocityHandler = GetComponent<VelocityHandler>();

            m_fallingSpeed = 0f;
        }

        private void SetGroundedState(bool IsGrounded)
        {
            m_isGrounded = IsGrounded;
        }

        // Update is called once per frame
        private void Update()
        {
            HandleGravity();
        }

        private void HandleGravity()
        {
            if (!m_isGrounded)
            {
                m_fallingSpeed += GravityAcceleration * Time.deltaTime;
                m_velocityHandler.AddVelocity(Vector2.down * m_fallingSpeed);
            }
            else
            {
                m_fallingSpeed = 0f;
            }

            
        }

        private void OnDisable()
        {
            GetComponent<Movement.GroundChecker>().OnGroundCheckUpdate -= SetGroundedState;
        }
    }
}
