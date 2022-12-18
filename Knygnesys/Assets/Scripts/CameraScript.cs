using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;

    public Transform bg1;

    public Transform bg2;

    public Transform siena;

    private float size;

    public SpriteRenderer outline;

    void Start()
    {
        size = siena.GetComponent<BoxCollider2D>().size.y; //kintamojo dydis backgroundo box colliderio dydzio

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = outline.bounds.size.x / outline.bounds.size.y;

        if(screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = outline.bounds.size.y / 2;
        }
        
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = outline.bounds.size.y / 2 * differenceInSize;
        }
    }

    void Update()
    {
        //camera
        Vector3 targetPos = new Vector3 (0, target.position.y, transform.position.z); // kamera perkeliama i tokia pacia pozicija kaip ir veikejas
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);

        //background
        if(target.position.y >= bg2.position.y+1) //jei veikejas pakyla i toki auksti kad nebesimato buvusio backgroundo
        {
            bg1.position = new Vector3(bg1.position.x, bg2.position.y+39, bg1.position.z); //backgroundas perkeliamas virs dabartinio backgroundo
            SwitchBg();
        }

        if(transform.position.y < bg1.position.y-1) //tas pats, tik i apacia
        {
            bg2.position = new Vector3(bg2.position.x, bg1.position.y - 39, bg2.position.z);
            SwitchBg();
        }
    }

    private void SwitchBg() //apkeicia backgroundu kintamuju pavadinimus (nezinau kam)
    {
        Transform temp = bg1;
        bg1=bg2;
        bg2=temp;
    }
}