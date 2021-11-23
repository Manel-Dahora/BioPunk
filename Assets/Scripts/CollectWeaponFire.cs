using UnityEngine;

public class CollectWeaponFire : MonoBehaviour
{
    public GameObject fireWeapon;

    public void OnCollisionEnter (Collision collision)
    {
        fireWeapon.SetActive(true);
        Destroy(gameObject);
    }
}
