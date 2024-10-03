using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;        
    [SerializeField] public float rotationSpeed = 25f;   
    [SerializeField] private bool isAutomated = false;   

    void MoveAndRotate()
    {
        
        if (!isAutomated)
        {
            float moveInput = Input.GetAxis("Vertical");
            float rotateInput = Input.GetAxis("Horizontal");
            
            transform.position += transform.forward * moveSpeed * moveInput * Time.deltaTime;
            transform.Rotate(transform.up * rotationSpeed * rotateInput * Time.deltaTime);
        }
        else
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    void Update()
    {
        MoveAndRotate();
    }
}
