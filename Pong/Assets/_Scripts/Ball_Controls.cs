using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controls : MonoBehaviour {

    float speed = 5f;
    Rigidbody2D rigid;
    Vector2 startPosition;

    private void Start()
    {
        startPosition = gameObject.transform.position;
        rigid = GetComponent<Rigidbody2D>();
        BallReset();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle")
        {
            float y = HitValue(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 direction = new Vector2(1, y).normalized;
            rigid.velocity = direction * speed;
        }
        if(collision.gameObject.name == "EnemyPaddle")
        {
            float y = HitValue(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 direction = new Vector2(-1, y).normalized;
            rigid.velocity = direction * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "EnemySide")
        {
            Score_Sheet.instance.PlayerScored();
            BallReset();
        }
        else if(collision.gameObject.name == "PlayerSide")
        {
            Score_Sheet.instance.EnemyScored();
            BallReset();
        }
    }

    public float HitValue(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        speed += 0.5f;
        return (ballPos.y - paddlePos.y) / paddleHeight;
    }

    void BallReset()
    {
        gameObject.transform.position = startPosition;
        speed = 5f;
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            rigid.velocity = Vector2.right * speed;
        }
        else
            rigid.velocity = Vector2.left * speed;
    }
}
