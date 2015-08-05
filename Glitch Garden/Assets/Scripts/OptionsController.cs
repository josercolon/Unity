using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSilder;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;


	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSilder.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDificulty();
	}

	void Update () {
		musicManager.SetVolume (volumeSilder.value);
	}

	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume (volumeSilder.value);
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);

		levelManager.LoadLevel ("Start");
	}

	public void SetDefaults(){
		volumeSilder.value = 0.8f;
		difficultySlider.value = 2f;
	}
}
