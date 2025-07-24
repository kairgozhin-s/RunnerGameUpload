using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class App_Initialize : MonoBehaviour{

		public GameObject inMenuUI;
		public GameObject inGameUI;
		public GameObject gameOverUI;
		public GameObject adButton;
		public GameObject player;
		private bool hasGameStarted = false;
		private bool hasSeenRewardedAd = false;


	void Awake() {
		Application.targetFrameRate = 60;
				}	

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
	inMenuUI.gameObject.SetActive(true);
	inGameUI.gameObject.SetActive(false);
	gameOverUI.gameObject.SetActive(false);
		
	}

	public void PlayButton() {

	if (hasGameStarted == true) {		
						StartCoroutine(StartGame(1.0f));
					}
	else {
	StartCoroutine(StartGame(0.0f));
}

				}

	public void PauseGame() {

	 	player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
	hasGameStarted = true;
		inMenuUI.gameObject.SetActive(true);
		inGameUI.gameObject.SetActive(false);
		gameOverUI.gameObject.SetActive(false);
	

			}
    public void HighScore() {
        	player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
      	inMenuUI.gameObject.SetActive(false);
		inGameUI.gameObject.SetActive(false);
		gameOverUI.gameObject.SetActive(false);
      
        
    }


	public void GameOver() {
		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
		hasGameStarted = true;
		inMenuUI.gameObject.SetActive(false);
		inGameUI.gameObject.SetActive(false);
		gameOverUI.gameObject.SetActive(true);
	if (hasSeenRewardedAd == true) {
		adButton.GetComponent<Image>().color = new Color (1, 1, 1, 0.5f);  
		adButton.GetComponent<Button>().enabled = false;
	}
}

    public void RestartGame() => SceneManager.LoadScene(0); //loads 0 index scene the one in building settings or whatever

	

	public IEnumerator StartGame(float waitTime) {
		
		inMenuUI.gameObject.SetActive(false);
		inGameUI.gameObject.SetActive(true);
		gameOverUI.gameObject.SetActive(false);
		yield return new WaitForSeconds(waitTime);
		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;


					}
}

