using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

	void Start () {
		
	}

	public void Quit(){
		Application.Quit();
		
	}

	public void Begin(){
		SceneManager.LoadScene (sceneName:"City Map");
	}
}