using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMan1 : MonoBehaviour
{
    Vector3 pos; 

    float delta_X = 2.0f; 
    float delta_Z = 2.0f;

    float speed = 3.0f; 


    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;

        v.x += delta_X * Mathf.Sin(Time.time * speed);
        v.z += delta_Z * Mathf.Cos(Time.time * speed);

        // �¿� �̵��� �ִ�ġ �� ���� ó���� �̷��� ���ٿ� ���ְ� �ϳ׿�.

        transform.position = v;
    }
}
