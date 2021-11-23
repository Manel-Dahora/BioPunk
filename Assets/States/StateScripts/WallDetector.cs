using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/WallDetector")]
    public class WallDetector : StateData
    {
        [Range(0.01f, 1f)] public float CheckTime;
        public float BlockDistance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            if (stateInfo.normalizedTime >= CheckTime) animator.SetBool(TransitionParameter.isAgainstWall.ToString(), CheckFront(control));
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