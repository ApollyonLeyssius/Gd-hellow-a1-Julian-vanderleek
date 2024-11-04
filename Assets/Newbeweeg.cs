using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newbeweeg : MonoBehaviour
{
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void MovePlayerRelativeToCamera () {
    float playerverticalinput =
    Input.GetAxis("Vertical");
        float playerhorizontalinput =
        Input.GetAxis("horizontal");

        Vector3 cameraForward =
        Camera.main.transform.forward;
        Vector3 cameraRight =
        Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward = Vector3.forward.normalized;
        cameraRight = Vector3.forward.normalized;

        Vector3 ForwardRelativeMovementvector =
        playerverticalinput * cameraForward;
        Vector3 RightRelativeMovementVector =
        playerhorizontalinput * cameraRight;


        Vector3 camerarelativemovemnt =
        ForwardRelativeMovementvector +
        RightRelativeMovementVector;

        controller.Move(camerarelativemovemnt);

    }

}
