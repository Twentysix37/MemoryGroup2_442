using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class selectionScript2 : MonoBehaviour {

	public Button Exit;
	public Button characterOne;
	public Button characterTwo;
	public Button characterThree;
	public Button characterFour;
	public Button characterFive;
	public Button characterSix;
	public Canvas selectionScene;
	public Canvas valueCanvas;
	public static Dictionary<string, List<string>> theHash;
	public Dictionary<string, string> computerDict;
	public Dictionary<string, string> playerDict;
	public Image spawnCharacter;
	public string characterOneString;
	public string characterTwoString;
	public string characterThreeString;
	public string characterFourString;
	public string characterFiveString;
	public string characterSixString;
	public string value4Map;
	public Text valueOne;
	public Text valueTwo;
	public Text turnPlayer;
	public Text turnComp;
	public int counter;
	public string valueMap;
	public string value4One;
	public string value4Two;
	public int playerOneCounter;
	public int playerTwoCounter;
	string currentCharacter;
	public Text playeroneCharacter1;
	public Text playeroneCharacter2;
	public Text playeroneCharacter3;
	public Text computerCharacter1;
	public Text computerCharacter2;
	public Text computerCharacter3;
	public int CharacterPanelcount;
	public Button startButton;
	public bool turn;


	void Start () {
		startButton = startButton.GetComponent<Button> ();
		characterOne = characterOne.GetComponent<Button> ();
		characterTwo = characterTwo.GetComponent<Button> ();
		characterThree = characterThree.GetComponent<Button> ();
		characterFour = characterFour.GetComponent<Button> ();
		characterFive = characterFive.GetComponent<Button> ();
		characterSix = characterSix.GetComponent<Button> ();
		selectionScene = selectionScene.GetComponent<Canvas> ();
		valueCanvas = valueCanvas.GetComponent<Canvas> ();
		theHash = new Dictionary<string, List<string>>();
		computerDict = new Dictionary<string, string>();
		playerDict = new Dictionary<string, string>();
		valueCanvas.enabled = false;
		startButton.enabled = false;
		characterOneString = "";
		characterTwoString = "";
		characterThreeString = "";
		playerOneCounter = 0;
		playerTwoCounter = 0;
		buttonText ();
		counter = 0;
		turn = true;

	}

	public void Awake(){
		DontDestroyOnLoad (this);
	}

	public void exitMain(){
		SceneManager.LoadScene ("Title");
	}
	public void startCombat(){
		SceneManager.LoadScene ("Game"); //Last character Choosen
	}

	public void generateMap(){//generates dictionary for starting selection phase
		theHash.Add("Frank", generateValue());
		theHash.Add("Joe", generateValue());
		theHash.Add("Billybob", generateValue());
		theHash.Add ("Mike", generateValue ());
		theHash.Add ("Jimmy", generateValue ());
		theHash.Add ("Rony", generateValue ());

	}

	public List<string> generateValue(){//generates value for static map
		List<string> generator = new List<string> ();
		generator.Add (""+Random.Range(200,800));
		generator.Add (""+Random.Range(200,800));
		return generator;
	}

	public void buttonText(){//updates text for buttons character name
		turnText ();
		generateMap();
		int count = 0;
		foreach (string pair in theHash.Keys) {
			if (count == 0) {
				characterTwo.GetComponentInChildren<Text> ().text = pair;
				characterOneString = pair;
			} else if (count == 1) {
				characterOne.GetComponentInChildren<Text> (). text = pair;
				characterTwoString = pair;
			} else if (count == 2) {
				characterThree.GetComponentInChildren<Text> ().text = pair;
				characterThreeString = pair;
			} else if (count == 3) {
				characterFour.GetComponentInChildren<Text> ().text = pair;
				characterFourString = pair;
			} else if (count == 4) {
				characterFive.GetComponentInChildren<Text> ().text = pair;
				characterFiveString = pair;
			}  else if (count == 5) {
				characterSix.GetComponentInChildren<Text> ().text = pair;
				characterSixString = pair;
			} 
			count = count + 1;
		}
	}
	public void turnText(){
		turnPlayer.enabled = true;
		if (counter % 2 == 0) {
			turn = true;
			turnPlayer.text = "Player One's Turn";
		} else {
			turn = false;
			turnPlayer.text = "Computers Turn";
		}
	}
	public void characterOnePress(){
		currentCharacter = characterOneString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterOneString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterOneString,"");

		}
		characterOne.enabled = false;
		characterTwo.enabled = false; //This
		characterThree.enabled = false;
		characterFour.enabled = false;
		characterFive.enabled = false;
		characterSix.enabled = false;

		characterTwo.GetComponentInChildren<Text> ().text = "-";
		//change the image to the character name
		//add the character/value to dictionary depending on the turn
	}

	public void characterTwoPress(){
		currentCharacter = characterTwoString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterTwoString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterTwoString,"");

		}
		characterOne.enabled = false; // This
		characterTwo.enabled = false;
		characterThree.enabled = false;
		characterFour.enabled = false;
		characterFive.enabled = false;
		characterSix.enabled = false;
		characterOne.GetComponentInChildren<Text> ().text = "-";
		//change the image to the character name
		//add the character/value to dictionary depending on the turn

	}

	public void characterThreePress(){
		currentCharacter = characterThreeString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterThreeString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterThreeString,"");

		}
		characterOne.enabled = false;
		characterTwo.enabled = false;
		characterThree.enabled = false; //This
		characterFour.enabled = false;
		characterFive.enabled = false;
		characterSix.enabled = false;
		characterThree.GetComponentInChildren<Text> ().text = "-";
		//change the image to the character name
		//add the character/value to dictionary depending on the turn

	}

	public void characterFourPress(){
		currentCharacter = characterFourString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterFourString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterFourString,"");
		}
		//change the image to the character name
		//add the character/value to dictionary depending on the turn
		characterOne.enabled = false;
		characterTwo.enabled = false;
		characterThree.enabled = false;
		characterFour.enabled = false;
		characterFive.enabled = false;
		characterSix.enabled = false;
		characterFour.GetComponentInChildren<Text> ().text = "-";
	}

	public void characterFivePress(){
		currentCharacter = characterFiveString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterFiveString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterFiveString,"");

		} 
		characterOne.enabled = false;
		characterTwo.enabled = false;
		characterThree.enabled = false;
		characterFour.enabled = false;
		characterFive.enabled = false;
		characterSix.enabled = false;
		characterFive.GetComponentInChildren<Text> ().text = "-";
		//change the image to the character name
		//add the character/value to dictionary depending on the turn
	}

	public void characterSixPress(){
		currentCharacter = characterSixString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterSixString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterSixString,"");

		} 
		characterOne.enabled = false;
		characterTwo.enabled = false;
		characterThree.enabled = false;
		characterFour.enabled = false;
		characterFive.enabled = false;
		characterSix.enabled = false;//This
		characterSix.GetComponentInChildren<Text> ().text = "-";
		//change the image to the character name
		//add the character/value to dictionary depending on the turn
	}
		
	public void valueText(List<string> values){
		int valueCounter = 0;
		valueCanvas.enabled = true;
		foreach (string str in values) {//value button text is made by looping threw the list of the dictionary
			if (valueCounter == 0) {
				valueOne.text = str;
				value4One = str;
			} else if (valueCounter == 1) {
				valueTwo.text = str;
				value4Two = str;
			}
			valueCounter = valueCounter + 1;
		}
	}

	public void valueOnePress(){
		valueCanvas.enabled = false;
		playerDict [currentCharacter] = value4One;
		characterUpdate ();
		characterUpdate (); //for computer
		//store into a map
		 if (characterOne.GetComponentInChildren<Text> ().text != "-") {
			characterOne.enabled = true;
		}
		if (characterTwo.GetComponentInChildren<Text> ().text != "-") {
			characterTwo.enabled = true;
		}
		if (characterThree.GetComponentInChildren<Text> ().text != "-") {
			characterThree.enabled = true;
		}
		if (characterFour.GetComponentInChildren<Text> ().text != "-") {
			characterFour.enabled = true;
		}
		if (characterFive.GetComponentInChildren<Text> ().text != "-") {
			characterFive.enabled = true;
		}
		if (characterSix.GetComponentInChildren<Text> ().text != "-") {
			characterSix.enabled = true;
		}
	}

	public void valueTwoPress(){
		valueCanvas.enabled = false;
		playerDict [currentCharacter] = value4Two;
		characterUpdate ();
		characterUpdate (); //for computer
		//store into a map
		if (characterOne.GetComponentInChildren<Text> ().text != "-") {
			characterOne.enabled = true;
		} 
		if (characterTwo.GetComponentInChildren<Text> ().text != "-") {
			characterTwo.enabled = true;
		} 
		if (characterThree.GetComponentInChildren<Text> ().text != "-") {
			characterThree.enabled = true;
		} 
		if (characterFour.GetComponentInChildren<Text> ().text != "-") {
			characterFour.enabled = true;
		} 
		if (characterFive.GetComponentInChildren<Text> ().text != "-") {
			characterFive.enabled = true;
		} 
		if (characterSix.GetComponentInChildren<Text> ().text != "-") {
			characterSix.enabled = true;
		}
	}

	public void characterUpdate(){

		string computerSelectionPhase;
		if (CharacterPanelcount == 0) {
			playeroneCharacter1.text = currentCharacter + " Value: " + playerDict [currentCharacter];
		} else if (CharacterPanelcount == 1) {
			computerSelectionPhase = computerChoice (characterTwo, characterOne, characterThree, characterFour, characterFive, characterSix);
			computerCharacter1.text = computerSelectionPhase + " Value: " + computerDict [computerSelectionPhase];
		} else if (CharacterPanelcount == 2) {
			playeroneCharacter2.text = currentCharacter + " Value: " + playerDict [currentCharacter];
		} else if (CharacterPanelcount == 3) {
			computerSelectionPhase = computerChoice (characterTwo, characterOne, characterThree, characterFour, characterFive, characterSix);
			computerCharacter2.text = computerSelectionPhase + " Value: " + computerDict [computerSelectionPhase];
		} else if (CharacterPanelcount == 4) {
			playeroneCharacter3.text = currentCharacter + " Value: " + playerDict [currentCharacter];
		} else if (CharacterPanelcount == 5) {
			computerSelectionPhase = computerChoice (characterTwo, characterOne, characterThree, characterFour, characterFive, characterSix);
			computerCharacter3.text = computerSelectionPhase + " Value: " + computerDict [computerSelectionPhase];
			startButton.enabled = true;

		}
		turnText ();
		if (CharacterPanelcount == 5) {
			turnPlayer.text = "Press Start";
		}
		CharacterPanelcount = CharacterPanelcount + 1;

	}


	public string computerChoice(Button charOne, Button charTwo, Button charThree, Button charFour, Button charFive, Button charSix){
		List<string> temp = new List<string>();

		string tempCharacter = charOne.GetComponentInChildren<Text> ().text;
		if (tempCharacter != "-") {
			temp.Add (tempCharacter);
		}
		string tempCharacter1 = charTwo.GetComponentInChildren<Text> ().text;
		if (tempCharacter1 != "-") {
			temp.Add (tempCharacter1);
		}
		string tempCharacter2 = charThree.GetComponentInChildren<Text> ().text;
		if (tempCharacter2 != "-") {
			temp.Add (tempCharacter2);
		}
		string tempCharacter3 = charFour.GetComponentInChildren<Text> ().text;
		if (tempCharacter3 != "-") {
			temp.Add (tempCharacter3);
		}
		string tempCharacter4 = charFive.GetComponentInChildren<Text> ().text;
		if (tempCharacter4 != "-") {
			temp.Add (tempCharacter4);
		}
		string tempCharacter5 = charSix.GetComponentInChildren<Text> ().text;
		if (tempCharacter5 != "-") {
			temp.Add (tempCharacter5);
		}
		int listSize = temp.Count;
		int listLocation = Random.Range (0, listSize-1);
		List<string> listValue = theHash[temp[listLocation]];
		int listValueSize = listValue.Count;
		int listLocation2 = Random.Range (0, listValueSize-1);
		computerDict.Add(temp[listLocation], listValue[listLocation2]);
		if(tempCharacter == temp[listLocation]){
			charOne.GetComponentInChildren<Text> ().text = "-";
		}
		if(tempCharacter1 == temp[listLocation]){
			charTwo.GetComponentInChildren<Text> ().text = "-";
		}
		if(tempCharacter2 == temp[listLocation]){
			charThree.GetComponentInChildren<Text> ().text = "-";
		}
		if(tempCharacter3 == temp[listLocation]){
			charFour.GetComponentInChildren<Text> ().text = "-";
		}
		if(tempCharacter4 == temp[listLocation]){
			charFive.GetComponentInChildren<Text> ().text = "-";
		}
		if(tempCharacter5 == temp[listLocation]){
			charSix.GetComponentInChildren<Text> ().text = "-";
		}
		return temp [listLocation];
	}

	public Dictionary<string, string> dictionaryCPU(){
		return computerDict;
	}

	public Dictionary<string, string> dictionaryP1(){
		return playerDict;
	}







}
