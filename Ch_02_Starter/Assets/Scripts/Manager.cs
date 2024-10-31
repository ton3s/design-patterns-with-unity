using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	public static Manager Instance;
	public int score = 0;
	public int startingLevel = 1;
	public Guid UniqueId { get; private set; } = Guid.NewGuid();

	public void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			Debug.Log("New Manager instance created...: " + UniqueId + " : " + gameObject.name);
			DontDestroyOnLoad(this.gameObject);
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
			Debug.Log("Manager instance already exists, destroying new instance...: " + UniqueId + " : " + gameObject.name);
		}
	}

	public void StartGame()
	{
		Debug.Log("New game has started...");
		SceneManager.LoadScene(startingLevel);
	}
}