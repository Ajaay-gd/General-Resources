using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{   
    [SerializeField] Transform attackPoint;

    InputHandler inputHandler;
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();   
    }

    void Update()
    {
        if(inputHandler.attackInput){
            
        }
    }
}
