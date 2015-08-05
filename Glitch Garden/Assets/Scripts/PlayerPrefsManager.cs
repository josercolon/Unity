using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY =  "master_volume";
	const string DIFICULTY_KEY = "dificulty";
	const string LEVEL_KEY = "level_unlocked_";
	// level_unlocked_01

	public static void SetMasterVolume (float volume){
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master Volume Out of range");
		}
	}

	public static float GetMasterVolume (){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel (int level){
		if (level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1);// Use une fot true
		} else {
			Debug.LogError ("Trying to unlock level not in Build Order");
		}
	}

	public static bool IsLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		bool isLevelUnlocked = (levelValue == 1);

		if (level <= Application.levelCount - 1) {
			return isLevelUnlocked;
		} else {
			Debug.LogError ("Trying to query level not in Build Order");
			return false;
		}
	}

	public static float GetDificulty (){
		return PlayerPrefs.GetFloat (DIFICULTY_KEY);
	}
	
	public static void SetDifficulty (float difficulty){
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Dificulty Out of range");
		}
	}




}