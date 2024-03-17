using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

	public GameObject player;

	// public variables
	public int score=0;
	public GameObject MainCanvas;
	public GameObject PlayCanvas;
	public GameObject GameOverCanvas;
	public bool canBeatLevel = false;
	public int beatLevelScore=0;

	public float startTime=5.0f;
	
	public Text mainTimerDisplay;
	public GameObject counter;

	public AudioSource musicAudioSource;

	public bool gameIsOver = false;
	private Health playerHealth;

	private float currentTime;

	// setup the game
	void Start () {
				MainCanvas.SetActive(false);
				GameOverCanvas.SetActive(false);
		counter.SetActive(true);
		
		// set the current time to the startTime specified
		currentTime = startTime;

		// get a reference to the GameManager component for use by other scripts
		if (gm == null) 
			gm = this.gameObject.GetComponent<GameManager>();
		if (player == null) 
			player = GameObject.FindWithTag("Player");

		playerHealth = player.GetComponent<Health>();

		// init scoreboard to 0

		// inactivate the gameOverScoreOutline gameObject, if it is set
	}

	// this is the main game event loop
	void Update () {
		
		if (!gameIsOver) {
			MainCanvas.SetActive(false);
			GameOverCanvas.SetActive(false);
			PlayCanvas.SetActive(true);
			if (canBeatLevel && (score >= beatLevelScore)) {  // check to see if beat game
				BeatLevel ();
			} else if (currentTime < 0) { // check to see if timer has run out
				EndGame ();
			} 
			else if(playerHealth.isAlive == false)
			{
				BeatLevel();
			}
			else { // game playing state, so update the timer
				StartCoroutine(wait());
				//currentTime -= Time.deltaTime;
				//mainTimerDisplay.text = currentTime.ToString ("0.00");				
			}
		}
	}
	
		IEnumerator wait(){
		yield return new WaitForSeconds(4);
		currentTime -= Time.deltaTime;
				mainTimerDisplay.text = currentTime.ToString ("0.00");}
		
	void EndGame() {
		// game is over
		gameIsOver = true;

		// repurpose the timer to display a message to the player
		mainTimerDisplay.text = "GAME OVER";
		PlayCanvas.SetActive(false);
		GameOverCanvas.SetActive(true);
		// activate the playAgainButtons gameObject, if it is set 
		

		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}
	
	void BeatLevel() {
		// game is over
		gameIsOver = true;
		PlayCanvas.SetActive(false);
		MainCanvas.SetActive(true);
		// repurpose the timer to display a message to the player
		mainTimerDisplay.text = "LEVEL COMPLETE";

		
		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}


}
