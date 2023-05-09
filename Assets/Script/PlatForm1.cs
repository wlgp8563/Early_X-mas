using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatForm1 : MonoBehaviour
{
    public int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpDown();
    }
    void UpDown()
    {
        if (transform.position.y >= 4.5)
        {
            dir = -1;
        }
        else if (transform.position.y <= 1.5)
        {
            dir = 1;
        }

        transform.Translate(Vector3.up * 1.0f * Time.deltaTime * dir);
    }
}
