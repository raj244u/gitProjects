using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
	public Transform PickTarget;
	// Use this for initialization
	void Start () {
		for(int x=0;x<=10;x+=2) {
            
            {
                Instantiate(PickTarget, new Vector3(x * -12f, 8f, 0), Quaternion.Euler(0,0,5f));
                
            }


            

        }

       for(int y = 1;y<=10;y +=2)
        {
            Instantiate(PickTarget, new Vector3(y * -12f, 6f, 0), Quaternion.identity);
           
        }
    }
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(5, 15, 35)   *Time.deltaTime);
        
    }
}
