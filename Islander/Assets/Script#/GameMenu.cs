using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {
	
//	public AudioSource audioSource;
	public GameObject  soundPanel,menuPanel;
	public Toggle audioCheck;
	public float mVolume;
	public Slider mSlider;
    
	// Use this for initialization
	void Start () {
		
//		audioCheck = GameObject.FindWithTag ("toggle").GetComponent<Toggle>();
//		audioSource = GetComponent<AudioSource> ();
		menuPanel.SetActive (true);
		soundPanel.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		if(mSlider!=null) {
		mVolume = mSlider.value;
		PlayerPrefs.SetFloat ("volumeValue",mVolume);
		


		}
	}


	public void Play() {
		
		SceneManager.LoadScene (1);


	}


	public void Control() {
		
		menuPanel.SetActive (false);
		soundPanel.SetActive (true);
		PlayerPrefs.SetInt ("audioKey",0);

		
		if (audioCheck.isOn) {
			
			PlayerPrefs.SetInt ("audioKey", 1);


		} else {
			
			PlayerPrefs.SetInt ("audioKey",0);
		}




	}
	public void  backArrow() {
		
		soundPanel.SetActive (false);
		menuPanel.SetActive (true);

	}

	public void toggleAudio() {




	}
	public void Quit() {

		Application.Quit();

	}



}
