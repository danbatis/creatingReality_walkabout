using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadScenes : MonoBehaviour {
	Dropdown sceneOption;

	// Use this for initialization
	void Start () {
		sceneOption = GameObject.Find ("GUI/Panel/Dropdown").GetComponent<Dropdown>();		
	}
	
	public void LoadScene(){
		Debug.Log (sceneOption.options[sceneOption.value].text);
		switch(sceneOption.options[sceneOption.value].text){
		case "scene1":
			SceneManager.LoadScene(0);
			break;
		case "scene2":
			SceneManager.LoadScene(1);
			break;
		case "scene4":
			SceneManager.LoadScene(2);
			break;	
		}		
	}
}
