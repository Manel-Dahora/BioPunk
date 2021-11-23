using UnityEngine;

namespace BioPunk
{
    public class EnemyAI : MonoBehaviour
    {
        private CharacterControl _characterControl;
        public Transform playerTransform;
        public float distanceToPursue;
        public float distanceToAttack;

        private void Awake()
        {
            _characterControl = this.gameObject.GetComponent<CharacterControl>();
        }

        private void Update()
        {
            if (Vector3.Distance(playerTransform.position, transform.position) <= distanceToPursue)
            {
                if (Vector3.Distance(playerTransform.position, transform.position) <= distanceToAttack)
                {
                    _characterControl.MoveRight = false;
                    _characterControl.MoveLeft = false;
                    _characterControl.Fire = true;
                }
                else
                {
                    _characterControl.Fire = false;
                    if (playerTransform.position.x < transform.position.x)
                    {
                        _characterControl.MoveRight = false;
                        _characterControl.MoveLeft = true;
                    }
                    else
                    {
                        _characterControl.MoveRight = true;
                        _characterControl.MoveLeft = false;
                    }
                }
            }
            else
            {
                _characterControl.MoveRight = false;
                _characterControl.MoveLeft = false;
            }
        }
    }
}