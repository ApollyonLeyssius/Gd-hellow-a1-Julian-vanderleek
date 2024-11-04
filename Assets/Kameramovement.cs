using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kameramovement : MonoBehaviour

{

    public Transform player;
    public float MouseSensitivity = 2f;
    float camerarotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float inputX = Input.GetAxis("Mouse X") * MouseSensitivity;
       float inputY = Input.GetAxis("Mouse Y") * MouseSensitivity;

       camerarotation -= inputY;
        //camerarotation = Mathf.Clamp(camerarotation, 90f, -90f);
        transform.localEulerAngles=Vector3.right * camerarotation;

        player.Rotate(Vector3.up * inputX);
    }
}
