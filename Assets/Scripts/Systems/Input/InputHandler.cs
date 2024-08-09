using UnityEngine;

namespace LSEKombat.Systems.Input
{
    public class InputHandler : MonoBehaviour
    {
        /*
            This class handles inputs from the Player
        */


        [Header("KEYS")]
        [SerializeField]private KeyCode MoveLeft_KeyCode;
        [SerializeField]private KeyCode MoveRight_KeyCode;
        [SerializeField]private KeyCode Jump_KeyCode;
        [SerializeField]private KeyCode Crouch_KeyCode;

        //debug variables

        private int m_movementSide;         // -1 -> Player moves Left ; 1 -> Player moves Right

        //event delegates

        public delegate void MovementInputUpdateHandler     (int MovementSide);
        public delegate void JumpInputUpdateHandler         (bool Jump);
        public delegate void CrouchInputUpdateHandler       (bool Crouch);

        //events
        public event MovementInputUpdateHandler OnMovementInputUpdate;
        public event JumpInputUpdateHandler     OnJumpInputUpdate;
        public event CrouchInputUpdateHandler   OnCrouchInputUpdate;

        // Start is called before the first frame update
        private void Start()
        {
            m_movementSide = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            HandleLeftRightMovementInput();
            HandleJumpInput();
            HandleCrouchInput();

        }
        private void HandleLeftRightMovementInput()
        {
            if (GetKey(MoveLeft_KeyCode))
            {
                m_movementSide = -1;
            }

            if (GetKey(MoveRight_KeyCode))
            {
                m_movementSide = 1;
            }

            if(!GetKey(MoveLeft_KeyCode) && !GetKey(MoveRight_KeyCode))
            {
                m_movementSide = 0;
            }

            OnMovementInputUpdate?.Invoke(m_movementSide);
        }
        private void HandleJumpInput()
        {
            OnJumpInputUpdate?.Invoke(GetKeyDown(Jump_KeyCode));
        }
        private void HandleCrouchInput()
        {
            OnCrouchInputUpdate?.Invoke(GetKey(Crouch_KeyCode));
        }
        private bool GetKey(KeyCode keyCode)
        {
            return (UnityEngine.Input.GetKey(keyCode));
        }
        private bool GetKeyDown(KeyCode keyCode)
        {
            return (UnityEngine.Input.GetKeyDown(keyCode));
        }
    }
}
