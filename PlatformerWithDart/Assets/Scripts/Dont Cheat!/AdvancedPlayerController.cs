using UnityEngine;
using UnityEngine.InputSystem;

public class AdvancedPlayerController : MonoBehaviour
{
    

    [SerializeField]
    private float moveSpeed = 15;
    [SerializeField]
    private float jumpSpeed = 5;

    private float horizontalMovement;
    

    private InputSystem_Actions playerControls;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        playerControls = new InputSystem_Actions();
    }
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        

        rb2d.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb2d.linearVelocity.y);

        FlipSprite();
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        Debug.Log("Move Called");
        horizontalMovement = ctx.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("Jump is Pressed");
            rb2d.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            AudioManager.Instance.PlayJumpSound();

        }


    }

    void FlipSprite()
    {

        bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.linearVelocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb2d.linearVelocity.x), 1f);
        }

    }
}
