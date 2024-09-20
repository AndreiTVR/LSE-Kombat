using System;
using UnityEngine;

namespace LSEKombat.Systems.Movement
{
    [RequireComponent(typeof(Input.InputHandler))]
    [RequireComponent(typeof(GroundChecker))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerJump : MonoBehaviour
    {
        /*
            This class handles jumping behaviour for the player
        */

        [Header("SETTINGS")]
        [SerializeField] private float JumpForce;
        [Range(0.1f,10f)][SerializeField] private float JumpCooldown;

        //references
        private Rigidbody2D m_rb;

        //debug
        private bool m_isGrounded = true;
        private bool m_cooldownPassed = true;
        private bool m_canJump = true;
        

        private void Start()
        {
            GetComponent<Input.InputHandler>().OnJumpInputUpdate += Jump;
            GetComponent<GroundChecker>().OnGroundCheckUpdate += SetGroundedState;

            m_rb = GetComponent<Rigidbody2D>();
        }

        private void Jump(bool Jump)
        {
            if(Jump && m_canJump)
            {
                m_rb.AddForce(Vector2.up * JumpForce , ForceMode2D.Impulse);

                m_cooldownPassed = false;

                Invoke(nameof(ResetCooldown) , JumpCooldown);
            }
        }

        private void SetGroundedState(bool IsGrounded)
        {
            m_isGrounded = IsGrounded;
            
            m_canJump = m_isGrounded && m_cooldownPassed;
        }

        private void ResetCooldown()
        {
            m_cooldownPassed = true;
        }

        // 'nuff said,if the player is grounded and the cooldown has passed,they may jump

        private void OnDisable()
        {
            GetComponent<Input.InputHandler>().OnJumpInputUpdate -= Jump;
            GetComponent<GroundChecker>().OnGroundCheckUpdate -= SetGroundedState;
        }
    }
}
