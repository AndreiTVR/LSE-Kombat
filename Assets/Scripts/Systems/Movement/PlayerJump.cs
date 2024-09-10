using UnityEngine;

namespace LSEKombat.Systems.Movement
{
    [RequireComponent(typeof(Input.InputHandler))]
    [RequireComponent(typeof(GroundChecker))]
    [RequireComponent(typeof(Physics.VelocityHandler))]
    public class PlayerJump : MonoBehaviour
    {
        /*
            This class handles jumping behaviour for the player
        */
        [Header("SETTINGS")]
        [SerializeField]private float JumpMaxVelocity;
        [SerializeField]private float JumpAcceleration;

        //debug
        private bool m_isGrounded;      
        private bool m_hasJumped;           //is the Player mid-jump?
        private float m_jumpVelocity;
        private Physics.VelocityHandler m_velocityHandler;

        // Start is called before the first frame update
        private void Start()
        {
            GetComponent<Input.InputHandler>().OnJumpInputUpdate += ApplyJumpImpulse;
            GetComponent<GroundChecker>().OnGroundCheckUpdate += SetGroundedState;
            m_velocityHandler = GetComponent<Physics.VelocityHandler>();

            m_hasJumped = false;
            m_jumpVelocity = 0;
        }

        private void SetGroundedState(bool IsGrounded)
        {
            m_isGrounded = IsGrounded;
        }

        private void ApplyJumpImpulse(bool Jump)
        {
            //apply a small impulse to the player to get them off the ground
            if(Jump && m_isGrounded)
            {
                m_hasJumped = true;
                m_jumpVelocity += JumpAcceleration * Time.deltaTime;
            }
        }

        // Update is called once per frame
        private void Update()
        {
            //increase the speed (up to JumpMaxVelocity) to get a smoother jump
            if(m_hasJumped && m_jumpVelocity < JumpMaxVelocity)
            {
                m_jumpVelocity += JumpAcceleration * Time.deltaTime;
                m_velocityHandler.AddVelocity(Vector2.up * m_jumpVelocity);
                
            }

            //reset jump behaviour when the player touches the ground
            if(m_isGrounded && m_jumpVelocity >= JumpMaxVelocity)
            {
                m_jumpVelocity = 0;
                m_hasJumped = false;
            }
        }

        private void OnDisable()
        {
            GetComponent<Input.InputHandler>().OnJumpInputUpdate -= ApplyJumpImpulse;
            GetComponent<GroundChecker>().OnGroundCheckUpdate -= SetGroundedState;
        }
    }
}
