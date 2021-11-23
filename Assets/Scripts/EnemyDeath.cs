using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Animator animator;
    private int lives = 1;

    public void OnTriggerEnter(Collider other)
    {
        if (lives > 0)
        {
            if (other.gameObject.tag == "Projectile") StartCoroutine("EnemyDamage");
        }
        else
        {
            animator.SetBool("EnemyDeath", true);
        }
    }

    IEnumerator EnemyDamage()
    {
        animator.SetBool("Damage", true);
        yield return new WaitForSeconds(.2f);
        lives--;
        //yield return new WaitForSeconds(.2f);
        animator.SetBool("Damage", false);
        Debug.Log("acertou");
    }
}
