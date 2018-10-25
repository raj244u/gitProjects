using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public GameObject player;

	private Vector3 offset;
	private Vector3 mTemp;
	public float cameraY;
		
	// Use this for initialization
	void Start ()
	{


		offset = transform.position - player.transform.position;
	//	Debug.Log ("Offset  "+offset);

	
	}
	


	void LateUpdate ()
	{
		
		
		if (player != null ) {
			mTemp = new Vector3 (player.transform.position.x,cameraY,player.transform.position.z);	
			transform.position = mTemp + offset;
//			transform.position = Quaternion.Lerp(transform.position,player.transform.position+offset,2f *Time.deltaTime);


		} else {
			

		}



	}
}
