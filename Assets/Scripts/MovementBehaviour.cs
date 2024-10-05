using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;        
    [SerializeField] public float rotationSpeed = 25f;    

    void MoveAndRotate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        Move(transform, moveSpeed, moveInput);  
        transform.Rotate(transform.up * rotationSpeed * rotateInput * Time.deltaTime);
    }

    public void Move(Transform transform, float moveSpeed, float input)
    {
        transform.position = transform.position + transform.forward * moveSpeed * input * Time.deltaTime;
    }

    void Update()
    {
        MoveAndRotate();
    }
}
