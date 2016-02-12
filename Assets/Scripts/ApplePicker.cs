using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {

	//TO FIX LIGHTNING ON RELOADING LEVEL GO TO WINDOW --> LIGHTING --> LIGHTMAP --> UNCHECK AUTO --> HIT BUILD


	public GameObject basketPrefab;

	public int numBaskets = 3;
	public List<GameObject> basketsList = new List<GameObject>();
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;

	private Text scoreText;
	private int score = 0;

	private Basket basketRef;

	private GameObject[] appleArr = new GameObject[3];

	private bool gameOver = false;

	private Text highScoreText;
	public static int highScore = 0;




	void Awake() {

		SetHighScorePref();

	}

	// Use this for initialization
	void Start () {

		InitializeScore();
		InstantiateBaskets();

	}
	
	// Update is called once per frame
	void Update () {

		GameOver();

		//TODO: PUT THIS IN A METHOD
		if(basketRef == null && gameOver != true) {
			//Gets basket script from top basket - top basket is the last element in the baskets GameObject array
			basketRef = basketsList[basketsList.Count-1].GetComponent<Basket>(); //GameObject.FindGameObjectWithTag("Basket").GetComponent<Basket>();
		}

		if(basketRef.addScore == true) {
			HandleScore();
			CalculateHighScore();
		}

		DisplayHighScore();

		

	}

	private void InstantiateBaskets() {

		for(int i = 0; i < numBaskets; i++) {
			GameObject tBasketGameObj = Instantiate(basketPrefab);
			basketsList.Add(tBasketGameObj);
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGameObj.transform.position = pos;

		}

	}

	private void HandleScore() {

		score = int.Parse(scoreText.text);
		score = score + 100;
		scoreText.text = score.ToString();
		
	}

	public void SubtractLife() {

		appleArr = GameObject.FindGameObjectsWithTag("Apple");
		foreach(GameObject apple in appleArr) {
			Destroy(apple);
		}

		int basketIndex = basketsList.Count-1;
		GameObject basketGameObj = basketsList[basketIndex];
		basketsList.RemoveAt(basketIndex);
		Destroy(basketGameObj);

	}

	private void GameOver() {
		
		if(basketsList.Count == 0) {
			gameOver = true;
			SceneManager.LoadScene("PlayScene");
		}

	}

	private void InitializeScore() {
		if(scoreText == null) {
			scoreText = GameObject.Find("ScoreCounter").GetComponent<Text>();
		}
		scoreText.text = "0";

	}

	private void CalculateHighScore() {
		if(score > highScore) {
			highScore = score;
		}

		if(highScore > PlayerPrefs.GetInt("ApplePickerHighScore")) {
			PlayerPrefs.SetInt("ApplePickerHighScore", highScore);
		}
	}
	
	private void DisplayHighScore() {
		if(highScoreText == null) {
			highScoreText = GameObject.Find("HighScoreCounter").GetComponent<Text>();
		}
		highScoreText.text = "High score: " + highScore;
	}

	private void SetHighScorePref() {
		if(PlayerPrefs.HasKey("ApplePickerHighScore")) {
			highScore = PlayerPrefs.GetInt("ApplePickerHighScore");
		}
		PlayerPrefs.SetInt("ApplePickerHighScore", highScore);
	}
}
