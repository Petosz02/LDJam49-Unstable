using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float chaseDistanse;
    [SerializeField] private Vector2 playerDir;
    private Transform playerTransform;

    HealthSystem health;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerTransform = PlayerHandler.Instance.transform;
        health = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = Vector2.zero;

        if(Vector3.Distance(playerTransform.position, transform.position)<= chaseDistanse)
        {
            playerDir = playerTransform.position - transform.position;
            playerDir.Normalize();
            rigidbody.velocity = playerDir * moveSpeed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log( collision.relativeVelocity);
            rigidbody.AddForce(collision.relativeVelocity * -3);
            if (health.Damage(1))
                Destroy(gameObject);
        }
    }
}
