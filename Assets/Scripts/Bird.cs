using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public SpringJoint2D sp;
    public Rigidbody2D rg;
    public Transform right;

    public float maxDis;

    private bool isClick = false;

    void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
		if(isClick == true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += new Vector3(0, 0, 10);

            if (Vector3.Distance(transform.position, right.position) > maxDis)
            {
                Vector3 pos = (transform.position - right.position).normalized;
                transform.position = pos * maxDis + right .position;
            }
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
        Invoke("Fly", 0.1f);
    }

    void Fly()
    {
        sp.enabled = false;
    }
}
