using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hammer : MonoBehaviour
{
    public GameObject AxeTarget;
    int i;
    public Text DisplayMessage;
    private GameObject[] AxeList;
    private GameObject[] AxeImg;
    // Use this for initialization
    void Start()
    {
        AxeList = new GameObject[3];
        AxeImg = new GameObject[3];
        AxeImg[0] = GameObject.FindWithTag("axe3");
        AxeImg[1] = GameObject.FindWithTag("axe2");
        AxeImg[2] = GameObject.FindWithTag("axe1");

       

        i = 0;
    }

    // Update is called once per frame
    public void Update()
    {
   

    }
    public void Attack()
    {

        if(i < 3)
        {

            AxeList[i] = GameObject.Instantiate(AxeTarget, transform.position, transform.rotation) as GameObject;



            Debug.Log("hit...");
            AxeList[i].SetActive(true);
            AxeImg[i].SetActive(false);
            Rigidbody rb = AxeList[i].GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 500f * 40f * Time.deltaTime);
        }
        else
        {
     
			Display ();
			Destroy (DisplayMessage,1f);
        }

            
       
      //  AxeList[i].transform.Translate(AxeList[i].transform.forward * 20f * Time.deltaTime);
     //   Destroy(AxeList[i], 1.3f);
        i++;

    }

	void Display() {

		DisplayMessage.text = "weapons are empty";

	}

}
