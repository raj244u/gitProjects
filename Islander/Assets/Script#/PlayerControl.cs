using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
	public Transform Player;

	public AudioSource Audio;

	private Rigidbody PlayerRb;
	//	private GameObject enemyScript;

	public Animator PlayerAnimator;
	public int Highcount;

	private int count;
	public Text CountTxt, WinTxt, LifeTxt, GameoverTxt, HighscoreTxt, CurrentScore;

	//	public Transform GroundObject;



	public ParticleSystem mBloodParticle;

	public GameObject gamePanel, winPanel, InGame, enemyAxeList;
	public static PlayerControl Instance;

//	private VirtualJoystick mVirtualStick;
	// Use this for initialization


	//Healthbar..........

	public Image currentHealthbar;

	public float maxHealth, currentHealth;





	public bool isGameover, isDown, isRight, isUp, isDamage, isGrounded;


	public void Awake ()
	{



		Audio.volume = PlayerPrefs.GetFloat ("volumeValue");



	}

	void Start ()
	{

	
		maxHealth = 100;
		currentHealth = maxHealth;
		if (PlayerPrefs.GetInt ("audioKey") == 0) {

			enemyAxeList = GameObject.FindWithTag ("enemy");
			Audio.Stop ();

		}
		
		Instance = this;

		InGame.SetActive (true);
		count = 0;

		SetCountTxt ();

		PlayerRb = GetComponent<Rigidbody> ();



		//		enemyScript = GameObject.FindWithTag ("enemy");

	}


	//	public bool Grounded;
	// Update is called once per frame
	void Update ()
	{

		if (Player.position.y < -6f) {


			currentHealthbar.fillAmount = 0;
			Gameover ();
			Destroy (gameObject);


		}


    mBloodParticle.Emit(1);



		//			Debug.DrawLine (transform.position, GroundObject.position, Color.red);
		//		Grounded = Physics.Linecast (this.transform.position, GroundObject.position, 1 << LayerMask.NameToLayer ("Ground"));
		//		Debug.Log ("Grounded" + Grounded);


		if (isDown || (Input.GetKey (KeyCode.LeftArrow))) {

			//	left direction

			Player.Translate (-Player.right * 5f * Time.deltaTime);
			Player.rotation = Quaternion.Lerp (Player.rotation, Quaternion.Euler (0, 90, 0), 40f * Time.deltaTime);


		}
		if (isRight || (Input.GetKey (KeyCode.RightArrow))) {


			Player.Translate (Player.right * 5f * Time.deltaTime);

			Player.rotation = Quaternion.Lerp (Player.rotation, Quaternion.Euler (0, -90, 0), 40f * Time.deltaTime);
		}
		if (isUp && isGrounded || (Input.GetKeyDown (KeyCode.UpArrow)) && isGrounded) {
			PlayerRb.AddForce (new Vector3 (0, 12f, 0), ForceMode.Impulse);
			PlayerAnimator.SetTrigger ("isJUMP");

			PlayerAnimator.SetBool ("isRUN", false);
		}

		if (isRight || (Input.GetKey (KeyCode.RightArrow)) && isGrounded || isDown || (Input.GetKey (KeyCode.LeftArrow)) && isGrounded) {


			PlayerAnimator.SetBool ("isRUN", true);




		} else {


			PlayerAnimator.SetBool ("isRUN", false);
		}

		Player.position = new Vector3 (Player.position.x, Player.position.y, 0);
	}

	public void OnPointerLeftDown ()
	{
		isDown = true;
		//this.downTime = Time.realtimeSinceStartup;
	}

	public void OnPointerLeftUp ()
	{
		isDown = false;
	}


    

    public void OnPointerRightDown ()
	{
		isRight = true;
		//this.downTime = Time.realtimeSinceStartup;
	}

	public void OnPointerRightUp ()
	{
		isRight = false;
	}

	public void OnPointerJumpDown ()
	{
		isUp = true;
		//this.downTime = Time.realtimeSinceStartup;
	}

	public void OnPointerJumptUp ()
	{
		isUp = false;
	}

	private Vector3 PoolInput ()
	{
		Vector3 dir = Vector3.zero;

		dir.x = VirtualJoystick.mInstance.Horizontal ();
		dir.y = VirtualJoystick.mInstance.Vertical ();
		if (dir.magnitude > 1) {
			dir.Normalize ();
		}
		return dir;
	}

	public void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Platform") {

			isGrounded = true;


		}



	}


	public void OnCollisionExit (Collision collisionInfo)
	{
		if (collisionInfo.gameObject.name == "Platform") {

			isGrounded = false;


		}
	}


	private void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);

			count = count + 1;

			SetCountTxt ();
		}
		if (other.gameObject.CompareTag ("Health pick")) {
			other.gameObject.SetActive (false);

			TakeDamage (-10f);


		}

		if (other.gameObject.CompareTag ("bullet")) {

			float value = 1f;
			//Debug.Log ("bullet.....");
			other.gameObject.SetActive (false);
			TakeDamage (value);

		}


		if (other.gameObject.CompareTag ("enemy") || other.gameObject.CompareTag ("hammer")) {

            
                mBloodParticle.Play();

            float defeat = 5f;
			TakeDamage (defeat);
		}
	}
	//public void checkEnemy()
	//{

	//    enemyAxeList.GetComponent<Animator>().enabled = false;

	//}
	private void SetCountTxt ()
	{
		CountTxt.text = "Score      " + count.ToString ();
       
		if (count >= 7) {
			winPanel.SetActive (true);
			WinTxt.text = "You Win!!\n congratulations";
			gameObject.SetActive (false);

			GameObject.FindWithTag ("enemy").SetActive (false);

		}
	}

	private void TakeDamage (float damage)
	{
		if (currentHealth != 0) {

			currentHealth -= damage;




			currentHealthbar.fillAmount = currentHealth / maxHealth;
			LifeTxt.text = (currentHealthbar.fillAmount * 100).ToString ();
		} else {
           

			Player.rotation = Quaternion.Slerp (Player.rotation, Quaternion.Euler (-90, -90, 0), 40f * Time.deltaTime);

			Gameover ();
            
		}

	}

	public void Gameover ()
	{
		isGameover = true;

		gameObject.GetComponent<Animator> ().enabled = false;

		Highcount = PlayerPrefs.GetInt ("HighscoreTxt_key");
		Debug.Log ("High Score  = " + PlayerPrefs.GetInt ("HighscoreTxt_key"));
		if (Highcount < count) {


			PlayerPrefs.SetInt ("HighscoreTxt_key", count);
			Debug.Log ("Play Score  = " + PlayerPrefs.GetInt ("HighscoreTxt_key"));



		}
		GameoverTxt.text = "Game Over";
		gamePanel.SetActive (true);
		CurrentScore.text = "Current score " + count.ToString ();
		HighscoreTxt.text = "High score " + PlayerPrefs.GetInt ("HighscoreTxt_key").ToString ();

	}




}





