using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

	private Rigidbody rigidBody;
	public float SPEED;
	public Text scoreText;
	public Text gameOverText;
	private int score = 0;

	void Start() 
	{
		gameOverText.gameObject.SetActive (false);
		rigidBody = GetComponent<Rigidbody> ();
		score = 0;
		setScore();
	}

	void FixedUpdate() 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rigidBody.AddForce (movement * SPEED);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("pickup")) 
		{
			other.gameObject.SetActive(false);
			score++; 
			setScore();
			if (score >= 17) {
				gameOverText.gameObject.SetActive (true);
			}
		}
	}

	void setScore(){
		scoreText.text = "Score : " + score.ToString();

	}

	void Update() {
		if (transform.position.y < -10) {
			gameOverText.gameObject.SetActive (true);
		}
	}
}
