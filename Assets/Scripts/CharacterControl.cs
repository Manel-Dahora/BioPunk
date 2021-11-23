using UnityEngine;

namespace BioPunk
{
    public enum TransitionParameter
    {
        isRunning,
        isJumping,
        ForceTransition,
        isGrounded,
        isWallSliding,
        WeaponFire,
        Attack,
        isAgainstWall,
    }

    public class CharacterControl : MonoBehaviour
    {
        public Animator Animator;
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public bool Fire;
        public bool Crouch;

        //public float GravityMultiplier;
        //public float PullMultiplier;

        private Rigidbody rigidbody;

        public Rigidbody Rigidbody
        {
            get
            {
                if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
                return rigidbody;
            }
        }

        //private void FixedUpdate()
        //{
        //    if (Rigidbody.velocity.y < 0f) Rigidbody.velocity += Vector3.down * GravityMultiplier;
        //    if (Rigidbody.velocity.y > 0f && !Jump) Rigidbody.velocity += Vector3.down * PullMultiplier;
        //}
    }
}
