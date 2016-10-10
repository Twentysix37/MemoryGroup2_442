using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class hashMap : MonoBehaviour {

	Dictionary<string, List<string>> theHash = new Dictionary<string, List<string>>();
	Dictionary<string, List<string>> firstHash = new Dictionary<string, List<string>>();
	Dictionary<string, List<string>> secondHash = new Dictionary<string, List<string>>();

	// Use this for initialization
	void Start () {

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
		theHash.Add("Fred", GetValue("Fred", "1"));
		theHash.Add("Chris", GetValue("Chris", "3"));
		theHash.Add ("Tom", GetValue("Tom", "4"));
		theHash.Add ("Emily", GetValue("Emily", "2"));
		theHash.Add ("Brad", GetValue("Brad", "1"));
		theHash.Add ("Jake", GetValue("Jake", "4"));
		theHash.Add ("Steve", GetValue("Steve", "3"));
		theHash.Add ("Kayla", GetValue("Kayla", "2"));
		theHash.Add ("Dennis", GetValue("Dennis", "1"));
		theHash.Add ("Taylor", GetValue("Taylor", "2"));
		theHash.Add ("Mike", GetValue("Mike", "4"));
		theHash.Add ("Doug", GetValue("Doug", "3"));

		//Debug.Log ("theHashLength: " + theHash.Count ());

		firstHash = GetHash();
		//Debug.Log ("firstHash length: " + firstHash.Count ());
		secondHash = GetHash();
		//Debug.Log ("secondHash length: " + secondHash.Count ());

	
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

		while(newHash.Count() != 8) {

			name = kList.ElementAt ((int)(Random.Range(0, theHash.Count())));
			//Debug.Log ("name: " + name);
			theHash.TryGetValue (name, out valueOfName);
			//Debug.Log ("valueOfName: " + valueOfName);
			newHash[name] = valueOfName;
			theHash.Remove (name);
		}

		return newHash;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
