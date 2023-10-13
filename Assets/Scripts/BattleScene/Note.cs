using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;

    [SerializeField] private float _goodRange;
    [SerializeField] private float _perfectRange;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 collisionPoint = collision.ClosestPoint(transform.position);
        float xDistanceFromCollisionPoint = Mathf.Abs(collisionPoint.x - this.transform.position.x);
        Debug.Log(xDistanceFromCollisionPoint);
        if (xDistanceFromCollisionPoint < _perfectRange)
        {
            Debug.Log("Perfect!");
        }
        else
        {
            Debug.Log("Good");
        }
    }

    public void InitializeDirection(Vector2 direction)=>this.direction = direction; 
}
