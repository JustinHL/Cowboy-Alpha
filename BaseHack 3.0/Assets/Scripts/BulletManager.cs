using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
	private float direction;
	private float velocity;
	private GameObject shooter;

	public void init(float direction, float velocity, GameObject shooter){
		this.direction = direction;
		this.velocity = velocity;
		this.shooter = shooter;
	}

	void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject != shooter){
        	collision.gameObject.GetComponent<Avatar>().Hit();
        	Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(velocity * Time.deltaTime * Mathf.Cos(direction), velocity * Time.deltaTime * Mathf.Sin(direction), 0f);
	}
}
