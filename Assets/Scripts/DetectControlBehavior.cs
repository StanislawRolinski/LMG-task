using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectControlBehavior : MonoBehaviour
{
    [SerializeField] GunController gunController;

    void Update()
    {
        //Detect Mouse Input
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            gunController.UseController = false;
        }
        if(Input.GetAxisRaw("Mouse X") !=0.0f || Input.GetAxisRaw("Mouse Y") != 0.0f)
        {
            gunController.UseController = false;
        }

        //Detect Controller Input
        if(Input.GetAxisRaw("RHorizontal") != 0.0f || Input.GetAxisRaw("RVertical") != 0.0f)
        {
            gunController.UseController = true;
        }
        if (Input.GetKey(KeyCode.JoystickButton0) ||
            Input.GetKey(KeyCode.JoystickButton1) ||
            Input.GetKey(KeyCode.JoystickButton2) ||
            Input.GetKey(KeyCode.JoystickButton3) ||
            Input.GetKey(KeyCode.JoystickButton4) ||
            Input.GetKey(KeyCode.JoystickButton5) ||
            Input.GetKey(KeyCode.JoystickButton6) ||
            Input.GetKey(KeyCode.JoystickButton7) ||
            Input.GetKey(KeyCode.JoystickButton8) ||
            Input.GetKey(KeyCode.JoystickButton9)
            )
        {
            gunController.UseController = true;
        }
    }
}
