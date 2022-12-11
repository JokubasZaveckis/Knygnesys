using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour
{
    public float range;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public LayerMask layerMask = 1;
    public Animator animator;
    float period=0.0f;
    public int shootingDelay = 4;
    
    //sound start
    [SerializeField] private AudioSource gunshotSoundEffect;
    //sound end

    private float timer;

    void Update()
    {
        //RaycastHit2D playerInfo = Physics2D.Raycast(firePoint.position, firePoint.right, range, layerMask);

        // timer += Time.deltaTime;

        /*if(playerInfo.collider != null)
        {
            Shoot();
        }*/

        // if(timer>1)
        // {
        //     timer = 0;
        //     Shoot();
        // }

        if (period>shootingDelay)
        {
            Shoot();
            period = 0;

            //sound start
            gunshotSoundEffect.Play();
            //sound end
        }
        period += UnityEngine.Time.deltaTime;
    }
    
    void Shoot()
    {
        animator.SetBool("isShooting", true);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animator.SetBool("isShooting", false);
    }

   

}
