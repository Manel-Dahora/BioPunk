using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        //public AnimationCurve SpeedGraph;
        public float Speed;
        public float BlockDistance;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (control.Jump) animator.SetBool(TransitionParameter.isJumping.ToString(), true);

            if (control.MoveRight && control.MoveLeft) animator.SetBool(TransitionParameter.isRunning.ToString(), false);
            if (!control.MoveRight && !control.MoveLeft) animator.SetBool(TransitionParameter.isRunning.ToString(), false);
            if (control.MoveRight)
            {
                control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                if (!CheckFront(control)) control.GetComponent<Rigidbody>().velocity = new Vector3(Speed, control.GetComponent<Rigidbody>().velocity.y, 0f);
            }
            if (control.MoveLeft)
            {
                control.transform.rotation = Quaternion.Euler(0f,180f,0f);
                if (!CheckFront(control)) control.GetComponent<Rigidbody>().velocity = new Vector3(-Speed, control.GetComponent<Rigidbody>().velocity.y, 0f);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool CheckFront(CharacterControl control)
        {
            if (Physics.Raycast(control.transform.position, Vector3.right, BlockDistance) && control.MoveRight) return true;
            if (Physics.Raycast(control.transform.position, Vector3.left, BlockDistance) && control.MoveLeft) return true;
            return false;
        }
    }
}
