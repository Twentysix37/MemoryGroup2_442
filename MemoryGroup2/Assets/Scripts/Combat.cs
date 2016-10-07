using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Combat : MonoBehaviour {
	public Text ResultText;
	public int PlayerValue;

	public void CombatResult (int PlayerValue){
		if (PlayerValue > 0){//EnemyValue) {
			ResultText.text = "Win!";
		} else if (PlayerValue < 0){ //EnemyValue) {
			ResultText.text = "Lose!";
		} else {
			ResultText.text = "Draw...";
		}
	}
}
