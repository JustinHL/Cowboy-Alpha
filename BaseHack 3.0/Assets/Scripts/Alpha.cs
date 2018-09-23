using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : Avatar {
	public Animator anim;
	private bool fired = false;
	public GameObject bullet;

	void Start () {
		anim = GetComponent<Animator>();
	}
	
	public override void ExecuteFunctionBullet(){
		if(currentAction != null){
			
			if(currentAction.GetFunction().GetCode() == FunctionBullet.ROLL_FORWARD){
				anim.SetBool("dashF", true);
				float rollLength = 200f;
				transform.position += new Vector3(rollLength / timePerAction * Time.deltaTime * Mathf.Cos(direction), rollLength / timePerAction * Time.deltaTime * Mathf.Sin(direction), 0f);
			}else if(currentAction.GetFunction().GetCode() == FunctionBullet.ROLL_BACKWARD){
				anim.SetBool("dashB", true);
				float rollLength = 200f;
				transform.position -= new Vector3(rollLength / timePerAction * Time.deltaTime * Mathf.Cos(direction), rollLength / timePerAction * Time.deltaTime * Mathf.Sin(direction), 0f);
			}else if(currentAction.GetFunction().GetCode() == FunctionBullet.TURN_TO_NEAREST_ENEMY){
				anim.SetBool("Walking", true);
				GameObject nearest = BattleFieldManager.GetNearestEnemy(transform.position);
				if(nearest != null){
					direction = Mathf.Atan((nearest.transform.position.y - transform.position.y)/ (nearest.transform.position.x - transform.position.x));
					if(nearest.transform.position.x < transform.position.x)direction += Mathf.PI;
				}
			}else if(currentAction.GetFunction().GetCode() == FunctionBullet.TURN_TO_NEAREST_LOOT){
				anim.SetBool("Walking", true);
				GameObject nearest = BattleFieldManager.GetNearestLoot(transform.position); 
				if(nearest != null){
					direction = Mathf.Atan((nearest.transform.position.y - transform.position.y)/ (nearest.transform.position.x - transform.position.x));
					if(nearest.transform.position.x < transform.position.x)direction += Mathf.PI;
				}
			}else if(currentAction.GetFunction().GetCode() == FunctionBullet.FIRE){
				if(!fired){
					GameObject bullet = new GameObject("bullet");
					bullet.AddComponent<BulletManager>();
					bullet.GetComponent<BulletManager>().init(direction, 10, gameObject);
					Instantiate(bullet, transform.position, new Quaternion());
					fired = true;
				}
			}else{
				fired = false;
				anim.SetBool("dashF", false);
				anim.SetBool("dashB", false);
				anim.SetBool("Walking", false);
			}
			timeTaken += Time.deltaTime;
			if(timeTaken > timePerAction){
				currentAction = null;
			}
		}else{
			Debug.Log("w");
			anim.SetBool("dashF", false);
			anim.SetBool("dashB", false);
			anim.SetBool("Walking", false);
		}
	}

	public override void Hit(){

	}

}
