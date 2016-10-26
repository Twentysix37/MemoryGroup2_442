using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class reviewScript : MonoBehaviour {

	public Text battleResult;
	public Text User;
	public Text Computer;
	public Text Outcome;
	public int battleNum;
	public string userChoice;
	public string compChoice;
	public string result;
	public Queue userChoices = new Queue();
	public Queue compChoices = new Queue();
	public Queue results = new Queue();
	public int count;
	public Button back;


	// Use this for initialization
	void Start () {

		generateQueues();

		back = back.GetComponent<Button> ();

		//setText ();
	
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

	void setText (){

		battleResult.enabled = true;
		User.enabled = true;
		Computer.enabled = true;
		Outcome.enabled = true;
		count = 1;

		while (count != 5) {


			userChoice = userChoices.Dequeue ().ToString ();
			compChoice = compChoices.Dequeue ().ToString ();
			result = results.Dequeue ().ToString ();
			battleNum = count;

			if (count == 1) {
				battleResult.text = "Battle: " + battleNum + ": User: " + userChoice + ": Computer: " + compChoice + ": Result: " + result;
			} else if (count == 2) {
				User.text = "Battle: " + battleNum + ": User: " + userChoice + ": Computer: " + compChoice + ": Result: " + result;
			} else if (count == 3) {
				Computer.text = "Battle: " + battleNum + ": User: " + userChoice + ": Computer: " + compChoice + ": Result: " + result;
			} else if (count == 4) {
				Outcome.text = "Battle: " + battleNum + ": User: " + userChoice + ": Computer: " + compChoice + ": Result: " + result;
			}

			count = count + 1;

		}
	}

	public void loadScene(){

		SceneManager.LoadScene("Game");

	}
}
