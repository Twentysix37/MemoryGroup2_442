using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class buttonCombat : MonoBehaviour {

	public Dictionary<string, string> testDict;
	public Sprite imageOne;
	public Sprite imageTwo;
	public Sprite imageThree;
	public Sprite imageFour;
	public Sprite imageFive;
	public Sprite imageSix;
	public Image playerImage1;
	public Image playerImage2;
	public Image playerImage3;
	public Image computerImage1;
	public Image computerImage2;
	public Image computerImage3;
	public Text playerOne;
	public Text playerTwo;
	public Text playerThree;
	public Text computerOne;
	public Text computerTwo;
	public Text computerThree;
	public Text playerOneValue;
	public Text playerTwoValue;
	public Text playerThreeValue;
	public Text computerOneValue;
	public Text computerTwoValue;
	public Text computerThreeValue;
	public int total;
	public int fighterOne;
	public int fighterTwo;
	public Text Winner;
	public Button playerButton1;
	public Button playerButton2;
	public Button playerButton3;
	public Button computerButton1;
	public Button computerButton2;
	public Button computerButton3;
	public string playerOneString;
	public string playerTwoString;
	public string playerThreeString;
	public string computerOneString;
	public string computerTwoString;
	public string computerThreeString;
	public Button Disabling;




	// Use this for initialization
	void Start () {
		testDict = new Dictionary<string, string>();
		playerImage1.GetComponent<Image> ().sprite = imageOne;
		playerImage2.GetComponent<Image> ().sprite = imageTwo;
		playerImage3.GetComponent<Image> ().sprite = imageThree;
		computerImage1.GetComponent<Image> ().sprite = imageFour;
		computerImage2.GetComponent<Image> ().sprite = imageFive;
		computerImage3.GetComponent<Image> ().sprite = imageSix;
		playerButton1 = playerButton1.GetComponent<Button> ();
		playerButton2 = playerButton2.GetComponent<Button> ();
		playerButton3 = playerButton3.GetComponent<Button> ();
		Disabling = Disabling.GetComponent<Button> ();
		computerButton1 = computerButton1.GetComponent<Button> ();
		computerButton2 = computerButton2.GetComponent<Button> ();
		computerButton3 = computerButton3.GetComponent<Button> ();
		testDict.Add ("Joe","545");
		testDict.Add ("Max","303");
		testDict.Add ("Ian","985");
		Buttonupdate ();
		total = 0;
	}

	public void Buttonupdate(){
		int count = 0;
		foreach (string pair in testDict.Keys) {//use player dictionary
			if (count == 0) {
				playerOne.text = pair;
				playerOneValue.text = testDict [pair];
			} else if (count == 1) {
				playerTwo.text = pair;
				playerTwoValue.text = testDict [pair];
			} else if (count == 2) {
				playerThree.text =  pair;
				playerThreeValue.text = testDict [pair];
			}
			count = count + 1;
		}
		count = 0;
		foreach (string pair in testDict.Keys) {//use computer dictionary
			if (count == 0) {
				computerOne.text = pair;
				computerOneValue.text = testDict [pair];
			} else if (count == 1) {
				computerTwo.text =  pair;
				computerTwoValue.text = testDict [pair];
			} else if (count == 2) {
				computerThree.text =  pair;
				computerThreeValue.text = testDict [pair];
			}
			count = count + 1;
		}
		characterStrings ();
	}

	public void cantClick(Button choosen, Text t){
		choosen.enabled = false;
		choosen.GetComponentInChildren<Text> ().text = "-";
		t.text = "-";
	}
	public void characterStrings(){//scope of character names are throughout the whole code
		playerOneString = playerOne.text;
		playerTwoString = playerTwo.text;
		playerThreeString = playerThree.text;
		computerOneString = computerOne.text;
		computerTwoString = computerTwo.text;
		computerThreeString = computerThree.text;
	}


	public void decision(string characterText1, string characterText2, Button characterButton1, Button characterButton2, string result){
		if (result == "death1") {
			characterButton2.GetComponentInChildren<Text> ().text = characterText2;
			characterButton2.enabled = true;
		} else if (result == "death2") {
			characterButton1.GetComponentInChildren<Text> ().text = characterText1;
			characterButton1.enabled = true;
		} else if (result == "draw") {
			characterButton1.GetComponentInChildren<Text> ().text = characterText1;
			characterButton2.GetComponentInChildren<Text> ().text = characterText2;
			characterButton1.enabled = true;
			characterButton2.enabled = true;
		}
		
	}

	int disableCount=0;
	public void disableButton(){
		if (disableCount % 2 == 0) {
			playerOneValue.text = "-";
			playerTwoValue.text = "-";
			playerThreeValue.text = "-";
			computerOneValue.text = "-";
			computerTwoValue.text = "-";
			computerThreeValue.text = "-";
		} else {
				playerOneValue.text = testDict [playerOneString];
				playerTwoValue.text = testDict [playerTwoString];
				playerThreeValue.text = testDict [playerThreeString];
				computerOneValue.text = testDict [computerOneString];
				computerTwoValue.text = testDict [computerTwoString];
				computerThreeValue.text = testDict [computerThreeString];
		}
		disableCount = disableCount + 1;
	}
	//TESTING FOR MY METHODS
	public void buttonOne(){
		cantClick (playerButton1, playerOneValue);
		decision ("rony","rony2", playerButton1, playerButton2,"death1");

	}
	public void buttonTwo(){
		cantClick (playerButton2, playerTwoValue);
		
	}
	public void buttonThree(){
		cantClick (playerButton3, playerThreeValue);
		
	}
	public void buttonFour(){
		cantClick (computerButton1, computerOneValue);

	}
	public void buttonFive(){
		cantClick (computerButton2, computerTwoValue);

	}
	public void buttonSix(){
		cantClick (computerButton3, computerThreeValue);

	}
}
