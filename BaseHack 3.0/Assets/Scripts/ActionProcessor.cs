using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionProecssor : MonoBehaviour {

	public static List<Action> processFunction(FunctionBullet function){
		List<Action> retVal = new List<Action>();
		if(function.GetCode() == FunctionBullet.MERGED){
			foreach(FunctionBullet bullet in function.GetFunctionBullets()){
				retVal.AddRange(processFunction(bullet));
			}
		}else{
			retVal.Add(new Action(function.GetCode()));
		}
		return retVal;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
