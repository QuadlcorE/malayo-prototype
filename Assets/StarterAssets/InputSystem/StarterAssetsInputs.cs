using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool rotateLeft;
		public bool rotateLeftFast;
		public bool rotateRight;
		public bool rotateRightFast;
		public bool flip;
		public bool pause;
		public bool boost;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnFlip(InputValue value) 
		{
			FlipInput(value.isPressed);
		}

		public void OnPause(InputValue value) 
		{
			PauseInput(value.isPressed);
		}

		public void OnBoost(InputValue value)
        {
			BoostInput(value.isPressed);
        }

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnRotateLeft(InputValue value) 
		{
			RotateLeftInput(value.isPressed);
		}
		
		public void OnRotateLeftFast(InputValue value) 
		{
			RotateLeftFastInput(value.isPressed);
		}

		public void OnRotateRight(InputValue value) 
		{
			RotateRightInput(value.isPressed);
		}

		public void OnRotateRightFast(InputValue value) 
		{
			RotateRightFastInput(value.isPressed);
		}
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void FlipInput(bool newFlipState)
		{
			flip = newFlipState;
		}

		public void PauseInput(bool newPauseState)
		{
			pause = newPauseState;
		}

		public void BoostInput(bool newBoostState)
        {
			boost = newBoostState;
        }

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void RotateLeftInput(bool newRotateLeftState) 
		{
			rotateLeft = newRotateLeftState;
		}

        public void RotateLeftFastInput(bool newRotateLeftFastState)
        {
            rotateLeftFast = newRotateLeftFastState;
        }

        public void RotateRightInput(bool newRotateRightState)
		{
			rotateRight = newRotateRightState;
		}

        public void RotateRightFastInput(bool newRotateRightFastState)
        {
            rotateRightFast = newRotateRightFastState;
        }

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}