using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float range;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public LayerMask layerMask = 1;

    private float timer;

    void Update()
    {
        //RaycastHit2D playerInfo = Physics2D.Raycast(firePoint.position, firePoint.right, range, layerMask);
        timer += Time.deltaTime;
        /*if(playerInfo.collider != null)
        {
            Shoot();
        }*/

        if(timer>1)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }


}
