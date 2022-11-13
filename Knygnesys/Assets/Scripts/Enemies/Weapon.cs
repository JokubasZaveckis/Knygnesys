using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float range;
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Update()
    {
        RaycastHit2D playerInfo = Physics2D.Raycast(firePoint.position, firePoint.right, range);
        if(playerInfo == true)//(playerInfo.collider.gameObject.CompareTag("Player") == true)
        //problema kaip detectint kad pamato playeri
        //reiktu dar padaryt cooldown tarp suviu
        //cia pas mane kiek sudinokai
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
