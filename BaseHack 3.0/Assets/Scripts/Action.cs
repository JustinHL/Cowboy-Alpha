using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action{
	float time;
	FunctionBullet function;
	
	public Action(float time, FunctionBullet function){
		this.time = time;
		this.function = function;
	}

	public float getTime(){
		return time;
	}

	public FunctionBullet GetFunction(){
		return function;
	}
}
