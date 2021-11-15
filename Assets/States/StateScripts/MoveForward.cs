using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public AnimationCurve SpeedGraph;
        public float Speed;
        public float BlockDistance;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (control.Jump) animator.SetBool(TransitionParameter.isJumping.ToString(), true);

            if (control.MoveRight && control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.isRunning.ToString(), false);
                return;
            }
            if (!control.MoveRight && !control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.isRunning.ToString(), false);
                return;
            }
            if (control.MoveRight)
            {
                control.transform.rotation = Quaternion.Euler(0f,0f,0f);

                if (!CheckFront(control))
                {
                    control.transform.Translate(Vector3.right * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
            }
            if (control.MoveLeft)
            {
                control.transform.rotation = Quaternion.Euler(0f,180f,0f);

                if (!CheckFront(control))
                {
                    control.transform.Translate(Vector3.right * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool CheckFront(CharacterControl control)
        {
            foreach (var o in control._frontSpheres)
            {
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, Vector3.right, out hit, BlockDistance)) return true;
            }
            return false;
        }

    }
}
