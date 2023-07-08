using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
        CalculateMouseY();
    }

    private void CalculateMouseY()
    {
        float _mouseY = Input.GetAxis("Mouse Y");

        Vector3 _newRotation = transform.localEulerAngles;
        _newRotation.x += -(_mouseY * _sensitivity);

        transform.localEulerAngles = _newRotation;

        /*float xAxis = transform.localEulerAngles.x + (-_mouseY * _sensitivity);
        float yAxis = transform.localEulerAngles.y;                                 |
        float zAxis = transform.localEulerAngles.z;                                 |       Also correct                                                                        |
        transform.localEulerAngles = new Vector3(xAxis, yAxis, zAxis);              |                       */
    }
}
