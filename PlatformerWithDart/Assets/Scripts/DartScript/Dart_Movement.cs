using UnityEngine;
using UnityEngine.InputSystem;

public class Dart_Movement : MonoBehaviour
{

    private Rigidbody2D rbdart;
    
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpSpeed = 10f;

    float horizontalMovement;

    public InputAction playerControls;

    private Vector2 moveInput;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbdart = GetComponent<Rigidbody2D>();
        OnEnable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = playerControls.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rbdart.linearVelocity = new Vector2(horizontalMovement * runSpeed, rbdart.linearVelocity.y);
        //rbdart.MovePosition(rbdart.position + movement)
        //rbdart.linearVelocity = new Vector2(moveInput.x * runSpeed, moveInput.y * jumpSpeed);
    }

    private void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    //void OnMove(InputValue value)
    //{
    //    moveInput = value.Get<Vector2>();
    //}
    //void Run()
    //{
    //    Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rbdart.linearVelocity.y);
    //    rbdart.linearVelocity = playerVelocity;
    //}


}
