using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/Landing")]
    public class Landing : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.isJumping.ToString(), false);
            animator.SetBool(TransitionParameter.isRunning.ToString(), false);
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
