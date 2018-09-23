using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : Avatar {
	FunctionBullet currentAction;
	float timeTaken;
	float totalTime;

	public override void ExecuteFunctionBullet(FunctionBullet action, float time){
		currentAction = action;
		timeTaken = 0;
		totalTime = time;
	}

	void Update () {
		if(currentAction != null){
			if(currentAction.GetCode() == FunctionBullet.ROLL_FORWARD){
				float rollLength = (float)BattleFieldManager.getBattlefieldWidth() / 4;
				transform.Translate(rollLength / totalTime * Time.deltaTime * Mathf.Cos(direction), rollLength / totalTime * Time.deltaTime * Mathf.Sin(direction), 0f);
			}else if(currentAction.GetCode() == FunctionBullet.ROLL_BACKWARD){
				float rollLength = (float)BattleFieldManager.getBattlefieldWidth() / 4;
				transform.Translate(-rollLength / totalTime * Time.deltaTime * Mathf.Cos(direction), -rollLength / totalTime * Time.deltaTime * Mathf.Sin(direction), 0f);
			}
			timeTaken += Time.deltaTime;
			if(Time.deltaTime > totalTime){
				currentAction = null;
			}
		}
	}
}
