using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform HitPosition;
    [SerializeField] private Transform DefaultPosition;

    private Rigidbody2D rb;

    public bool movingToHitPosition  = false;
    public bool movingToDefaultPosition  = false;

    private float lastInputTime;
    public float inputCooldown = 0.1f; // Set your desired cooldown time here

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        this.transform.position = DefaultPosition.position;
    }

    private void FixedUpdate()
    {
        if (movingToHitPosition)
        {
            if (this.transform.position.y <= HitPosition.position.y)
            {
                movingToHitPosition = false;
                movingToDefaultPosition = true;
            }
            // Move to note
            this.transform.position = HitPosition.position;
        }
        else if (movingToDefaultPosition)
        {
            // Move to default position
            this.transform.position = DefaultPosition.position;
            movingToDefaultPosition = false;
        }
    }


    void OnAttack()
    {
        // Check if enough time has passed since the last input
        if (Time.time - lastInputTime >= inputCooldown)
        {
            movingToHitPosition = true;
            movingToDefaultPosition = false;
            lastInputTime = Time.time;
        }
    }
}
