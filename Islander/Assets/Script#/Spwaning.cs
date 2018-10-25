using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaning : MonoBehaviour {
	public GameObject  pickUp,platform,enemy;

	public GameObject[] respawns;
	// Use this for initialization
	void Start () {

		if(respawns == null) {
		respawns = GameObject.FindGameObjectsWithTag ("Pick Up");

		}

		foreach (GameObject respawn in respawns)
		{
			Instantiate(pickUp, respawn.transform.position, respawn.transform.rotation);
		}
		if ( gameObject.CompareTag("Pick Up")) {
			Debug.Log ("Pick Up");
			for (int x = 1; x < 10; x++) {
				Instantiate (pickUp, new Vector3 (x * -18f, 0, 0), Quaternion.identity);
			}



		}
		else if(gameObject.CompareTag ("Platform")) {


			for (int x = 1; x < 10; x++) {
				Instantiate (gameObject, new Vector3 (x * -18f, 0, 0), Quaternion.identity);
			}



		}
		else if(gameObject.CompareTag ( "enemy")) {


			for (int x = 1; x < 10; x++) {
				Instantiate (gameObject, new Vector3 (x * -18f, 0, 0), Quaternion.identity);
			}


		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
