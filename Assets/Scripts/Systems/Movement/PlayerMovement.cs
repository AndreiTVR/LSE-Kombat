using LSEKombat.Systems.Physics;
using UnityEngine;

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
        [SerializeField] private float MovementSpeed;
        [SerializeField][Range(0,1)] private float CrouchingSpeedPercentage;        //percentage ,of the normal movement speed, the player has when they are crouched 

        //debug
        private int m_movementSide;
        private bool m_isCrouching;

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
        }

        private void GetCrouchingState(bool IsCrouching)
        {
            m_isCrouching = IsCrouching;
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
