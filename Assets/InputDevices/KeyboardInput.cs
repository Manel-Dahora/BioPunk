using UnityEngine;

namespace BioPunk
{
    public class KeyboardInput : MonoBehaviour
    {
        void Update()
        {
            VirtualInputManager.Instance.MoveRight = Input.GetKey(KeyCode.D);
            VirtualInputManager.Instance.MoveLeft = Input.GetKey(KeyCode.A);
            VirtualInputManager.Instance.Jump = Input.GetKey(KeyCode.Space);
            VirtualInputManager.Instance.Fire = Input.GetMouseButtonDown(0);
        }
    }
}
