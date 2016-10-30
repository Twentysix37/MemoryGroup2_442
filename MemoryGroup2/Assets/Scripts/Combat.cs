using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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
	List<string> Names = new List<string>();

	void Start(){
		Names.Add ("John");
		Names.Add ("Jacob");
		Names.Add ("Smith");
		Button1.GetComponentInChildren<Text>().text = Names[0];
		Button2.GetComponentInChildren<Text>().text = Names[1];
		Button3.GetComponentInChildren<Text>().text = Names[2];
	}

	public void CombatResult (int PlayerValue){
		
		Player.SetActive(false);
		EnemyValue = 0;

		//enemyani.SetBool ("Ani", false);
		//playerani.SetBool ("Ani", false);
		backgroundSprite = ResultText.GetComponentInParent<Image> ();
		if (PlayerValue > EnemyValue) {//EnemyValue) {
			
			Player = GameObject.Instantiate (Resources.Load ("Prefab/KnightAttack_0", typeof(GameObject))) as GameObject;
			playerSpriteRenderer = Player.GetComponent<SpriteRenderer>();
			playerani = playerSpriteRenderer.GetComponent<Animator> ();
			playerani.SetBool ("Ani", true);

			StartCoroutine( Waiting ("Win!"));

			//backgroundSprite.enabled = false;


		} else if (PlayerValue < EnemyValue) { //EnemyValue) {
			enemyani = Enemy.GetComponent<Animator> ();
			enemyani.SetBool ("Ani", true);

			StartCoroutine( Waiting ("Lose!"));
			//backgroundSprite.enabled = false;



		} else {
			
			Player = GameObject.Instantiate (Resources.Load ("Prefab/RedKnight", typeof(GameObject))) as GameObject;
			playerSpriteRenderer = Player.GetComponent<SpriteRenderer>();
			playerani = playerSpriteRenderer.GetComponent<Animator> ();
			playerani.SetBool ("Ani", true);

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
	}

