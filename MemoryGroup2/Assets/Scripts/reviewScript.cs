using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class reviewScript : MonoBehaviour {

	public Text battleResult;
	public Queue userChoices = new Queue();
	public Queue compChoices = new Queue();
	public Queue results = new Queue();
	public Button Back;
	public Button Main;



	// Use this for initialization
	void Start () {

		GameObject combatEventSystem = GameObject.Find ("character button");
		Combat combatScript = combatEventSystem.GetComponent <Combat> ();
		combatEventSystem.SetActive (false);

		List<string> results = combatScript.reviewList;

		//generateQueues();

		Back = GetComponent<Button> ();
		Main = GetComponent<Button> ();
		//battleResult.text = "string";

		setText (results);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void generateQueues(){

		userChoices.Enqueue ("Frank");
		userChoices.Enqueue ("Joe");
		userChoices.Enqueue ("Steve");
		userChoices.Enqueue ("Bob");
		compChoices.Enqueue ("Bob");
		compChoices.Enqueue ("Joe");
		compChoices.Enqueue ("Frank");
		compChoices.Enqueue ("Steve");
		results.Enqueue ("Win");
		results.Enqueue ("Draw");
		results.Enqueue ("Lose");
		results.Enqueue ("Lose");
	}

	public void setText (List<string> resultText){

		/*int battleNum;
		int count;
		string userChoice;
		string compChoice;
		string result;*/
		string strOne = "";
		int battles = resultText.Count;

		/*
		userChoice = userChoices.Dequeue ().ToString ();
		compChoice = compChoices.Dequeue ().ToString ();
		result = results.Dequeue ().ToString ();
		battleNum = 1;
		strOne = "Battle: " + battleNum.ToString() + " User: " + userChoice + " Computer: " + compChoice + " Result: " + result;
		*/

		for (int i = 0; i < resultText.Count; i++) {
			strOne = strOne + "\n\n" + resultText [i];
		}

		/*
		while (count < battles) {


			userChoice = userChoices.Dequeue ().ToString ();
			compChoice = compChoices.Dequeue ().ToString ();
			result = results.Dequeue ().ToString ();
			battleNum = count;
			strOne = strOne + "\nBattle: " + battleNum.ToString() + " User: " + userChoice + " Computer: " + compChoice + " Result: " + result; 

			if (count == 1) {
				//battleResult.text = strOne;
				battleResult.text = strOne;
			} else if (count == 2) {
				User.text = "Battle: " + battleNum + " User: " + userChoice + " Computer: " + compChoice + " Result: " + result;
			} else if (count == 3) {
				Computer.text = "Battle: " + battleNum + " User: " + userChoice + " Computer: " + compChoice + " Result: " + result;
			} else if (count == 4) {
				Outcome.text = "Battle: " + battleNum + " User: " + userChoice + " Computer: " + compChoice + " Result: " + result;
			}

			count = count + 1;

		}
		*/
	
		battleResult.text = strOne;
	}

	public void loadLastScene(){

		SceneManager.LoadScene("Selection V3");

	}

	public void loadMain(){

		SceneManager.LoadScene ("Title");
	}
}
