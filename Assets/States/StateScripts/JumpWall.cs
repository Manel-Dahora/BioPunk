using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/JumpWall")]
    public class JumpWall : StateData
    {
        public float JumpForceUp;
        public float JumpForceSide;
        public float WallJumpTime;
        //public AnimationCurve Gravity;
        //public AnimationCurve Pull;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            characterState.GetCharacterControl(animator).GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForceUp);
            //if (control.MoveRight) characterState.GetCharacterControl(animator).rigidbody.AddForce(Vector3.left * JumpForceSide);
            //else characterState.GetCharacterControl(animator).rigidbody.AddForce(Vector3.right * JumpForceSide);
            animator.SetBool(TransitionParameter.isGrounded.ToString(), false);
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            //CharacterControl control = characterState.GetCharacterControl(animator);
            //control.GravityMultiplier = Gravity.Evaluate(stateInfo.normalizedTime);
            //control.PullMultiplier = Pull.Evaluate(stateInfo.normalizedTime);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}