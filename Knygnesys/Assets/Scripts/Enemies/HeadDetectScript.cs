using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetectScript : MonoBehaviour
{
    GameObject Enemy;
    public static int movespeed = 1;
    public Vector3 userDirection = Vector3.right;
    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Collider2D>().enabled = false;
        Enemy.GetComponent<SpriteRenderer>().enabled = false;
        Enemy.GetComponent<BoxCollider2D>().enabled = false;
        /*Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
        Enemy.transform.position = Enemy.transform.position + movement * Time.deltaTime;
        //transform.Translate(userDirection * movespeed * Time.deltaTime);*/
        //transform.Translate(Vector2.down * Time.deltaTime);

        Enemy.transform.position = new Vector3(0f, -70f, 0f);
        //Destroy(this.gameObject);
        

    }
}
