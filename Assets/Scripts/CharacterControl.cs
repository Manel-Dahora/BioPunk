using Boo.Lang;
using UnityEngine;

namespace BioPunk
{
    public enum TransitionParameter
    {
        isRunning,
        isJumping,
        ForceTransition,
        isGrounded,
    }
    public class CharacterControl : MonoBehaviour
    {
        public Animator Animator;
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public GameObject ColliderEdgePrefab;
        public List<GameObject> _bottomSpheres = new List<GameObject>();
        public List<GameObject> _frontSpheres = new List<GameObject>();

        public float GravityMultiplier;
        public float PullMultiplier;

        private Rigidbody rigidbody;
        public Rigidbody Rigidbody
        {
            get
            {
                if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
                return rigidbody;
            }
        }

        private void Awake()
        {
            BoxCollider box = GetComponent<BoxCollider>();
            float bottom = box.bounds.center.y - box.bounds.extents.y;
            float top = box.bounds.center.y + box.bounds.extents.y;
            float front = box.bounds.center.x + box.bounds.extents.x;
            float back = box.bounds.center.x - box.bounds.extents.x;

            GameObject bottomFront = CreateEdgeSphere(new Vector3(front, bottom, 0f));
            GameObject bottomBack = CreateEdgeSphere(new Vector3(back, bottom, 0f));
            GameObject topFront = CreateEdgeSphere(new Vector3(front, top, 0f));

            bottomFront.transform.parent = this.transform;
            bottomBack.transform.parent = this.transform;
            topFront.transform.parent = this.transform;

            _bottomSpheres.Add(bottomFront);
            _bottomSpheres.Add(bottomBack);

            _frontSpheres.Add(topFront);
            _frontSpheres.Add(bottomFront);

            float horSec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;
            CreateMiddleSpheres(bottomBack, this.transform.right, horSec, 4, _bottomSpheres);

            float verSec = (topFront.transform.position - bottomFront.transform.position).magnitude / 10f;
            CreateMiddleSpheres(bottomFront, this.transform.up, verSec, 9, _frontSpheres);
        }

        private void FixedUpdate()
        {
            if (Rigidbody.velocity.y < 0f) Rigidbody.velocity += Vector3.down * GravityMultiplier;
            if (Rigidbody.velocity.y > 0f && !Jump) Rigidbody.velocity += Vector3.down * PullMultiplier;
        }

        public void CreateMiddleSpheres(GameObject start, Vector3 direction, float sec, int interations, List<GameObject> spheresList)
        {
            for (int i = 0; i < interations; i++)
            {
                Vector3 pos = start.transform.position + (direction * sec * (i + 1));
                GameObject newObj = CreateEdgeSphere(pos);
                newObj.transform.parent = this.transform;
                spheresList.Add(newObj);
            }
        }
        public GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
            return obj;
        }
    }
}
