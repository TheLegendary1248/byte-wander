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
        //Get reflection off paddle
        Paddle pad = Paddle.singleton;
        float dif = transform.position.x - pad.transform.position.x;
        float padXScale = pad.transform.lossyScale.x;
        float ratio = (dif * 2f) / padXScale;
        Vector2 relectionUnitVec = new Vector2(Mathf.Sin(ratio / 2.2f * Mathf.PI), Mathf.Cos(ratio / 2.2f * Mathf.PI));
        if (padXScale > Mathf.Abs(dif * 2f))
        {
            Debug.DrawRay(new Vector2(transform.position.x, pad.transform.position.y), relectionUnitVec * 4f, Color.red);
            float heightDif = (26f -(transform.position.y - pad.transform.position.y)) / 26f;
            Debug.DrawLine(transform.position, new Vector2(transform.position.x, pad.transform.position.y), new Color(heightDif,heightDif,heightDif,heightDif));
        }
        if (col.bounds.min.y < -14.5 & vel.y < 0) //If the ball is below the paddle surface and velocity is going down
        {
            if (padXScale > Mathf.Abs(dif * 2f))
            { 
                Debug.Log(ratio);
                vel = relectionUnitVec * vel.magnitude;
                Debug.DrawRay(transform.position, vel, Color.cyan, 3f);
            }
            else { transform.position = Vector2.zero; } //Set to center on failure to catch the ball for now
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            vel = new Vector2(0, -vel.magnitude);
        }
    }
}
