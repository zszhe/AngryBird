using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigs : MonoBehaviour {

    private float maxSpeed = 10;

    private float minSpeed = 3;

    private SpriteRenderer sr;

    public Sprite hurt;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            Destroy(gameObject);
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)
        {
            sr.sprite = hurt;
        }
    }
}
