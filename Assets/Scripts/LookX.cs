using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]private float _sensitivity = 5.0f;

    void Start()
    {
        
    }

    private void Update()
    {
        CalculateMouseX();
    }

    private void CalculateMouseX()
    {
        float _mouseX = Input.GetAxis("Mouse X");

        Vector3 _newRotation = transform.localEulerAngles;

        _newRotation.y += _mouseX * _sensitivity;
        transform.localEulerAngles = _newRotation;
        
        //this.gameObject.transform.rotation.y = _mouseX;    need to use EulerAngles

        /*float xAngle = transform.localEulerAngles.x;
        float yAngle = transform.eulerAngles.y + (_mouseX * _sensitivity);
        float zAngle = transform.eulerAngles.z;

        transform.localEulerAngles = new Vector3(xAngle, yAngle, zAngle);*/
    }
}