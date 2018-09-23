using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Avatar : MonoBehaviour {
	private double timer = 0;
	protected float direction = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DeliverAction(List<FunctionBullet> actionStack){
		float timePerAction = 2f / actionStack.Count;
		while(true){
			if(timer == 0){
				if(actionStack.Count == 0){
					break;
				}else{
					ExecuteFunctionBullet(actionStack[0], timePerAction);
				}
			}  
			timer += Time.deltaTime;
			if(timer > timePerAction)timer = 0;
		}
	}

	abstract public void ExecuteFunctionBullet(FunctionBullet action, float time);
}
