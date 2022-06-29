using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Collider2D col;
    public Rigidbody2D rbody;
    public Vector2 vel;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            vel = Vector2.Reflect(vel, collision.GetContact(i).normal);
        }
    }
    private void FixedUpdate()
    {
        rbody.MovePosition(rbody.position + (vel * Time.fixedDeltaTime));
        if(col.bounds.min.y < -14.5 & vel.y < 0) //If the ball is below the paddle surface and velocity is going down
        {
            Paddle pad = Paddle.singleton;
            float dif = Mathf.Abs(transform.position.x - pad.transform.position.x);
            if (pad.transform.lossyScale.x > dif * 2f) vel.y *= -1;
            else { transform.position = Vector2.zero; }
        }
    }
}
