using System.Collections;
using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerStatsComponent))]
    public abstract class BasePlayerController : MonoBehaviour
    {
        protected RunnerControls _controls;
        protected Rigidbody _rb;
        private float _jumpForce;
        private float _speed;
        protected float _sideSpeed;

        protected virtual void Start()
        {
            _sideSpeed = GetComponent<PlayerStatsComponent>().SideSpeed;
            _speed = GetComponent<PlayerStatsComponent>().ForwardSpeed;
            _jumpForce = GetComponent<PlayerStatsComponent>().JumpForce;
            _rb = GetComponent<Rigidbody>();
            StartCoroutine(MoveForward());
        }

        protected void Jump()
        {
            _rb.AddForce(transform.up * _jumpForce , ForceMode.Impulse);
        }

        private IEnumerator MoveForward()
        {
            while(true)
            {
                transform.position += transform.forward * (_speed * Time.deltaTime);
                yield return null;
			}
		}
    }
}
