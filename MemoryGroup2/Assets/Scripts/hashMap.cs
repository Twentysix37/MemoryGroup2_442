using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class hashMap : MonoBehaviour {


	// Use this for initialization
	void Start () {
		Dictionary<string, List<string>> theHash = new Dictionary<string, List<string>>();

		theHash.Add("Frank", GetValue("Frank", "1"));
		theHash.Add("Curt", GetValue("Curt", "3"));
		theHash.Add ("Kyle", GetValue("Kyle", "4"));
		theHash.Add ("Alison", GetValue("Alison", "2"));
		theHash.Add ("Rachel", GetValue("Rachel", "1"));
		theHash.Add ("Joe", GetValue("Joe", "4"));
		theHash.Add ("Ray", GetValue("Ray", "3"));
		theHash.Add ("Sam", GetValue("Sam", "2"));
		theHash.Add ("Dave", GetValue("Dave", "1"));
		theHash.Add ("Travis", GetValue("Travis", "2"));
		theHash.Add ("Monica", GetValue("Monica", "4"));
		theHash.Add ("Dan", GetValue("Dan", "3"));
	
	}


	public List<string> GetValue(string firstItem, string secondItem){

		List<string> value = new List<string> ();

		value.Add (firstItem);
		value.Add (secondItem);

		return value;
	}


	public List<string> GetKeys(){

		List<string> keyList = new List<string> (theHash.Keys);

		return keyList;
	}


	//returns the values for a specific hash 
	public Dictionary<string, List<string>> GetHash(){


		List<string> kList = GetKeys ();
		string name;
		List<string> valueOfName;
		Dictionary<string, List<string>> newHash =  new Dictionary<string, List<string>>();

		for (int i = 0; i < 3; i++) {

			name = kList.ElementAt ((int)(Random.Range(0, 11)));
			valueOfName = theHash [name];
			newHash.Add (name, valueOfName);
			theHash.Remove (name);
		}

		return newHash;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
