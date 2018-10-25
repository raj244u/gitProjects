using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject AxeListSpawn = Instantiate (transform.position,AxeList.transform.rotation) as GameObject;
		Rigidbody  rb = gameObject.GetComponent<Rigidbody>();
        
        rb.AddForce(rb.transform.forward * 10f);
       // transform.Translate(this.transform.forward);
       
           
        Destroy (this.gameObject,4f);

        


    }
}
