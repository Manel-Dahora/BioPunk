using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/SlideWall")]
    public class SlideWall : StateData
    {
        public float WallSlidingSpeed;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.isJumping.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            if (control.MoveRight || control.MoveLeft)
            {
                control.GetComponent<Rigidbody>().velocity = new Vector3(control.GetComponent<Rigidbody>().velocity.x, WallSlidingSpeed, 0);
                if (control.Jump) animator.SetBool(TransitionParameter.isJumping.ToString(), true);
            }
            else control.GetComponent<Rigidbody>().velocity = new Vector3(control.GetComponent<Rigidbody>().velocity.x, control.GetComponent<Rigidbody>().velocity.y, 0);

            Debug.Log(control.GetComponent<Rigidbody>().velocity);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
