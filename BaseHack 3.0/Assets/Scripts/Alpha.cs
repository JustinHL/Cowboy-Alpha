using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : Avatar {
	FunctionBullet currentAction;
	double timeTaken;
	double totalTime;

	public abstract void ExecuteFunctionBullet(FunctionBullet action, double time){
		currentAction = action;
		timeTaken = 0;
		totalTime = time;
	}

	void Update () {
		if(currentAction != null){
			if(currentAction.GetCode() == FunctionBullet.ROLL_FORWARD){
				double rollLength = BattleFieldManager.getBattlefieldWidth() / 4;
				
			}else if(currentAction.GetCode() == FunctionBullet.ROLL_BACKWARD){

			}
		}
	}
}
