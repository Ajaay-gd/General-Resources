using UnityEngine;

public class PlayerCheckSystem : MonoBehaviour
{
    [Header("Ground")]
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckRadius;
    


    public bool IsGrounded(){

        return 
        Physics2D.OverlapCircle(groundCheckPoint.position,groundCheckRadius,groundLayer);
        
    }


    void OnDrawGizmosSelected(){
        Gizmos.color = IsGrounded() ? Color.green : Color.red ;
        Gizmos.DrawWireSphere(groundCheckPoint.position,groundCheckRadius);
    }
    
}


// if(isGrounded)
