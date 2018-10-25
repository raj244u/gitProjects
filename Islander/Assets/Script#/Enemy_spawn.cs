using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour {
	public GameObject enemyTarget;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {


		rb = enemyTarget.GetComponent<Rigidbody> ();
		for(int x=0;x<10;x++) {
			Instantiate (enemyTarget,new Vector3(x * -22f,2.0f,0),Quaternion.Euler(new Vector3(0,90,0)));


			if (x % 2 == 0) {

				enemyTarget.transform.position =  Vector3.Lerp (enemyTarget.transform.position     , rb.velocity   ,  5f * Time.deltaTime);
               

			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
