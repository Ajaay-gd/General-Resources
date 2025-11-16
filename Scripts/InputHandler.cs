using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{   
    /* Public Input Variables Explanation:
    These variables are public so that other systems (like PlayerMovementSystem, PlayerCombatSystem, etc.) can access them.
    They have private setters to prevent other systems from modifying them directly, ensuring that only the InputHandler
    can change their values based on player input. 
    (Encapsulation principle)
    */
    public float movementInput{ get; private set; }
    public float lookInput{ get; private set; }
    public bool jumpInput{ get; private set; }
    public bool attackInput{ get; private set; }
    public bool secondaryAttackInput{ get; private set; }
    public bool dodgeInput{ get; private set; }

    /* Input Action Functions Explanation:
    These functions are called by the Unity Input System Component attached to the player 
    when the corresponding input action is triggered.

    context.performed is called when the action is triggered (e.g., button pressed)
    context.canceled is called when the action is released (e.g., button released)

    Try not to put any heavy logic in these functions, just set variables to be used in the Update loop or other systems
    (Abstraction principle). Input and logic should be separated.

    NOTE: context.canceled is not true when an action has been performed, only when the button is released.
    so if you set a boolean to true in context.performed, it will stay true until the button is released.
    this may be a problem for actions like jump or attack where you want the action to be executed once per button press.
    To handle this, you can use the UseJump, UseAttack, etc. functions to reset the booleans after the action has been executed.
    */
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            movementInput = context.ReadValue<float>();
        }
        else if(context.canceled)
        {
            movementInput = 0;
        }
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            lookInput = context.ReadValue<float>();
        }
        else if(context.canceled)
        {
            lookInput = 0;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            jumpInput = true;
        }
        else if(context.canceled)
        {
            jumpInput = false;
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            attackInput = true;
        }
        else if(context.canceled)
        {
            attackInput = false;
        }
    }
    public void OnSecondaryAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            secondaryAttackInput = true;
        }
        else if(context.canceled)
        {
            secondaryAttackInput = false;
        }
    }
    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            dodgeInput = true;
        }
        else if (context.canceled)
        {
            dodgeInput = false;
        }
    }

    /*
    Use Function Explanation: These are usually used by discountinuous actions like jump or attack
    to reset the input boolean after the action has been executed in another system.
    */
    public void UseJump() => jumpInput = false;
    public void UseAttack() => attackInput = false;
    public void UseSecondaryAttack() => secondaryAttackInput = false;
    public void UseDodge() => dodgeInput = false;
}
