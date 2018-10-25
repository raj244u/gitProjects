using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemo : MonoBehaviour {
    public Animator m_anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = new Vector3(transform.position.x,transform.position.y,0);


        m_anim.SetBool("isRUN", false);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_anim.SetBool("isRUN",true);
            transform.Translate(-transform.right * 5f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 40f * Time.deltaTime);
        
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_anim.SetBool("isRUN", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 40f * Time.deltaTime);
          
            transform.Translate(transform.right * 5f * Time.deltaTime);

        }
	}
}
