using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "Master Volume";
	const string DIFFICULTY_KEY = "Difficulty";
	const string LEVEL_KEY = "level_unlock_";

	public static void SetMasterVolume (float volume){
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master Volume Out Of Range");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}


	public static void UnlockLevel (int level){
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1); // use 1 for ture
		} else {
			Debug.LogError("trying to unlock level not in build");
		}
	}
	public static bool IslevelUnlock(int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		bool isLevelUnlock = (levelValue == 1);
		if (level < +SceneManager.sceneCountInBuildSettings - 1) {
			return isLevelUnlock;
		} else {
			Debug.LogError("trying to unlock level not in build");
			return false;
		}
	}
	public static void SetDifficulty (float difficulty){
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty Out Of Range");
		}
	}
	
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
}
