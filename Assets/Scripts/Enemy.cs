using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float minSpeed = 1.0f;
	public float maxSpeed = 3.0f;
	public float currentSpeed;
	public GameObject enemyToSpawn;
	public Transform enemyTransform;
	public int score = 0;
	public bool isPaused = false;
	public bool hasWon = false;
	public int quitDelay = 5;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(Random.Range (-7f, 7f), 10, -1);
		currentSpeed = Random.Range(minSpeed, maxSpeed);
		StartCoroutine(updateCurrentSpeed());
		isPaused = false;
		hasWon = false;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.down * currentSpeed * Time.deltaTime);
		if(transform.position.y <= -4.5)
		{
			transform.position = new Vector3(Random.Range (-7f, 7f), 10, -1);
			score = score - 1;
		}

		if(Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.Escape)) {
			if(isPaused)
			{
				isPaused = false;
				Time.timeScale = 1;
				Debug.Log ("Game unpaused");
			} else if (!isPaused) {
				isPaused = true;
				Time.timeScale = 0;
				Debug.Log ("Game paused");
			}
		}
	}

	IEnumerator updateCurrentSpeed() {
		yield return new WaitForSeconds(2);
		currentSpeed = Random.Range(minSpeed, maxSpeed);
		yield return new WaitForSeconds(3);
	}

	/*
	 * Was going to use OnCollisionEnter instead
	 * of OnTriggerEnter, but OnTriggerEnter was
	 * simply a better choice for what I needed.
	void OnCollisionEnter(Collision collision) {
		Destroy(collision.gameObject);
	}
	*/
	void OnTriggerEnter(Collider collision) {
		transform.position = new Vector3(Random.Range (-10f, 10f), 10, -1);
		score++;
	}
	/*
	 * This is a old function that didn't work with GUI
	 * but I'm going to try and put it back in.
	void Pause() {
		if(Input.GetKey(KeyCode.Escape)) {
			if(!isPaused) {
				Time.timeScale = 0;
				Debug.Log("Game paused");
				isPaused = true;
			}
			if(isPaused) {
				Time.timeScale = 1;
				Debug.Log("Game unpaused");
				isPaused = true;
			}
		}
	}
	*/
	void OnGUI() {
		GUI.Box (new Rect(10, 10, 160, 40), "Space Shooter");
		GUI.Label(new Rect(64, 24, 150, 30), "Score = " + score +"");

		if (isPaused == true) {
			
			if(GUI.Button(new Rect(600, 10, 150, 50), "Unpause game")) {
				Time.timeScale = 1;
				Debug.Log ("Game unpaused via button");
				isPaused = false;
			}
		}

		if(score > 9) {
			GUI.Label(new Rect(600, 300, 300, 300), "You Win!");
			Time.timeScale = 0;
			hasWon = true;
			StartCoroutine(quitter());
		}

	}

	IEnumerator quitter() {
		//GUI.Label (new Rect(600, 330, 300, 300), "Quitting in " + quitDelay + " seconds.");
		GUI.Label (new Rect(600, 330, 300, 300), "Quitting in 5 seconds.");
		yield return new WaitForSeconds(5);
		Application.Quit();
	}
	/*
	IEnumerator countdownDelay() {
		while(true) {
		yield return new WaitForSeconds(1);
		quitDelay = quitDelay - 1;
		}
	}
	*/
}
