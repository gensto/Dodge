using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public Vector3 jumpPos;
    public Vector3 crouchPos;

    Animator anim;

    float speed = 5.0f;
    public Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        anim = this.GetComponent<Animator>();

        jumpPos = new Vector3(0.25f, 0.65f, 9.37f);
        crouchPos = new Vector3(0.25f, 1.46f, 9.37f);

        int randPos = Random.Range(0, 2);

        Debug.Log("Rando pos: " + randPos);

        if(randPos == 0)
        {
            rb.position = crouchPos;
        }
        else
        {
            rb.position = jumpPos;
        }

        rb.velocity = -(transform.forward) * speed;
        rb.transform.Rotate(0, 0, 90);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(gameObject.transform.position.z < -8.0f)
        {
            Destroy(gameObject);
        }
	}
}
