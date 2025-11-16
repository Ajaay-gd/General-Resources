using UnityEngine;

public class PlayerMovementSystem : MonoBehaviour
{
    //Declaration of components we need
    [SerializeField] float speed = 5f; // use SerializeField to allow variables to be private and still editable in the inspector
    [SerializeField] float jumpForce = 20f;
    InputHandler inputHandler;
    Rigidbody2D rb;
    PlayerCheckSystem checkSystem;

    // Assignment of components needed for movement input (the one we made) and physics (Rigidbody2D)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        checkSystem = GetComponent<PlayerCheckSystem>();
        /*GetComponent is self explanatory it checks all the components on the gameObject this script is attached to 
         and assigns it the variable if its there, if no component it found is assigns null(empty)
         (which i promise you will haunt you a few times 😭)
         */
        rb = GetComponent<Rigidbody2D>();
    }

    /* Update is called once per frame usually 
     Update update update. very easy to understand, this is called ussually around 60 - 120fps (or more or less)
     that means its called around every 0.1667🫴🫴 to 0.01 seconds (alot), and is where you will call all your continous logic
     try and put a Debug.Log("Hi") line to see how many messages get sent.
    */
    void Update()
    {
        rb.linearVelocity = new Vector2(inputHandler.movementInput * speed, rb.linearVelocity.y);
        //Vector2 are variables that hold 2 floats (simple) like this (x,y). perfect for position, direction logic and both
        //in this case we are simply using the player input and assigning it to only the x axis and keeping the y axis the same (rb.linearVelocity.y)
        // making sure we only move left and right like all platformers(jump logic can come later)
        //then we multiply by speed 

        // idealy you would want to use FixedUpdate for physics related logic
        // but for simplicity we are using Update here
        // you would also multiply by Time.deltaTime to make movement frame rate independent
        // but for simplicity we are not doing that here. we would work on that on a later date

        if(inputHandler.jumpInput && checkSystem.IsGrounded())
        {
            // Simple jump logic
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            // Add an upward force to the Rigidbody2D (excluding x axis this time)
            // Use ForceMode2D.Impulse to apply an instant force like a jump or shooting a bullet
            inputHandler.UseJump(); // Reset jump input after using it
            
            //Right now you can jump infinitely even if you are not on the ground, we will add ground check logic later to fix that
        }
        
    }
}
