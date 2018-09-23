using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : Avatar {
	
	public override void ExecuteFunctionBullet(){
		if(currentAction != null){
			
			if(currentAction.GetFunction().GetCode() == FunctionBullet.ROLL_FORWARD){
				float rollLength = 8f;
				transform.position += new Vector3(rollLength / timePerAction * Time.deltaTime * Mathf.Cos(direction), rollLength / timePerAction * Time.deltaTime * Mathf.Sin(direction), 0f);
			}else if(currentAction.GetFunction().GetCode() == FunctionBullet.ROLL_BACKWARD){
				float rollLength = 8f;
				transform.position -= new Vector3(rollLength / timePerAction * Time.deltaTime * Mathf.Cos(direction), rollLength / timePerAction * Time.deltaTime * Mathf.Sin(direction), 0f);
			}
			timeTaken += Time.deltaTime;
			if(timeTaken > timePerAction){
				currentAction = null;
			}
		}
	}


}
