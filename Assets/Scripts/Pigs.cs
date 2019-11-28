using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigs : MonoBehaviour {

    private float maxSpeed = 10;

    private float minSpeed = 3;

    private SpriteRenderer sr;

    public Sprite hurt;
    public GameObject boom;
    public GameObject score;

    public bool isPig = false;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            Dead();
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)
        {
            sr.sprite = hurt;
        }
    }

    void Dead()
    {
        if(isPig)
        {
            GameManager._instance.pigs.Remove(this);
        }
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameObject a = Instantiate(score, transform.position + new Vector3(0, 0.45f, 0), Quaternion.identity);
        Destroy(a, 1.1f);
    }
}
