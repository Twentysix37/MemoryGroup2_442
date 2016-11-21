using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Combat : MonoBehaviour {
	public Text ResultText;
	public int PlayerValue;
	public int EnemyValue;
	public GameObject Button1;
	public GameObject Button2;
	public GameObject Button3;
	Image backgroundSprite;
	public GameObject Player;
	//public SpriteRenderer Player;
	public GameObject Enemy;
	//public SpriteRenderer Enemy;
	SpriteRenderer playerSpriteRenderer;
	SpriteRenderer enemySpriteRenderer;
	Animator playerani;
	Animator enemyani;
	public Button Back;
	int counter = 0;
	List<string> Names = new List<string>();
	List<string> Values = new List<string>();
	List<string> cpuNames = new List<string>();
	List<string> cpuValues = new List<string>();
	List<string> playerNames = new List<string> ();
	List<string> playerValues = new List<string> ();
	List<string> enemyNames = new List<string> ();
	List<string> enemyValues = new List<string> ();

	void Start(){
		GameObject selectionCanvas = GameObject.Find ("Player Selection Canvas1");
		selectionCanvas.SetActive(false);
		selectionScript2 selScript = selectionCanvas.GetComponent <selectionScript2> ();


		var keyCollection = selScript.playerDict.Keys;
		foreach (var key in keyCollection) {
			playerNames.Add (key);
		}

		var valueCollection = selScript.playerDict.Values;
		foreach (var val in valueCollection) {
			playerValues.Add (val);
		}

		var keyEnemyCollection = selScript.computerDict.Keys;
		foreach (var key in keyEnemyCollection) {
			enemyNames.Add (key);
		}

		var valueEnemyCollection = selScript.computerDict.Values;
		foreach (var val in valueEnemyCollection) {
			enemyValues.Add (val);
		}

		Names.Add (playerNames[0]);
		Names.Add (playerNames[1]);
		Names.Add (playerNames[2]);
		cpuNames.Add (enemyNames [0]);
		cpuNames.Add(enemyNames[1]);
		cpuNames.Add(enemyNames[2]);

		Values.Add (playerValues [0]);
		Values.Add (playerValues [1]);
		Values.Add (playerValues [2]);
		cpuValues.Add(enemyValues [0]);
		cpuValues.Add(enemyValues [1]);
		cpuValues.Add(enemyValues [2]);

//		Button1.GetComponentInChildren<Text>().text = Names[0];
//		Button2.GetComponentInChildren<Text>().text = Names[1];
//		Button3.GetComponentInChildren<Text>().text = Names[2];
	}


	public void CombatResult (int PlayerValue){
		
		Player.SetActive(false);
		Enemy.SetActive (false);


		//enemyani.SetBool ("Ani", false);
		//playerani.SetBool ("Ani", false);
		backgroundSprite = ResultText.GetComponentInParent<Image> ();
		if ((int.Parse(Values[PlayerValue]) + (int.Parse(cpuValues[counter]))) <= 800) {//EnemyValue) {
			counter++;
			
			Player = GameObject.Instantiate (Resources.Load ("Prefab/KnightAttack_0", typeof(GameObject))) as GameObject;
			playerSpriteRenderer = Player.GetComponent<SpriteRenderer>();
			playerani = playerSpriteRenderer.GetComponent<Animator> ();
			playerani.SetBool ("Ani", true);

			Enemy = GameObject.Instantiate (Resources.Load ("Prefab/OrckAttack_0", typeof(GameObject))) as GameObject;
			enemySpriteRenderer = Enemy.GetComponent<SpriteRenderer>();
			enemyani = Enemy.GetComponent<Animator> ();

			StartCoroutine( Waiting ("Win!"));

			//backgroundSprite.enabled = false;


		} else if ((int.Parse(Values[PlayerValue]) + (int.Parse(cpuValues[counter]))) >= 1300) { //EnemyValue) {
			counter++;
			Player = GameObject.Instantiate (Resources.Load ("Prefab/KnightAttack_0", typeof(GameObject))) as GameObject;
			playerSpriteRenderer = Player.GetComponent<SpriteRenderer>();
			playerani = playerSpriteRenderer.GetComponent<Animator> ();

			Enemy = GameObject.Instantiate (Resources.Load ("Prefab/OrckAttackBlack_0", typeof(GameObject))) as GameObject;
			enemySpriteRenderer = Enemy.GetComponent<SpriteRenderer>();
			enemyani = Enemy.GetComponent<Animator> ();
			enemyani.SetBool ("Ani", true);

			StartCoroutine( Waiting ("Lose!"));
			//backgroundSprite.enabled = false;



		} else {
			counter++;
			Player = GameObject.Instantiate (Resources.Load ("Prefab/RedKnight", typeof(GameObject))) as GameObject;
			playerSpriteRenderer = Player.GetComponent<SpriteRenderer>();
			playerani = playerSpriteRenderer.GetComponent<Animator> ();
			playerani.SetBool ("Ani", true);

			Enemy = GameObject.Instantiate (Resources.Load ("Prefab/OrckAttack_0", typeof(GameObject))) as GameObject;
			enemySpriteRenderer = Enemy.GetComponent<SpriteRenderer>();
			enemyani = Enemy.GetComponent<Animator> ();
			enemyani.SetBool ("Ani", true);

			StartCoroutine( Waiting ("Draw..."));
			//backgroundSprite.enabled = false;

		}
		if (counter == 3) {
			StartCoroutine(waitNextScene ());
		}
	}

	IEnumerator Waiting (string text){
		yield return new WaitForSecondsRealtime(1.5f);
		ResultText.text = text;

		backgroundSprite.enabled = true;
		playerani.SetBool ("Ani", false);
		enemyani.SetBool ("Ani", false);

		}
	IEnumerator waitNextScene (){
		yield return new WaitForSecondsRealtime(2.5f);
		loadNextScene ();
	}

	public void loadLastScene(){

		SceneManager.LoadScene("Selection V3");

	}

	public void loadNextScene(){

		SceneManager.LoadScene("Review");

	}

	}

