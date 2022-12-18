using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour
{
    public float range;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    float period=0.0f;
    public int shootingDelay = 4;
    
    //sound start
    [SerializeField] private AudioSource gunshotSoundEffect;
    public float minDist=1;
    public float maxDist=10;
    //sound end

    private float timer;

    void Update()
    {
        if (period>shootingDelay)
        {
            Shoot();
            period = 0;

            //sound start
            gunshotSoundEffect.Play();
            //sound end
        }
        period += UnityEngine.Time.deltaTime;


        // float dist = Vector2.Distance(transform.position, reikiaPlayerioPozicijosarbaCamera.position);
 
        // if(dist < minDist)
        // {
        //     gunshotSoundEffect.volume = 1;
        // }
        // else if(dist > maxDist)
        // {
        //     gunshotSoundEffect.volume = 0;
        // }
        // else
        // {
        //     gunshotSoundEffect.volume = 1 - ((dist - minDist) / (maxDist - minDist));
        // }
    }
    
    void Shoot()
    {
        animator.SetBool("isShooting", true);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animator.SetBool("isShooting", false);
    }

}
