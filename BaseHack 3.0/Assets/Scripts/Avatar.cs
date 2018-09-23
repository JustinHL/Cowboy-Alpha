using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Avatar : MonoBehaviour {
	private double timer = 0;
	protected double direction = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DeliverAction(List<FunctionBullet> actionStack){
		double timePerAction = 2 / actionStack.Count;
		while(true){
			if(timer == 0){
				if(actionStack.Count == 0){
					break;
				}else{
					ExecuteFunctionBullet(actionStack[0]);
				}
			}
			timer += Time.deltaTime;
			if(timer > timePerAction)timer = 0;
		}
	}

	public abstract void ExecuteFunctionBullet(FunctionBullet action, double time);
}
