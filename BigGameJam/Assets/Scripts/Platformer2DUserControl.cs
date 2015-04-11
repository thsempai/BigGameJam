using System;
using UnityEngine;
using InControl;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Punch;

        PlayerCharacterActions characterActions;

        void Start() {
            characterActions = new PlayerCharacterActions();

            characterActions.Left.AddDefaultBinding( Key.LeftArrow );
            characterActions.Left.AddDefaultBinding( InputControlType.DPadLeft );

            characterActions.Right.AddDefaultBinding( Key.RightArrow );
            characterActions.Right.AddDefaultBinding( InputControlType.DPadRight );

            characterActions.Jump.AddDefaultBinding( Key.Space );
            characterActions.Jump.AddDefaultBinding( InputControlType.Action1 );

            characterActions.Punch.AddDefaultBinding( Key.Control );
            characterActions.Punch.AddDefaultBinding( InputControlType.Action3 );
        }

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = characterActions.Jump.WasPressed;
            }
            if (!m_Punch)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Punch = characterActions.Punch.WasPressed;
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = false;
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Punch, m_Jump);
            m_Punch = false;
            m_Jump = false;
        }
    }
}
