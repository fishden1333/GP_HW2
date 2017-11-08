using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	void Start()
	{
		Screen.lockCursor = false;
	}

	IEnumerator LoadScene()
	{
		yield return new WaitForSeconds(100);
	}

	public void StartGame()
	{
		StartCoroutine(LoadScene());
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Game");
	}
}
