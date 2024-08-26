using System;
using UnityEngine;

namespace LSEKombat.Systems.Input
{
    public class InputHandler : MonoBehaviour
    {
        /*
            This class handles inputs from the Player
        */

        //debug variables

        private int m_movementSide;         // -1 -> Player moves Left ; 1 -> Player moves Right

        
        //event delegates
        public delegate void MovementInputUpdateHandler     (int MovementSide);
        public delegate void JumpInputUpdateHandler         (bool Jump);
        public delegate void CrouchInputUpdateHandler       (bool Crouch);
        public delegate void PunchAttackInputUpdateHandler  (bool PunchAttack);
        public delegate void KickAttackInputUpdateHandler   (bool KickAttack);

        //events
        public event MovementInputUpdateHandler    OnMovementInputUpdate;
        public event JumpInputUpdateHandler        OnJumpInputUpdate;
        public event CrouchInputUpdateHandler      OnCrouchInputUpdate;
        public event PunchAttackInputUpdateHandler OnPunchInputUpdate;
        public event KickAttackInputUpdateHandler  OnKickInputUpdate;

        // Start is called before the first frame update
        private void Start()
        {
            m_movementSide = 0;
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
            float yAxis = GetAxis("Vertical");

            HandleJumpInput(yAxis);
            HandleCrouchInput(yAxis);
        }

        private void HandleLeftRightMovementInput()
        {
            float xAxis = GetAxis("Horizontal");

            //for anyone reading this,see if you can optimize these here if's.They look horrible
            if(xAxis > 0)
                m_movementSide = 1;
            else if(xAxis < 0)
                m_movementSide = -1;
            else
                m_movementSide = 0;

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
            OnPunchInputUpdate?.Invoke(GetButtonDown("Fire1"));             //by default,it should bind to left mouse button
            OnKickInputUpdate?.Invoke(GetButtonDown("Fire2"));              //by default it should bind to right mouse button
        }
        

        private float GetAxis(String AxisName)
        {
            return UnityEngine.Input.GetAxis(AxisName);
        }

        private bool GetButtonDown(String ButtonName)
        {
            return UnityEngine.Input.GetButtonDown(ButtonName);
        }
    }
}
