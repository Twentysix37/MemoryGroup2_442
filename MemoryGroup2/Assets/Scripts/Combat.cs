using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Combat : MonoBehaviour {
	public Text ResultText;
	public int PlayerValue;
	public int EnemyValue;
	public Dictionary<string,string> playerd;
	public Dictionary<string,string> computerd;
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
	public List<string> reviewList = new List<string>();
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
	public Text Versus;
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
	public int total;
	public int drawCounter = 0;
	public int lostCounter = 0;
	public int enemyCounter = 0;
	List<int> randomEnemy = new List<int> ();



	public void Awake(){
		DontDestroyOnLoad (this);
	}


	void Start(){
		
		randomEnemy.Add (0);
		randomEnemy.Add (1);
		randomEnemy.Add (2);
		playerd = new Dictionary<string,string> ();
		computerd = new Dictionary<string,string> ();
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

		playerd.Add (playerNames [0], playerValues [0]);
		playerd.Add (playerNames [1], playerValues [1]);
		playerd.Add (playerNames [2], playerValues [2]);
		computerd.Add (enemyNames [0], enemyValues [0]);
		computerd.Add (enemyNames [1], enemyValues [1]);
		computerd.Add (enemyNames [2], enemyValues [2]);

		playerButton1 = playerButton1.GetComponent<Button> ();
		playerButton2 = playerButton2.GetComponent<Button> ();
		playerButton3 = playerButton3.GetComponent<Button> ();

		computerButton1 = computerButton1.GetComponent<Button> ();
		computerButton2 = computerButton2.GetComponent<Button> ();
		computerButton3 = computerButton3.GetComponent<Button> ();
		Buttonupdate ();
		total = 0;

//		Button1.GetComponentInChildren<Text>().text = Names[0];
//		Button2.GetComponentInChildren<Text>().text = Names[1];
//		Button3.GetComponentInChildren<Text>().text = Names[2];
	}

	void getRandomEnemy(){
		int temp = Random.Range (0, 2);
		if(randomEnemy.Contains(temp)){
			return temp;
		} return 0;
			} 

	public void buttonOne(){
		playerButton1.enabled = false;
		cantClick (playerButton1, playerOneValue);
		int j = CombatResult (0);
		if (j==1){//==2) {
			decision (playerOneString,playerOneValue,computerOneValue,computerOneString,playerButton1,computerButton1,"death2");
		} else 	if (j==2){//==2) {
			decision (playerOneString,playerOneValue, computerOneValue,computerOneString,playerButton1,computerButton1,"death1");
		}  else if (j==3){//==2) {
			decision (playerOneString,playerOneValue, computerOneValue,computerOneString,playerButton1,computerButton1,"draw");
		}
		//decision ("rony","rony2", playerButton1, playerButton2,"death1");

	}
	public void buttonTwo(){
		playerButton2.enabled = false;
		cantClick (playerButton2, playerTwoValue);
		int j = CombatResult (1);
		if (j==1){//==2) {
			decision (playerTwoString,playerTwoValue,computerTwoValue,computerTwoString,playerButton2,computerButton2,"death2");
		} else 	if (j==2){//==2) {
			decision (playerTwoString,playerTwoValue,computerTwoValue,computerTwoString,playerButton2,computerButton2,"death1");
		}  else if (j==3){//==2) {
			decision (playerTwoString,playerTwoValue,computerTwoValue,computerTwoString,playerButton2,computerButton2,"draw");
		}

	}
	public void buttonThree(){
		playerButton3.enabled = false;
		cantClick (playerButton3, playerThreeValue);

		int j = CombatResult (2);
		if (j==1){//==2) {
			decision (playerThreeString,playerThreeValue,computerThreeValue,computerThreeString,playerButton3,computerButton3,"death2");
		} else 	if (j==2){//==2) {
			decision (playerThreeString,playerThreeValue,computerThreeValue,computerThreeString,playerButton3,computerButton3,"death1");
		}  else if (j==3){//==2) {
			decision (playerThreeString,playerThreeValue,computerThreeValue,computerThreeString,playerButton3,computerButton3,"draw");
		}

	}

	public void Buttonupdate(){
		int count = 0;
		foreach (string pair in playerd.Keys) {//use player dictionary
			if (count == 0) {
				playerOne.text = pair;
				playerOneValue.text = playerd [pair];
			} else if (count == 1) {
				playerTwo.text = pair;
				playerTwoValue.text = playerd [pair];
			} else if (count == 2) {
				playerThree.text =  pair;
				playerThreeValue.text = playerd [pair];
			}
			count = count + 1;
		}
		count = 0;
		foreach (string pair in computerd.Keys) {//use computer dictionary
			if (count == 0) {
				computerOne.text = pair;
				computerOneValue.text = computerd [pair];
			} else if (count == 1) {
				computerTwo.text =  pair;
				computerTwoValue.text = computerd [pair];
			} else if (count == 2) {
				computerThree.text =  pair;
				computerThreeValue.text = computerd [pair];
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
			if (playerButton1.GetComponentInChildren<Text> ().text != "-") {
				playerOneValue.text = playerd [playerOneString];
			}
			if (playerButton2.GetComponentInChildren<Text> ().text != "-") {
				playerTwoValue.text = playerd [playerTwoString];
			}
			if (playerButton3.GetComponentInChildren<Text> ().text != "-") {
				playerThreeValue.text = playerd [playerThreeString];
			}
			if(computerButton1.GetComponentInChildren<Text> ().text !="-"){
			computerOneValue.text = computerd [computerOneString];
			}
			if(computerButton2.GetComponentInChildren<Text> ().text !="-"){
			computerTwoValue.text = computerd [computerTwoString];
			} 
			if(computerButton3.GetComponentInChildren<Text> ().text !="-"){
			computerThreeValue.text = computerd [computerThreeString];
			}
		}
		disableCount = disableCount + 1;
	}

	public void decision(string characterText1, Text characterValue1, Text characterValue2, string characterText2, Button characterButton1, Button characterButton2, string result){
		characterButton2.GetComponentInChildren<Text> ().text = "-";
		Versus.text = characterText1 + " VS " + characterText2; 
		if (result == "death1") {
			characterButton2.GetComponentInChildren<Text> ().text = characterText2;
			characterButton2.enabled = true;
			characterValue2.text = computerd[characterText2];
		} else if (result == "death2") {
			characterButton1.GetComponentInChildren<Text> ().text = characterText1;
			characterButton1.enabled = true;
			characterValue1.text = playerd[characterText1];
		} else if (result == "draw") {
			characterButton1.GetComponentInChildren<Text> ().text = characterText1;
			characterButton2.GetComponentInChildren<Text> ().text = characterText2;
			characterButton1.enabled = true;
			characterButton2.enabled = true;
			characterValue1.text = playerd[characterText1];
			characterValue2.text = computerd[characterText2];
		}

	}


	public int CombatResult (int PlayerValue){
		int enemyLocation = getRandomEnemy;
		string compName;
		string compVal;
		string playerName;
		string playerVal;

		
		Player.SetActive(false);
		Enemy.SetActive (false);

		List<string> PlayerImg = new List<string>();
		List<string> EnemyImg = new List<string>();
		PlayerImg.Add ("Prefab/KnightAttack_0");
		PlayerImg.Add ("Prefab/BlackKnightAttack_0");
		PlayerImg.Add ("Prefab/RedKnight");

		EnemyImg.Add ("Prefab/OrckAttack_0");
		EnemyImg.Add ("Prefab/RedOrckAttack_0");
		EnemyImg.Add ("Prefab/OrckAttackBlack_0");

		int outcome = 0;


			//enemyani.SetBool ("Ani", false);
			//playerani.SetBool ("Ani", false);
			backgroundSprite = ResultText.GetComponentInParent<Image> ();
			if ((int.Parse (Values [PlayerValue]) + (int.Parse (cpuValues [enemyLocation]))) <= 1000) {//EnemyValue) {
				counter++;
			
				Player = GameObject.Instantiate (Resources.Load (PlayerImg [PlayerValue], typeof(GameObject))) as GameObject;
				playerSpriteRenderer = Player.GetComponent<SpriteRenderer> ();
				playerani = playerSpriteRenderer.GetComponent<Animator> ();
				playerani.SetBool ("Ani", true);

				Enemy = GameObject.Instantiate (Resources.Load (EnemyImg [enemyLocation], typeof(GameObject))) as GameObject;
				enemySpriteRenderer = Enemy.GetComponent<SpriteRenderer> ();
				enemyani = Enemy.GetComponent<Animator> ();

				StartCoroutine (Waiting ("Win!"));

				outcome = 1;

				playerName = Names [PlayerValue];
				playerVal = Values [PlayerValue];
				compVal = cpuValues [enemyLocation];
				cpuValues.RemoveAt (enemyLocation);
				compName = cpuNames [enemyLocation];
				cpuNames.RemoveAt (enemyLocation);
			randomEnemy.Remove (enemyLocation);
				
				//enemyCounter++;

				//backgroundSprite.enabled = false;


			} else if ((int.Parse (Values [PlayerValue]) + (int.Parse (cpuValues [enemyLocation]))) >= 1100) { //EnemyValue) {
				counter++;
				Player = GameObject.Instantiate (Resources.Load (PlayerImg [PlayerValue], typeof(GameObject))) as GameObject;
				playerSpriteRenderer = Player.GetComponent<SpriteRenderer> ();
				playerani = playerSpriteRenderer.GetComponent<Animator> ();

				Enemy = GameObject.Instantiate (Resources.Load (EnemyImg [enemyLocation], typeof(GameObject))) as GameObject;
				enemySpriteRenderer = Enemy.GetComponent<SpriteRenderer> ();
				enemyani = Enemy.GetComponent<Animator> ();
				enemyani.SetBool ("Ani", true);

				StartCoroutine (Waiting ("Lose!"));

				outcome = 2;
				//backgroundSprite.enabled = false;

				playerName = Names [PlayerValue];
				playerVal = Values [PlayerValue];
				compVal = cpuValues [enemyLocation];
				compName = cpuNames [enemyLocation];

				lostCounter++;

			} else {
				counter++;
				Player = GameObject.Instantiate (Resources.Load (PlayerImg [PlayerValue], typeof(GameObject))) as GameObject;
				playerSpriteRenderer = Player.GetComponent<SpriteRenderer> ();
				playerani = playerSpriteRenderer.GetComponent<Animator> ();
				playerani.SetBool ("Ani", true);

				Enemy = GameObject.Instantiate (Resources.Load (EnemyImg [enemyLocation], typeof(GameObject))) as GameObject;
				enemySpriteRenderer = Enemy.GetComponent<SpriteRenderer> ();
				enemyani = Enemy.GetComponent<Animator> ();
				enemyani.SetBool ("Ani", true);

				StartCoroutine (Waiting ("Draw..."));

				outcome = 3;
				//backgroundSprite.enabled = false;

				playerName = Names [PlayerValue];
				playerVal = Values [PlayerValue];
			compVal = cpuValues [enemyLocation];
				compName = cpuNames [enemyLocation];

				drawCounter++;

			}

		recordResult (playerName, playerVal, compName, compVal, outcome);

			if (Values.Count == 0) {
				reviewList.Insert (0, "win");
				StartCoroutine (waitNextScene ());
				return 1;
			} else if (cpuValues.Count == 0) {
				reviewList.Insert (0, "win");
				StartCoroutine (waitNextScene ());
				return 2;
			}else if (lostCounter == 3) {
				reviewList.Insert (0, "lost");
				StartCoroutine (waitNextScene ());
				return 3;
			}else if (drawCounter == 3) {
				reviewList.Insert (0, "draw");
				StartCoroutine (waitNextScene ());
				return 4;
			}	
			/*if (counter == 3) {
				StartCoroutine (waitNextScene ());
			}*/

			return outcome;
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


	public void recordResult(string one, string two, string three, string four, int result){

		string pName = one;
		string eName = three;
		string pVal = two;
		string eVal = four;
		string finish;
		string outcomeString = "";

		/*

		pName = Names [pValue];
		pVal = Values [pValue];
		eName = cpuNames [count-1];
		eVal = cpuValues [count-1];

		*/

		if (result == 1) {
			finish = "Win";
		} else if (result == 2) {
			finish = "Lose";
		} else {
			finish = "Draw";
		}

		outcomeString = "User: " + pName + " Value: " + pVal + " Computer: " + eName + " Value: " + eVal + " Result: " + finish;
		reviewList.Add (outcomeString);
	}



	public void loadLastScene(){

		SceneManager.LoadScene("Selection V3");

	}

	public void loadNextScene(){

		SceneManager.LoadScene("Review");

	}




	}

