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
	List<string> Names = new List<string>();

	void Start(){
		GameObject selectionCanvas = GameObject.Find ("Player Selection Canvas1");
		selectionScript2 selScript = selectionCanvas.GetComponent <selectionScript2> ();
		List<string> playerNames = new List<string>();
		var keyCollection = selScript.playerDict.Keys;
		foreach (var key in keyCollection) {
			playerNames.Add (key);
		}

		Names.Add (playerNames[0]);
		Names.Add (playerNames[1]);
		Names.Add (playerNames[2]);
		Button1.GetComponentInChildren<Text>().text = Names[0];
		Button2.GetComponentInChildren<Text>().text = Names[1];
		Button3.GetComponentInChildren<Text>().text = Names[2];
	}

	public void CombatResult (int PlayerValue){
		
		Player.SetActive(false);
		Enemy.SetActive (false);
		EnemyValue = 0;

		//enemyani.SetBool ("Ani", false);
		//playerani.SetBool ("Ani", false);
		backgroundSprite = ResultText.GetComponentInParent<Image> ();
		if (PlayerValue > EnemyValue) {//EnemyValue) {
			
			Player = GameObject.Instantiate (Resources.Load ("Prefab/KnightAttack_0", typeof(GameObject))) as GameObject;
			playerSpriteRenderer = Player.GetComponent<SpriteRenderer>();
			playerani = playerSpriteRenderer.GetComponent<Animator> ();
			playerani.SetBool ("Ani", true);

			Enemy = GameObject.Instantiate (Resources.Load ("Prefab/OrckAttack_0", typeof(GameObject))) as GameObject;
			enemySpriteRenderer = Enemy.GetComponent<SpriteRenderer>();
			enemyani = Enemy.GetComponent<Animator> ();

			StartCoroutine( Waiting ("Win!"));

			//backgroundSprite.enabled = false;


		} else if (PlayerValue < EnemyValue) { //EnemyValue) {
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
	}

	IEnumerator Waiting (string text){
		yield return new WaitForSecondsRealtime(1.5f);
		ResultText.text = text;

		backgroundSprite.enabled = true;
		playerani.SetBool ("Ani", false);
		enemyani.SetBool ("Ani", false);

		}

	public void loadLastScene(){

		SceneManager.LoadScene("Game");

	}
	}

