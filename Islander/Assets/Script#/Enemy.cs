using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float dist;
    // public GameObject bulletTarget;
    public GameObject player;
   // public float mass;
    public Animator enemy_anim;
    //public bool bullet_hit;
    //public GameObject target;
	private GameObject edge;
	private  bool isCollideEdge;

    // public Text mDebugText;
    void Start()
    {


		edge = GameObject.FindWithTag ("edge");


        player = GameObject.FindWithTag("Player");
        //StartCoroutine("hitBullet");




    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
          
            Destroy(gameObject);
            other.gameObject.SetActive(false);                                                                         
        }


		if(other.gameObject.CompareTag("edge")) {


			isCollideEdge = true;
			Debug.Log ("edge1122");
			//transform.position =  edge.transform.position ;
		//	transform.Rotate( new Vector3(0,90,0)) ; 
		}

    }
	private void OnTriggerExit  (Collider other) {

		if(other.gameObject.CompareTag("edge")) {


			isCollideEdge = false;
			Debug.Log ("edge out");
			//transform.position =  edge.transform.position ;
			//	transform.Rotate( new Vector3(0,90,0)) ; 
		}



	}
        void Update()
    {

      
        if (!PlayerControl.Instance.isGameover)
        {

            dist = 0f;
            Vector3 trgPost = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            enemy_anim.SetBool("isLUMP", false);
            enemy_anim.SetBool("isWALK", false);
            dist = Vector3.Distance(transform.position, player.transform.position);
            //  mDebugText.text =  " Distance" + dist;
            if (dist <= 11f && (PlayerControl.Instance.isGrounded))
            {


                transform.LookAt(trgPost);




                if (dist > 3f)
                {


                    enemy_anim.SetBool("isLUMP", false);
                    enemy_anim.SetBool("isWALK", true);
					if (!isCollideEdge) {
						transform.position = Vector3.Lerp (transform.position, new Vector3 (player.transform.position.x, transform.position.y, transform.position.z), 0.5f * Time.deltaTime);


					} else {
						
						enemy_anim.SetBool("isWALK", false);
						Debug.Log ("coliide");

						transform.rotation = Quaternion.Inverse (transform.rotation);
					
						transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x + 0.08f, transform.position.y, transform.position.z), 0.5f * Time.deltaTime);
					}

                }
                else
                {
                    enemy_anim.SetBool("isWALK", false);

                    enemy_anim.SetBool("isLUMP", true);

                }









            }

        }
        else
        {

            gameObject.GetComponent<Animator>().enabled = false;

        }

    }



    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {

    //        Rigidbody rbdy = collision.gameObject.GetComponent<Rigidbody>();
    //        rbdy.mass = mass;
    //        //Stop Moving/Translating
    //        rbdy.velocity = Vector3.zero;

    //        //Stop rotating
    //        rbdy.angularVelocity = Vector3.zero;
    //    }
    //}
    public void SendMessageTest()
    {

        //	Debug.Log ("Sendmessage Test");

    }


    //IEnumerator hitBullet()
    //{
    //    yield return new WaitForSeconds(2);


    //    if (dist <= 8f)
    //    {
    //        //GameObject targetSpawn = Instantiate(target, bulletTarget.transform.position, this.transform.rotation) as GameObject;




    //    }
    //    StartCoroutine("hitBullet");



    //}
}
