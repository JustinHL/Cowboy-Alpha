using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionProcessor : MonoBehaviour {

	public static List<Action> processFunction(FunctionBullet function, float time){

		List<Action> retVal = new List<Action>();
		function.GetCode();
		if(function.GetCode() == FunctionBullet.MERGED){
			foreach(FunctionBullet bullet in function.GetFunctionBullets()){
				retVal.AddRange(processFunction(bullet, time/function.GetFunctionBullets().Length));
			}
		}else{
			retVal.Add(new Action(time, function));
		}
		return retVal;
	}
}
