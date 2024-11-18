using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputDirection;
    public float speed;
    
    private PlayerInputControl inputControl;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        inputControl = new PlayerInputControl();

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        inputDirection =inputControl.Gameplay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
         rb.velocity = new Vector2(inputDirection.x * speed, rb.velocity.y);
        
         int faceDir = (int)transform.localScale.x;
        
         if(inputDirection.x > 0)
            faceDir = 1;
         if(inputDirection.x < 0)
            faceDir = -1;
         
         // 人物翻转
         Vector3 newScale = transform.localScale;
         if (inputDirection.x > 0)
         {
             newScale.x = 1;
         }
         if (inputDirection.x < 0)
         {
             newScale.x = -1;
         }
         transform.localScale = newScale;
    }
}
