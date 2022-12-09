using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

	void Start () {
		
	}

	public void Quit(){
		Application.Quit();
		#if UNITY_EDITOR
        if (Application.isEditor) {
			UnityEditor.EditorApplication.isPlaying = false;
		}
		#endif
    }

	public void BackToMenu()
	{
		SceneManager.LoadScene(sceneName: "Start Scene");

	}

	public void Begin(){
		SceneManager.LoadScene (sceneName:"City Map");
        Cursor.lockState = true ? CursorLockMode.Locked : CursorLockMode.None;
    }
}