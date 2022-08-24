using UnityEngine;
using UnityEngine.InputSystem;

namespace Runner
{
    public class NewPlayerController : BasePlayerController
    {
	    private void Update()
		{
			var direction = _controls.Player.Move.ReadValue<float>() * _sideSpeed * Time.deltaTime;

			if (direction == 0f) return;
			transform.position += direction * transform.right;
		}

		#region new input system code

		private void Awake()
		{
			_controls = new RunnerControls();
		}

		private void OnEnable()
		{
			_controls.Player.Enable();
			_controls.Player.Jump.performed += JumpPerformed;
		}

		private void OnDisable()
		{
			_controls.Player.Disable();
			_controls.Player.Jump.performed -= JumpPerformed;
		}

		private void JumpPerformed(InputAction.CallbackContext ctx) => Jump();

		private void OnDestroy()
		{
			_controls.Dispose();
		}

		#endregion
    }
}