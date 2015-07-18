using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	// Use this for initialization
	int max;
	int min;
	int guess;
	public int maxGuessesAllowed = 5;

	public Text text; 


	void Start () {
		StartGame ();

	}

	void StartGame () {
		max = 1000;
		min = 1;
		NextGuess();

		print ("========================");
		print ("Welcome to Number Wizard");
		print ("Pick a number in your head, but dont tell me");
		
		print ("The highest number you can pick is " + max);
		print ("The lowest number you can pick is " + min);
		
		print ("Is the number higher or lower than " + guess);
		print ("Up arrow for higher, Down arrow for lower, Enter for equals.");

		max = max + 1;
	}
	
	public void GuessLower(){
		max = guess; 
		NextGuess ();
	}

	public void GuessHigher(){
		min = guess;
		NextGuess ();
	}

	void NextGuess () {
		guess = Random.Range(min,max+1);
		text.text = guess.ToString();
		maxGuessesAllowed = maxGuessesAllowed -1;
		if (maxGuessesAllowed <= 0) {
			Application.LoadLevel("Win");
		}
	}
}
