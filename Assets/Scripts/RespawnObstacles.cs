using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObstacles : MonoBehaviour
{

    public GameObject obstacle;
    public Vector3 pos;
    public Vector3 crouchPos;
    public float timeLeft;

	// Use this for initialization
	void Start ()
    {
        pos = new Vector3(-0.9399f, -0.17094f, -0.36f);
        timeLeft = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft <= 0)
        {
            Instantiate(obstacle, pos, Quaternion.identity);
            timeLeft = 1.2f;
        }
	}
}
