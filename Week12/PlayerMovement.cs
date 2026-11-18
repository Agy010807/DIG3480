using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    public Sprite beartop;
    public Sprite beardown;
    public Sprite bearleft;
    public Sprite bearright;

    public Transform weapon;

    // NEW: Sword sprite renderer
    public SpriteRenderer swordRenderer;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
            spriteRenderer.sprite = bearleft;

            weapon.localScale = new Vector3(-1, 1, 1);
            weapon.localRotation = Quaternion.Euler(0, 0, 0);

            swordRenderer.sortingOrder = 1;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
            spriteRenderer.sprite = bearright;

            weapon.localScale = new Vector3(1, 1, 1);
            weapon.localRotation = Quaternion.Euler(0, 0, 0);

            swordRenderer.sortingOrder = 1;
        }
        else
        {
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
            spriteRenderer.sprite = beartop;

            weapon.localScale = new Vector3(1, 1, 1);
            weapon.localRotation = Quaternion.Euler(0, 0, 90);

            // Sword appears behind player
            swordRenderer.sortingOrder = -1;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
            spriteRenderer.sprite = beardown;

            weapon.localScale = new Vector3(1, 1, 1);
            weapon.localRotation = Quaternion.Euler(0, 0, -90);

            // Sword appears in front of player
            swordRenderer.sortingOrder = 1;
        }
        else
        {
            speedY = 0;
        }

        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}
