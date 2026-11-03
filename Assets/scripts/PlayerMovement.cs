using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    private Rigidbody2D playerRb;
    [SerializeField] private GameManager gameManage;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        
        var direction = 0;
        Vector3 pointerPos = Camera.main.ScreenToWorldPoint(Pointer.current.position.ReadValue());
        if (Pointer.current != null && Pointer.current.press.isPressed && pointerPos.x < 0  )
        {
            direction -= 1;
            playerSpriteRenderer.flipX = true;
        }
        if (Pointer.current != null && Pointer.current.press.isPressed && pointerPos.x >= 0)
        {
            direction += 1;
            playerSpriteRenderer.flipX = false;
        }
        if (Keyboard.current != null && Keyboard.current.aKey.isPressed)
        {
            direction -= 1;
            playerSpriteRenderer.flipX = true;
        }
        if (Keyboard.current != null && Keyboard.current.dKey.isPressed)
        {
            direction += 1;
            playerSpriteRenderer.flipX = false;
        }
        playerRb.linearVelocityX = direction * moveSpeed;


        if (transform.position.x < -3)
        {
            transform.position = new Vector2(3, transform.position.y);

        }
        else if (transform.position.x > 3)
        {
            transform.position = new Vector2(-3, transform.position.y);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("die"))
        {
            gameManage.Dead();
        }
    }
}
