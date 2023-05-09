using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    //[SerializeField] public Define.CameraMode _mode = Define.CameraMode.QuaterView;
    //[SerializeField] public Vector3 _delta;
    //[SerializeField] public GameObject Santa;

    public Transform objectFollow;
    public float followSpeed = 10f;
    public float sensitivity = 300f;
    public float clamAngle = 70f;

    private float rotX;
    private float rotY;

    public Transform realCamera;
    public Vector3 dirNomalized;
    public Vector3 finalDir;
    public float minDistance;
    public float maxDistance;
    public float finalDistance;
    public float smoothness = 10f;

    void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNomalized = realCamera.localPosition.normalized;
        finalDistance = realCamera.localPosition.magnitude;
    }

    void Update()
    {
        rotX += -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;
        rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clamAngle, clamAngle);
        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
        transform.rotation = rot;
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectFollow.position, followSpeed * Time.deltaTime);

        finalDir = transform.TransformPoint(dirNomalized * maxDistance);

        RaycastHit hit;

        if (Physics.Linecast(transform.position, finalDir, out hit))
        {
            finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
            finalDistance = maxDistance;

        realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNomalized * finalDistance, Time.deltaTime * smoothness);
        
        
        /*
        if (_mode == Define.CameraMode.QuaterView)
        {
            transform.position = Santa.transform.position + _delta;
            transform.LookAt(Santa.transform);
        }
        */
    }

}
