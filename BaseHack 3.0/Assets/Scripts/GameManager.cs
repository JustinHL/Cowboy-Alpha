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
	public UnityEngine.UI.Button runButton;
	public FunctionBullet[] inventory;
	public FunctionBullet[] currentHand;
	public List<FunctionBullet> currentDeck;
	public GameObject alpha;
	private int daysWon;
	
	// Use this for initialization
	void Start () {
		BattleFieldManager.calculateSize(GetComponent<Camera>());
		daysWon = 0;
		gameState = TITLE;
		startGameButton.onClick.AddListener(EnterTown);
		runButton.onClick.AddListener(runCode);
		runButton.gameObject.SetActive(false);
		inventory = new FunctionBullet[24];
		for(int i = 0; i < 24; i++){
			/*
			if(i < 6){
				inventory[i] = new FunctionBullet(FunctionBullet.FIRE);
			}else
			*/ if(i < 8){
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
		currentHand = new FunctionBullet[6];
		alpha = Instantiate(alpha, new Vector3(-2, 0, 0f), new Quaternion());
	}

	public void BattleWon(){
		gameState = NIGHT;
		daysWon++;
	}

	public void EnterTown(){
		gameState = DAY;
		startGameButton.gameObject.SetActive(false);
		runButton.gameObject.SetActive(true);
		BattleFieldManager.generateMap(daysWon);
		currentDeck = new List<FunctionBullet>(inventory);
		for(int i = 0; i < 6; i++){
			 int randomCard = (int)UnityEngine.Random.Range(0, currentDeck.Count);
			 currentHand[i] = currentDeck[randomCard];
			 currentDeck.RemoveAt(randomCard); 
		}

	}

	public void GameOver(){
		gameState = TITLE;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void runCode(){
		alpha.GetComponent<Alpha>().currentStack = new List<Action>();
		for(int i = 0; i < 6; i++){
			alpha.GetComponent<Alpha>().currentStack.AddRange(ActionProcessor.processFunction(currentHand[i], 2f/6));
		}
		alpha.GetComponent<Alpha>().processing = true;
		if(currentDeck.Count == 0)currentDeck = new List<FunctionBullet>(inventory);
		for(int i = 0; i < 6; i++){
			 int randomCard = (int)UnityEngine.Random.Range(0, currentDeck.Count);
			 currentHand[i] = currentDeck[randomCard];
			 currentDeck.RemoveAt(randomCard); 
		}
	}
}
