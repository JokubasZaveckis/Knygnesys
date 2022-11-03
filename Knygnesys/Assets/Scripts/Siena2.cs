using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siena2 : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(12, target.position.y, transform.position.z);
    }
}