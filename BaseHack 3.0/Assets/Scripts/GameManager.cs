using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	private const int TITLE = 0, DAY = 1, NIGHT = 2;
	public int gameState;
	public bool frozen = true;
	public List<FunctionBullet> loot;
	// Use this for initialization
	void Start () {
		gameState = TITLE;
	}

	public void BattleWon(){
		gameState = NIGHT;
	}

	public void EnterTown(){
		gameState = DAY;
	}

	public void GameOver(){
		gameState = TITLE;
	}
	
	// Update is called once per frame
	void Update () {
		switch(gameState){
			case DAY:
				if(frozen){
					
				}else{

				}
				break;
			case NIGHT:
				MergeManager.merge(loot);
				break;
			default:
				break;

		}
	}
}
