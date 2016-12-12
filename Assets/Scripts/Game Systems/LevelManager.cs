using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private string nameHolder;

    // Loading levels incremented in listing order.
    public void LoadNextLevelDelay(float delay) {
        Invoke("LoadNextLevel", delay);
    }

    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    // Loading levels by name.
    public void LoadLevelByNameDelay(string name, float delay) {
        nameHolder = name;
        Invoke("LoadLevelByNameCall", delay);
    }

    private void LoadLevelByNameCall() {
        LoadLevelByName(nameHolder);
        nameHolder = null;
    }

    public void LoadLevelByName(string name) {
		Debug.Log ("New Level load: " + name);
        SceneManager.LoadScene(name);
	}

    // Quiting the game.
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
