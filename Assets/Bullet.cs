using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").gameObject.GetComponent<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.collider.tag == "enemy")
        {
            gameController.addScore();
            Destroy(collision.collider.gameObject);
        }
    }
}
