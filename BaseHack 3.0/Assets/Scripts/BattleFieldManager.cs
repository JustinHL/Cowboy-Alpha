using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFieldManager : MonoBehaviour {

	private static float battlefieldWidth;
	private static float battlefieldHeight;
	public static List<GameObject> enemies;
	public static List<GameObject> dropedLoots;
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

	public static GameObject GetNearestEnemy(Vector3 transform){
		if(enemies.Count > 0){
			float minDist = Vector3.Distance(transform, enemies[0].gameObject.transform.position);
			GameObject retVal = enemies[0];
			for(int i = 1; i < enemies.Count; i++){
				if(minDist > Vector3.Distance(transform, enemies[i].gameObject.transform.position)){
					minDist = Vector3.Distance(transform, enemies[i].gameObject.transform.position);
					retVal = enemies[i];
				}
			}
			return retVal;
		}
		return null;
	}

	public static GameObject GetNearestLoot(Vector3 transform){
		if(dropedLoots.Count > 0){
			float minDist = Vector3.Distance(transform, dropedLoots[0].gameObject.transform.position);
			GameObject retVal = dropedLoots[0];
			for(int i = 1; i < dropedLoots.Count; i++){
				if(minDist > Vector3.Distance(transform, dropedLoots[i].gameObject.transform.position)){
					minDist = Vector3.Distance(transform, dropedLoots[i].gameObject.transform.position);
					retVal = dropedLoots[i];
				}
			}
			return retVal;
		}
		return null;
	}
	// Update is called once per frame
}
