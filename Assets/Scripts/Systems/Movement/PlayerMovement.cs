using LSEKombat.Systems.Physics;
using UnityEngine;
using System.Collections;

namespace LSEKombat.Systems.Movement
{
    [RequireComponent(typeof(Input.InputHandler))]
    [RequireComponent(typeof(VelocityHandler))]
    public class PlayerMovement : MonoBehaviour
    {
        /*
            This class handles left-right movement for the Player
        */
        [Header("SETTINGS")]
        [SerializeField] public float MovementSpeed;
        float originalMovementSpeed;
       
        [SerializeField][Range(0,1)] private float CrouchingSpeedPercentage;        //percentage ,of the normal movement speed, the player has when they are crouched 

        //debug
        private int m_movementSide;
        private bool m_isCrouching;
        public bool isOnStun;
         public float stunTime=2.0f;
        //references
        private VelocityHandler m_velocityHandler;
        
        
        private void OnEnable()
        {
            GetComponent<Input.InputHandler>().OnMovementInputUpdate += SetMovementSide;
            m_velocityHandler = GetComponent<VelocityHandler>();

            PlayerCrouch m_playerCrouch;
            gameObject.TryGetComponent<PlayerCrouch>(out m_playerCrouch);
            m_playerCrouch.OnCrouchStateUpdate += GetCrouchingState;

            m_movementSide = 0;
                    
        }
        private void Start(){
            originalMovementSpeed = MovementSpeed;
        }

        private void SetMovementSide(int MovementSide)
        {
            m_movementSide = MovementSide;
            
        }
        
        // Update is called once per frame
        private void Update()
        {
            if(!m_isCrouching)
                m_velocityHandler.AddVelocity(Vector2.right * m_movementSide * MovementSpeed);
            else
                m_velocityHandler.AddVelocity(Vector2.right * m_movementSide * MovementSpeed * CrouchingSpeedPercentage);

            if(isOnStun == false){
                MovementSpeed = originalMovementSpeed;
            }

        }

        private void GetCrouchingState(bool IsCrouching)
        {
            m_isCrouching = IsCrouching;
        }
        public void StunEffect(){
             
             MovementSpeed = 0;
             StartCoroutine(ThrowAbilityCooldown());

        }
        private IEnumerator ThrowAbilityCooldown()
    {
        isOnStun = true;
        yield return new WaitForSeconds(stunTime);
        isOnStun = false;
    }

        private void OnDisable()
        {
            GetComponent<Input.InputHandler>().OnMovementInputUpdate -= SetMovementSide;

            PlayerCrouch m_playerCrouch;
            gameObject.TryGetComponent<PlayerCrouch>(out m_playerCrouch);
            m_playerCrouch.OnCrouchStateUpdate -= GetCrouchingState;
        }
    }
}
