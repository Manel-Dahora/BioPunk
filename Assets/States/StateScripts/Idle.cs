using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/Idle")]
    public class Idle : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.isJumping.ToString(), false);
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            if (control.MoveRight) animator.SetBool(TransitionParameter.isRunning.ToString(), true);
            if (control.MoveLeft) animator.SetBool(TransitionParameter.isRunning.ToString(), true);
            if (control.Jump) animator.SetBool(TransitionParameter.isJumping.ToString(), true);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
