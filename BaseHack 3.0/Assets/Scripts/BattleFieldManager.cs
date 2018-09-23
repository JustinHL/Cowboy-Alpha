using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFieldManager : MonoBehaviour {

	private static float battlefieldWidth;
	private static float battlefieldHeight;
	public List<GameObject> battlefieldObjects;
	public List<Enemy> enemies;
	public List<Loot> dropedLoots;
	public readonly GameObject background;

	void Start () {

	}

	public static void generateMap(double difficulty){

	}

	public static void calculateSize(Camera cam){
		battlefieldHeight = cam.pixelHeight;
		battlefieldWidth = battlefieldHeight;
	}

	public static float getBattlefieldWidth(){
		return battlefieldWidth;
	}

	public static float getBattlefieldHeight(){
		return battlefieldHeight;
	}
	// Update is called once per frame
}
