using UnityEngine;

namespace BioPunk
{
    [CreateAssetMenu(fileName = "New State", menuName = "BioPunk/AbilityData/WeaponFire")]
    public class WeaponFire : StateData
    {
        public GameObject fireProjectile;
        public Transform _firePosition;
        public float fireBallSpeed;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            animator.SetBool(TransitionParameter.WeaponFire.ToString(), false);
            //GameObject fireBall = Instantiate(fireProjectile, _firePosition);
            //fireBall.GetComponent<Rigidbody>().velocity = Vector3.right * fireBallSpeed;
            /*
            if (control.Fire)
            {
                GameObject fireBall = Instantiate(fireProjectile, _firePosition);
                fireBall.GetComponent<Rigidbody>().velocity = Vector3.right * fireBallSpeed;
                //animator.SetBool(TransitionParameter.WeaponFire.ToString(), false);
            }
            */
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}