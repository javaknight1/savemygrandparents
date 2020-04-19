using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    public GameController gameController;
    public GameObject Grandma;
    public GameObject Grandpa;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        gameController = GameObject.FindWithTag("GameController").gameObject.GetComponent<GameController>();
        Grandma = GameObject.FindWithTag("grandma");
        Grandpa = GameObject.FindWithTag("grandpa");
    }

    // Update is called once per frame
    void Update()
    {
        if (Grandma || Grandpa)
        {
            float grandpaDist = float.MaxValue;
            float grandmaDist = float.MaxValue;
            if (Grandpa)
            {
                grandpaDist = Vector3.Distance(transform.position, Grandpa.transform.position);
            }
            if (Grandma)
            {
                grandmaDist = Vector3.Distance(transform.position, Grandma.transform.position);
            }
            Vector3 direction;
            if (grandmaDist < grandpaDist)
            {
                direction = Grandma.transform.position - transform.position;
            }
            else
            {
                direction = Grandpa.transform.position - transform.position;
            }
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "grandma")
        {
            gameController.killGrandma();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "grandpa")
        {
            gameController.killGrandpa();
            Destroy(collision.gameObject);
        }
        
        Destroy(gameObject);
    }
}
