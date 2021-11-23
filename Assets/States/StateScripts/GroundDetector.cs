using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/GroundDetector")]
    public class GroundDetector : StateData
    {
        [Range(0.01f, 1f)] public float CheckTime;
        public float Distance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            if (stateInfo.normalizedTime >= CheckTime)
            {
                if (IsGrounded(control)) animator.SetBool(TransitionParameter.isGrounded.ToString(), true);
                else animator.SetBool(TransitionParameter.isGrounded.ToString(), false);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool IsGrounded(CharacterControl control)
        {
            if (control.Rigidbody.velocity.y > -0.001f && control.Rigidbody.velocity.y <= 0f) return true;
            if (control.Rigidbody.velocity.y < 0f)
            {
                // Implementar RayCastHit
            }
            return false;
        }
    }
}