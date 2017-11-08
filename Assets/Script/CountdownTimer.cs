using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public float timeLeft = 100;

  public Text text;

	void Start()
	{
		text = GameObject.Find("TimeText").GetComponent<Text>();
	}

  void Update()
  {
      timeLeft -= Time.deltaTime;
      text.text = "Time: " + Mathf.Round(timeLeft);
      if(timeLeft < 0)
      {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Over");
      }
  }
}
