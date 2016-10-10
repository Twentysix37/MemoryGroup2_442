using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Combat : MonoBehaviour {
	public Text ResultText;
	public int PlayerValue;
	Image backgroundSprite;
	public SpriteRenderer Player;
	public SpriteRenderer Enemy;
	Animator playerani;
	Animator enemyani;

	public void CombatResult (int PlayerValue){
		//enemyani.SetBool ("Ani", false);
		//playerani.SetBool ("Ani", false);
		backgroundSprite = ResultText.GetComponentInParent<Image> ();
		if (PlayerValue > 0) {//EnemyValue) {
			playerani = Player.GetComponent<Animator> ();
			playerani.SetBool ("Ani", true);

			StartCoroutine( Waiting ("Win!"));

			//backgroundSprite.enabled = false;


		} else if (PlayerValue < 0) { //EnemyValue) {
			enemyani = Enemy.GetComponent<Animator> ();
			enemyani.SetBool ("Ani", true);

			StartCoroutine( Waiting ("Lose!"));
			//backgroundSprite.enabled = false;



		} else {
			playerani = Player.GetComponent<Animator> ();
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

