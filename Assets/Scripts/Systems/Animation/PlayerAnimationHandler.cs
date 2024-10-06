using UnityEngine;
using LSEKombat.Systems.Input;

namespace LSEKombat.Systems.Animation
{
    [RequireComponent(typeof(InputHandler))]
    public class PlayerAnimationHandler : MonoBehaviour
    {
        /*
                This class handles animation triggering behaviour (by interfacing between the rest of the player and an animation controller)


           
        */

        //script references
        private InputHandler m_inputHandler;
        [SerializeField] private SpriteRenderer SpriteRenderer;


        //  !Atention:the Animator doesn't sit on the same object as this script!
        [SerializeField] private Animator       Animator;

        //animation variables
        //Use events to get other variables
        private int m_movementSide = 0;

        // Start is called before the first frame update
        private void Start()
        {
            m_inputHandler = GetComponent<InputHandler>();
            m_inputHandler.OnMovementInputUpdate += GetADMovement;
        }

        // Update is called once per frame
        private void Update()
        {
            HandlePlayerRotationFromMovement();
            //TODO:Add animation triggering logic here
        }

        private void GetADMovement(int MovementSide)
        {
            // -1 -> Player moves Left ; 1 -> Player moves Right
            //this method gets the movementSide variable

            m_movementSide = MovementSide;
        }

        private void HandlePlayerRotationFromMovement()
        {
            switch(m_movementSide)
            {
                case 1  :   SpriteRenderer.flipX = false;
                            break;
                case -1:    SpriteRenderer.flipX = true;
                            break;
            }
        }

        private void OnDestroy() 
        {
            m_inputHandler.OnMovementInputUpdate -= GetADMovement;
        }
    }
}
