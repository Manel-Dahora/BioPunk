using UnityEngine;
using System.Collections.Generic;

namespace BioPunk
{
    public class CharacterState : StateMachineBehaviour
    {
        public List<StateData> ListAbilityData = new List<StateData>();

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var d in ListAbilityData)
            {
                d.OnEnter(this, animator, stateInfo);
            }
        }

        public void UpdateAll(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach (StateData d in ListAbilityData)
            {
                d.UpdateAbility(characterState, animator, stateInfo);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(this, animator, stateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var d in ListAbilityData)
            {
                d.OnExit(this, animator, stateInfo);
            }
        }

        private CharacterControl _characterControl;
        public CharacterControl GetCharacterControl(Animator animator)
        {
            if (_characterControl == null) _characterControl = animator.GetComponentInParent<CharacterControl>();
            return _characterControl;
        }
    }
}
