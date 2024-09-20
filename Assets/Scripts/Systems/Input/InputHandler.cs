using System;
using System.Security.Cryptography;
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

        [SerializeField] GameObject Player; 
        
        //event delegates
        public delegate void MovementInputUpdateHandler     (int MovementSide);
        public delegate void JumpInputUpdateHandler         (bool Jump);
        public delegate void CrouchInputUpdateHandler       (bool Crouch);
        public delegate void PunchAttackInputUpdateHandler  (bool PunchAttack);
        public delegate void KickAttackInputUpdateHandler   (bool KickAttack);
        
        public delegate void CastFirstAbilityUpdateHandler (bool CastFirst);

        //events
        public event MovementInputUpdateHandler    OnMovementInputUpdate;
        public event JumpInputUpdateHandler        OnJumpInputUpdate;
        public event CrouchInputUpdateHandler      OnCrouchInputUpdate;
        public event PunchAttackInputUpdateHandler OnPunchInputUpdate;
        public event KickAttackInputUpdateHandler  OnKickInputUpdate;

        public event CastFirstAbilityUpdateHandler OnCastFirstUpdate;

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
            FirstAbilityCast();
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

             if (m_movementSide != 0) // Flip only if there is movement
                 
              FlipCharacter(m_movementSide);
                
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
        private void FirstAbilityCast(){
           if(UnityEngine.Input.GetKeyDown(KeyCode.F)){
                OnCastFirstUpdate?.Invoke(true);
           }else{
                OnCastFirstUpdate?.Invoke(false);
           }
        }
        

        private float GetAxis(String AxisName)
        {
            return UnityEngine.Input.GetAxis(AxisName);
        }

        private bool GetButtonDown(String ButtonName)
        {
            return UnityEngine.Input.GetButtonDown(ButtonName);
        }
        
        private void FlipCharacter(int movementSide)
                {
    Vector3 characterScale = Player.transform.localScale;

    // Flip character if moving left or right
    if (movementSide == -1 && characterScale.x > 0)
    {
        // Flip to face left
        characterScale.x = -Mathf.Abs(characterScale.x);
    }
    else if (movementSide == 1 && characterScale.x < 0)
    {
        // Flip to face right
        characterScale.x = Mathf.Abs(characterScale.x);
    }

    // Apply the new scale
    Player.transform.localScale = characterScale;
}

    }
}
