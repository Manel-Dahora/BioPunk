using UnityEngine;

namespace BioPunk
{
    public class ManualInput : MonoBehaviour
    {
        private CharacterControl _characterControl;

        private void Awake()
        {
            _characterControl = this.gameObject.GetComponent<CharacterControl>();
        }

        private void Update()
        {
            _characterControl.MoveRight = VirtualInputManager.Instance.MoveRight;
            _characterControl.MoveLeft = VirtualInputManager.Instance.MoveLeft;
            _characterControl.Jump = VirtualInputManager.Instance.Jump;
            _characterControl.Crouch = VirtualInputManager.Instance.Crouch;
            _characterControl.Fire = VirtualInputManager.Instance.Fire;
        }
    }
}
