using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACtionProecssor : MonoBehaviour {

	public static List<FunctionBullet> processFunction(FunctionBullet function){
		List<FunctionBullet> retVal = new List<FunctionBullet>();
		if(function.GetCode() == FunctionBullet.MERGED){
			foreach(FunctionBullet bullet in function.GetFunctionBullets()){
				retVal.AddRange(processFunction(bullet));
			}
		}else{
			retVal.Add(new FunctionBullet(function.GetCode()));
		}
		return retVal;
	}
}
