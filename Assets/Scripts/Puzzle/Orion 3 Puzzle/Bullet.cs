using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LaserCaster laserCaster;
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void Update() {
        lastVelocity = rb.velocity;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
        } else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Destroy(gameObject);
            laserCaster.isFiring = false;
        } else if (collision.gameObject.CompareTag("Target")) {
            // todo: puzzle complete on this
            Destroy(gameObject);
            laserCaster.isFiring = false;
            Debug.Log("winner");
        }
    }
}
