﻿using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;


	void Awake () {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Persistent Music");
	}

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void OnLevelWasLoaded (int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log ("Playing clip: " + levelMusicChangeArray [level]);

		if (thisLevelMusic){
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	public void SetVolume(float volume){
		audioSource.volume = volume;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
