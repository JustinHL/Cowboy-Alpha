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
	}

	abstract public void ExecuteFunctionBullet();
}
