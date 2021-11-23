using System.Collections;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject fireProjectile;
    public Transform _firePosition;
    public float fireBallSpeed;
    private Animator animator;
    public Rigidbody player;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) StartCoroutine("Tiro");
    }

    private IEnumerator Tiro()
    {
        animator.SetBool("WeaponFire", true);
        yield return new WaitForSeconds(.2f);
        if (player.velocity.x >= 0)
        {
            GameObject fireBall = Instantiate(fireProjectile, _firePosition);
            fireBall.GetComponent<Rigidbody>().velocity = Vector3.right * 15f;
        }

        if (player.velocity.x < 0)
        {
            GameObject fireBall = Instantiate(fireProjectile, _firePosition);
            fireBall.GetComponent<Rigidbody>().velocity = Vector3.left * 15f;
        }
        yield return new WaitForSeconds(.2f);
        animator.SetBool("WeaponFire", false);
    }
}
