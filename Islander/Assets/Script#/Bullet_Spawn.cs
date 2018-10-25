using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawn : MonoBehaviour {
	public static Bullet_Spawn instanceBullet;
	public GameObject AxeList;
	// Use this for initialization
	void Start () 
	{
		instanceBullet = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			fire ();
		}

	}

	public void fire() 
	{
		//Debug.Log (transform.forward);
		GameObject AxeListSpawn = Instantiate (AxeList,transform.position,AxeList.transform.rotation) as GameObject;
		Rigidbody  rb = AxeListSpawn.GetComponent<Rigidbody>();
		
		rb.AddForce (rb.transform.up * 150f);
		Destroy (AxeList.gameObject,2f);

	}
}
