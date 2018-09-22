using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionBullet : MonoBehaviour {
	public const byte MERGED = 0, ROLL_FORWARD = 1, ROLL_BACKWARD = 2,
	FIRE = 3, TURN_TO_NEAREST_LOOT = 4, TURN_TO_NEAREST_ENEMY = 5,
	DO_NOTHING = 6;
	public readonly byte code;
	public readonly FunctionBullet[] functionBullets;

	void Start (){
		
	}

	public FunctionBullet(byte basicBullet){
		code = basicBullet;
	}

	public FunctionBullet(FunctionBullet[] mergeBullets){
		code = MERGED;
		functionBullets = mergeBullets;
	}

	public FunctionBullet[] GetFunctionBullets(){
		return functionBullets;
	}

	public byte GetCode(){
		return code;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
