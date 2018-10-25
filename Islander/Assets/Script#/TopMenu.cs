using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void play() {
//		SceneManager.LoadScene ();

		Time.timeScale = 1;
	}

	public void pause() {
		Time.timeScale = 0;

//		SceneManager.LoadScene ();

	}
}
