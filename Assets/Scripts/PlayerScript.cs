using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CharacterController _cController;
    [SerializeField]
    private float _speed = 3.5f;

    private float _gravity = 9.81f;

    void Start()
    {
        _cController = GetComponent<CharacterController>();
    }


    void Update()
    {
        ProcessMovement();
    }//update

    private void ProcessMovement()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");
        float _verticalInput = Input.GetAxis("Vertical");

        Vector3 _direction = new Vector3(_horizontalInput, 0f, _verticalInput);
        Vector3 _velocity = _direction * _speed;

        //Apply gravity
        _velocity.y -= _gravity;

        _cController.Move(_velocity * Time.deltaTime);
    }//processMovement

}//class
