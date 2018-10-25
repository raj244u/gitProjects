using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
	public GameObject PlatformTarget;
	// Use this for initialization
	void Start () 
	{
		for (int x = 0; x <= 10; x++) 
		{
			Instantiate (PlatformTarget, new Vector3 (x * -35f, 0, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


}
