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
	public GameObject alpha;
	private int daysWon;
	
	// Use this for initialization
	void Start () {
		BattleFieldManager.calculateSize(GetComponent<Camera>());
		daysWon = 0;
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
		Instantiate(alpha, new Vector3(BattleFieldManager.getBattlefieldHeight() / 2, BattleFieldManager.getBattlefieldHeight() / 2, 0f), new Quaternion());
	}

	public void BattleWon(){
		gameState = NIGHT;
		daysWon++;
	}

	public void EnterTown(){
		gameState = DAY;
		startGameButton.gameObject.SetActive(false);
		BattleFieldManager.generateMap(daysWon);
	}

	public void GameOver(){
		gameState = TITLE;
	}
	
	// Update is called once per frame
	void Update () {
		switch(gameState){
			case DAY:
				break;
			case NIGHT:
				//MergeManager.merge(loot);
				break;
			default:
				break;

		}
	}
}
