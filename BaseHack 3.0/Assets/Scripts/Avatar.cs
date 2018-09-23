using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Avatar : MonoBehaviour {
	private double timer = 0;
	protected float direction = 0;
	protected Action currentAction;
	protected float timeTaken;
	protected float timePerAction;
	public bool processing;
	public List<Action> currentStack;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	
	public void Update () {
		if(processing){
			if(timer == 0){
				currentStack.RemoveAt(0);
				if(currentStack.Count == 0){
					processing = false;
					currentAction = null;
					Debug.Log("a");
				}else{	
					currentAction = currentStack[0];
					timePerAction = currentAction.getTime();
				}
			}  
			timer += Time.deltaTime;
			ExecuteFunctionBullet();
			if(timer > timePerAction){
				timer = 0;
			}
		}
		if(transform.position.x < 0){
			transform.position = new Vector3(0, transform.position.y, 0f);
		}else if(transform.position.x > 300){
			transform.position = new Vector3(300, transform.position.y, 0f);;
		}
		if(transform.position.y < 0){
			transform.position = new Vector3(transform.position.x, 0, 0f);
		}else if(transform.position.y > 200){
			transform.position = new Vector3(transform.position.x, 200, 0f);
		}
	}

	abstract public void Hit();

	abstract public void ExecuteFunctionBullet();
}
