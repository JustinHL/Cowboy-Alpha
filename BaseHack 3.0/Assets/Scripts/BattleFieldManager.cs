using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFieldManager : MonoBehaviour {

	private static double battlefieldWidth;
	private static double battlefieldHeight;
	public List<GameObject> battlefieldObjects;
	public List<Enemy> enemies;
	public List<Loot> dropedLoots;
	public readonly GameObject background;

	void Start () {

	}

	public static void calculateSize(){
		battlefieldHeight = GetComponent<Camera>().pixelHeight;
		battlefieldWidth = battlefieldHeight;
	}

	public static double getBattlefieldWidth(){
		return battlefieldWidth;
	}

	public static double getBattlefieldHeight(){
		return battlefieldHeight;
	}
	// Update is called once per frame
}
