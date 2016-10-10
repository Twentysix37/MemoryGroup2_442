using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class selectionScript2 : MonoBehaviour {

	public Button characterOne;
	public Button characterTwo;
	public Button characterThree;
	public Canvas selectionScene;
	public Canvas valueCanvas;
	public Dictionary<string, List<string>> theHash;
	public Dictionary<string, string> computerDict;
	public Dictionary<string, string> playerDict;
	public Image spawnCharacter;
	public string characterOneString;
	public string characterTwoString;
	public string characterThreeString;
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
	public Text computerCharacter1;
	public Text computerCharacter2;
	public int CharacterPanelcount;

	// Use this for initialization
	void Start () {
		characterOne = characterOne.GetComponent<Button> ();
		characterTwo = characterTwo.GetComponent<Button> ();
		characterThree = characterThree.GetComponent<Button> ();
		selectionScene = selectionScene.GetComponent<Canvas> ();
		valueCanvas = valueCanvas.GetComponent<Canvas> ();
		theHash = new Dictionary<string, List<string>>();
		computerDict = new Dictionary<string, string>();
		playerDict = new Dictionary<string, string>();
		valueCanvas.enabled = false;
		characterOneString = "";
		characterTwoString = "";
		characterThreeString = "";
		playerOneCounter = 0;
		playerTwoCounter = 0;
		buttonText ();
		counter = 0;

	}

	public void generateMap(){//generates dictionary for starting selection phase
		theHash.Add("Frank", generateValue());
		theHash.Add("Joe", generateValue());
		theHash.Add("Billybob", generateValue());
	}

	public List<string> generateValue(){//generates value for static map
		List<string> generator = new List<string> ();
		generator.Add ("1");
		generator.Add ("2");
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
			}
			count = count + 1;
		}
	}
	public void turnText(){
		turnPlayer.enabled = true;
		if (counter % 2 == 0) {
			turnPlayer.text = "Player One's Turn";
		} else {
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

		} else {
			computerDict.Add (characterOneString,"");
		}
			
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

		} else {
			computerDict.Add (characterTwoString,"");
		}

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

		} else {
			computerDict.Add (characterThreeString,"");
		}

		//change the image to the character name
		//add the character/value to dictionary depending on the turn

	}



	public void valueText(List<string> values){
		int valueCounter = 0;
		valueCanvas.enabled = true;
		foreach (string str in values) {//value button text is made by looping threw the list of the dictionary
			if (valueCounter == 0) {
				valueOne.text = str;
			} else if (valueCounter == 1) {
				valueTwo.text = str;
			}
			valueCounter = valueCounter + 1;
		}
	}



	public void valueOnePress(){
		valueCanvas.enabled = false;
		value4One = "1";
		playerDict [currentCharacter] = value4One;
		characterUpdate ();


		//store into a map
	}

	public void valueTwoPress(){
		valueCanvas.enabled = false;
		value4One = "2";
		playerDict [currentCharacter] = value4One;
		characterUpdate ();
		//store into a map
	}

	public void characterUpdate(){
		if (CharacterPanelcount == 0) {
			playeroneCharacter1.text = currentCharacter + " Value: " + playerDict [currentCharacter];
		} else if (CharacterPanelcount == 1) {
			computerCharacter1.text = currentCharacter + " Value: " + playerDict [currentCharacter];
		} else if (CharacterPanelcount == 2) {
			playeroneCharacter2.text = currentCharacter + " Value: " + playerDict [currentCharacter];
		} else if (CharacterPanelcount == 3) {
			computerCharacter2.text = currentCharacter + " Value: " + playerDict [currentCharacter];
		}
		CharacterPanelcount = CharacterPanelcount + 1;
		turnText ();
	}







}
