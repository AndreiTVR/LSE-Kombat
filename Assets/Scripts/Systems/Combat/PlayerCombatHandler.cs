using LSEKombat.Systems.Input;
using LSEKombat.Systems.Movement;
using UnityEngine;

namespace LSEKombat.Systems.Combat
{
    [RequireComponent(typeof(InputHandler))]
    public class PlayerCombatHandler : MonoBehaviour
    {
        /*
            This class manages the combat (the different attacks,for example) for the player

            !This class should only hold the ATTACK logic,not the ANIMATION logic!
        */

        //debug
        private bool m_IsGrounded;
        private bool m_IsCrouched;
        private int  m_MovementSide;
        private bool m_PunchAttack;
        private bool m_KickAttack;


        // Start is called before the first frame update
        private void Start()
        {
            //get all movement variables,left right movement,crouching and grounded status

            GroundChecker groundChecker = GetComponent<GroundChecker>();
            if(groundChecker)
            {
                groundChecker.OnGroundCheckUpdate += UpdateGroundedState; 
            }else
            {
                m_IsGrounded = true;
            }


            PlayerCrouch playerCrouch = GetComponent<PlayerCrouch>();
            if(playerCrouch)
            {
                playerCrouch.OnCrouchStateUpdate += UpdateCrouchState;
            }else
            {
                m_IsCrouched = false;
            }

            //grab input
            InputHandler inputHandler = GetComponent<InputHandler>();
            inputHandler.OnMovementInputUpdate += UpdateMovementSide;
            inputHandler.OnPunchInputUpdate += UpdatePunchInputState;
            inputHandler.OnKickInputUpdate += UpdateKickInputState;
            
            
        }

        private void UpdateGroundedState(bool IsGrounded)
        {
            m_IsGrounded = IsGrounded;
        }

        private void UpdateCrouchState(bool IsCrouching)
        {
            m_IsCrouched = IsCrouching;
        }

        private void UpdateMovementSide(int MovementSide)
        {
            //only store non zero values
            if(MovementSide != 0)
            {
                m_MovementSide = MovementSide;
            }
        }

        private void UpdatePunchInputState(bool PunchAttack)
        {
            m_PunchAttack = PunchAttack;
        }

        private void UpdateKickInputState(bool KickAttack)
        {
            m_KickAttack = KickAttack;
        }

        // Update is called once per frame
        private void Update()
        {
            if(m_PunchAttack)
            {
               

                if(m_IsGrounded && !m_IsCrouched)
                {
                    
                    
                    return;
                }

               
            }
            else if(m_KickAttack)
            {
               

                if(m_IsGrounded && !m_IsCrouched)
                {
                    //do normal kick
                    Debug.Log("Normal Kick");
                    return;
                }

         
            }
        }
    }
}
