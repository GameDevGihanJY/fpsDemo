using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CharacterController _cController;
    [SerializeField]
    private float _speed;
    private float _normalSpeed = 3.5f;
    private float _runSpeed = 7.0f;

    private float _gravity = 9.81f;

    public bool hasCoin = false;

    void Start()
    {
        _cController = GetComponent<CharacterController>();

        //Hide cursor when start the game
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.LeftShift)))
        {
            _speed = _runSpeed;
        }
        else
        {
            _speed = _normalSpeed;
        }
        ProcessMovement();
        UnlockCursor();
    }//update

    private static void UnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void ProcessMovement()
    {

        float _horizontalInput = Input.GetAxis("Horizontal");
        float _verticalInput = Input.GetAxis("Vertical");

        Vector3 _direction = new Vector3(_horizontalInput, 0f, _verticalInput);
        Vector3 _velocity = _direction * _speed;

        //Apply gravity
        _velocity.y -= _gravity;

        _velocity = transform.transform.TransformDirection(_velocity);     //Rotate player to main camera view

        _cController.Move(_velocity * Time.deltaTime);
    }//processMovement

}//class
