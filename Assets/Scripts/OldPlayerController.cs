using UnityEngine;

namespace Runner
{
    public class OldPlayerController : BasePlayerController
    {
        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Jump();

            var direction = Input.GetAxis("Horizontal") * _sideSpeed * Time.fixedDeltaTime;

            if (direction == 0f) return;
            _rb.velocity += direction * transform.right;
        }
	}
}
