using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    private const float rayLength = 1.2f;
    [Header( "Movement parameters" )] 
    [Range( 0.01f, 20.0f )] [SerializeField] private float moveSpeed = 0.1f; // moving speed of the player
    [Range( 0.01f, 20.0f )] [SerializeField] private float jumpForce = 6f; // moving speed of the player
    public LayerMask groundLayer;
    private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(this.transform.position, Vector2.down, rayLength, groundLayer.value);
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Lisek se skacze");
        }
    }
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        } 
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        Debug.DrawRay(transform.position, rayLength * Vector3.down, Color.white, 1, false);
    }
}
