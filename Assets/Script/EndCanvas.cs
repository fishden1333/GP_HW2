using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCanvas : MonoBehaviour {

	public Canvas endCanvas;
	private bool inCanvas;

	// Use this for initialization
	void Start () {
		endCanvas.enabled = false;
		inCanvas = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && inCanvas == false)
		{
			OpenCanvas();
		}
		else if (Input.GetKeyDown(KeyCode.N) && inCanvas == true)
		{
			CloseCanvas();
		}
		else if (Input.GetKeyDown(KeyCode.Y) && inCanvas == true)
		{
			Application.Quit();
		}
	}

	public void OpenCanvas()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			print("Press enter");
			endCanvas.enabled = true;
			inCanvas = !inCanvas;
		}
	}

	public void CloseCanvas()
	{
			endCanvas.enabled = false;
			inCanvas = !inCanvas;
	}
}
