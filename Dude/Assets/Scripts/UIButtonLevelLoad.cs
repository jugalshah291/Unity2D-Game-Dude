using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIButtonLevelLoad : MonoBehaviour {
	
	public string LevelToLoad;
	
	public void loadLevel() {
        ScoreScript.scoreValue = 0;
        //Load the level from LevelToLoad
        SceneManager.LoadScene(LevelToLoad);
	}
}
