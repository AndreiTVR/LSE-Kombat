using System;
using UnityEngine;

namespace LSEKombat.Systems.Input
{
    public class InputHandler : MonoBehaviour
    {
        /*
            This class handles inputs from the Player
        */

        //references
        [SerializeField] private InputActionsScriptableObject InputActions;

        //debug variables

        private int m_movementSide;         // -1 -> Player moves Left ; 1 -> Player moves Right

        
        //event delegates
        public delegate void MovementInputUpdateHandler     (int MovementSide);
        public delegate void JumpInputUpdateHandler         (bool Jump);
        public delegate void CrouchInputUpdateHandler       (bool Crouch);
        public delegate void PunchAttackInputUpdateHandler  (bool PunchAttack);
        public delegate void KickAttackInputUpdateHandler   (bool KickAttack);
        public delegate void CastFirstUpdateHandler(bool CastFirst);
        //events
        public event CastFirstUpdateHandler OnCastFirstUpdate;
        public event MovementInputUpdateHandler    OnMovementInputUpdate;
        public event JumpInputUpdateHandler        OnJumpInputUpdate;
        public event CrouchInputUpdateHandler      OnCrouchInputUpdate;
        public event PunchAttackInputUpdateHandler OnPunchInputUpdate;
        public event KickAttackInputUpdateHandler  OnKickInputUpdate;
        SpriteRenderer sprite;
        // Start is called before the first frame update
        private void Start()
        {
            m_movementSide = 0;
            sprite = GetComponent<SpriteRenderer>();
            if(InputActions == null)
            {
                Debug.LogError("INPUT ERROR : NO INPUT ACTIONS FOR : "  + this.gameObject.name);
            }
        }

        // Update is called once per frame
        private void Update()
        {
            HandleLeftRightMovementInput();

            HandleUpDownMovementInput();

            HandleCombatInput();
        }

        private void HandleUpDownMovementInput()
        {
            float yAxis = 0;

            if(GetKeyDown(InputActions.Jump_Key))
            {
                yAxis = 1;
            }else if(GetKey(InputActions.Crouch_Key))
            {
                yAxis = -1;
            }

            HandleJumpInput(yAxis);
            HandleCrouchInput(yAxis);
        }

        private void HandleLeftRightMovementInput()
        {
            m_movementSide = 0;

            if(GetKey(InputActions.MoveRight_Key))
            {
                sprite.flipX = false;
                m_movementSide = 1;
            }else if(GetKey(InputActions.MoveLeft_Key))
            {
                m_movementSide = -1;
                sprite.flipX=true;
            }

            OnMovementInputUpdate?.Invoke(m_movementSide);
        }
        private void HandleJumpInput(float yAxis)
        {
            if(yAxis > 0)
                OnJumpInputUpdate?.Invoke(true);
            else
                OnJumpInputUpdate?.Invoke(false);
        }
        private void HandleCrouchInput(float yAxis)
        {
            if(yAxis < 0)
                OnCrouchInputUpdate?.Invoke(true);
            else
                OnCrouchInputUpdate?.Invoke(false);
        }

        private void HandleCombatInput()
        {
            OnPunchInputUpdate?.Invoke(GetKeyDown(InputActions.Punch_Key));             
            OnKickInputUpdate?.Invoke(GetKeyDown(InputActions.Kick_Key));
            OnCastFirstUpdate?.Invoke(GetKeyDown(InputActions.FirstAbility_Key));
            OnCastFirstUpdate?.Invoke(GetKeyDown(InputActions.SecondAbility_Key));
            OnCastFirstUpdate?.Invoke(GetKeyDown(InputActions.Ultimate_Key));
        }
        

        private float GetAxis(String AxisName)
        {
            return UnityEngine.Input.GetAxis(AxisName);
        }

        private bool GetButtonDown(String ButtonName)
        {
            return UnityEngine.Input.GetButtonDown(ButtonName);
        }

        private bool GetKeyDown(KeyCode Key)
        {
            return UnityEngine.Input.GetKeyDown(Key);
        }

        private bool GetKey(KeyCode Key)
        {
            return UnityEngine.Input.GetKey(Key);
        }
    }
}
