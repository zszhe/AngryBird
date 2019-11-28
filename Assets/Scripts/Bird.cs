using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public GameObject boom;

    public SpringJoint2D sp;
    public Rigidbody2D rg;

    public LineRenderer right;
    public Transform rightPos;
    public LineRenderer left;
    public Transform leftPos;
    public Transform springPos;

    public TestMyTrail testMyTrail;

    public float maxDis;

    private bool isClick = false;
    public bool done = false;

    void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
        springPos = transform.Find("springPos");
        testMyTrail = GetComponent<TestMyTrail>();
    }

	// Update is called once per frame
	void Update () {
		if(isClick == true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += new Vector3(0, 0, 10);

            if (Vector3.Distance(transform.position, rightPos.position) > maxDis)
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;
                transform.position = pos * maxDis + rightPos .position;
            }
        }
        if (done)
        {
            DrawLine();
        }
       
	} 

	void OnMouseDown()
    {
        isClick = true;
        rg.isKinematic = true;

    }

    void OnMouseUp()
    {
        isClick = false;
        rg.isKinematic = false;
        done = false;
        right.enabled = false;
        left.enabled = false;
        Invoke("Fly", 0.1f);
    }

    void Fly()
    {
        testMyTrail.heroAttack();
        sp.enabled = false;
        Invoke("Next", 2f);
    }

    void DrawLine()
    {
        right.enabled = true;
        left.enabled = true;

        right.SetPosition(0, rightPos.position);
        right.SetPosition(1, springPos.position);
        left.SetPosition(0, leftPos.position);
        left.SetPosition(1, springPos.position);
    }

    void Next()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(this.gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManager._instance.NextBird();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        testMyTrail.heroIdle();
    }
}
