using UnityEngine;

namespace LSEKombat.Systems.Movement
{
    [RequireComponent(typeof(Input.InputHandler))]
    [RequireComponent(typeof(GroundChecker))]
    public class PlayerCrouch : MonoBehaviour
    {
        /*
            This class handles crouching behaviour for the player
        */

        [Header("SETTINGS")]
        [SerializeField] private Vector2 PlayerColliderOnCrouch;

        [Header("REFERENCES")]
        [SerializeField]private BoxCollider2D PlayerCollider;

        //debug

        private bool m_isGrounded;
        private bool m_wantsToCrouch;
        private Vector2 PlayerColliderOffCrouch;


        //event delegates
        public delegate void PlayerCrouchStateHandler       (bool IsCrouching);                  //true -> Player is crouched ; false -> player isn't crouched

        //events
        public event PlayerCrouchStateHandler               OnCrouchStateUpdate;

        // Start is called before the first frame update
        private void Start()
        {
            GetComponent<GroundChecker>().OnGroundCheckUpdate += SetGroundedState;
            GetComponent<Input.InputHandler>().OnCrouchInputUpdate += GetCrouchInput;


            PlayerColliderOffCrouch = PlayerCollider.size;
        }

        private void GetCrouchInput(bool Crouch)
        {
            m_wantsToCrouch = Crouch;
        }

        private void SetGroundedState(bool IsGrounded)
        {
            m_isGrounded = IsGrounded;
        }

        // Update is called once per frame
        private void Update()
        {
            HandleCrouchStates();
        }

        private void HandleCrouchStates()
        {
            if (m_wantsToCrouch && m_isGrounded)
            {
                //crouch
                OnCrouchStateUpdate?.Invoke(true);

                PlayerCollider.size = PlayerColliderOnCrouch;
            }
            else
            {
                //"uncrouch"
                OnCrouchStateUpdate?.Invoke(false);

                PlayerCollider.size = PlayerColliderOffCrouch;
            }
        }

        private void OnDisable()
        {
            GetComponent<GroundChecker>().OnGroundCheckUpdate -= SetGroundedState;
            GetComponent<Input.InputHandler>().OnCrouchInputUpdate -= GetCrouchInput;
        }
    }
}
