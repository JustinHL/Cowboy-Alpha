using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	private const int TITLE = 0, DAY = 1, NIGHT = 2;
	public int gameState;
	public bool frozen = true;
	public List<FunctionBullet> loot;
	public UnityEngine.UI.Button startGameButton;
	public FunctionBullet[] inventory;  
	
	// Use this for initialization
	void Start () {
		gameState = TITLE;
		startGameButton.onClick.AddListener(EnterTown);
		inventory = new FunctionBullet[24];
		for(int i = 0; i < 24; i++){
			if(i < 6){
				inventory[i] = new FunctionBullet(FunctionBullet.FIRE);
			}else if(i < 8){
				inventory[i] = new FunctionBullet(FunctionBullet.ROLL_FORWARD); 
			}else if(i < 10){
				inventory[i] = new FunctionBullet(FunctionBullet.ROLL_BACKWARD); 
			}else if(i < 14){
				inventory[i] = new FunctionBullet(FunctionBullet.TURN_TO_NEAREST_ENEMY);
			}else if(i < 18){
				inventory[i] = new FunctionBullet(FunctionBullet.TURN_TO_NEAREST_LOOT);
			}else{
				inventory[i] = new FunctionBullet(FunctionBullet.DO_NOTHING);
			}
		} 
	}

	public void BattleWon(){
		gameState = NIGHT;
	}

	public void EnterTown(){
		gameState = DAY;
		startGameButton.gameObject.SetActive(false);
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
				//MergeManager.merge(loot);
				break;
			default:
				break;

		}
	}
}
