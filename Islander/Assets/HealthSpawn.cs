using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour {
	public GameObject HealthTarget;
	// Use this for initialization
	void Start () {
		for(int i = 1;i<10;i +=2 ) {

			Instantiate (HealthTarget,new Vector3(i * -12f,6f,0),transform.rotation) ;


		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
