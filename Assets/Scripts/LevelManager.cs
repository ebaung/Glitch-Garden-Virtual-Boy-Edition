using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // new for Unity 5.x replaces Application.LoadLevel with SceneManager.LoadScene

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start(){
		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log ("Level auto load disabled. Use a positive number in seconds.");

		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel (string name)
	{
		Debug.Log ("New Level Load: " + name);
		// deprecated: Application.LoadLevel(name) -- use SceneManager.LoadScene
		SceneManager.LoadScene (name);
	}

	public void QuitRequest ()
	{
		Debug.Log ("Quit Requested!");
		Application.Quit();
	}

	public void LoadNextLevel() {
		// deprecated: Application.LoadLevel (Application.LoadedLevel + 1);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
