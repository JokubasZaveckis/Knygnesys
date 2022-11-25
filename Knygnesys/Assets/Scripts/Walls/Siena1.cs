using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siena1 : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {

        /*Vector3 targetPos = new Vector3 (0, target.position.y, transform.position.z); //kamera perkeliama i tokia pacia pozicija kaip ir veikejas
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);*/
        //transform.Translate(Vector2.up * Time.deltaTime);

        transform.position = new Vector3(-12, target.position.y, transform.position.z);
    }
}
