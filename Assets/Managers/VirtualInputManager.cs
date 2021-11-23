using UnityEngine;

namespace BioPunk
{
    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public bool Fire;
        public bool Crouch;
    }
}
