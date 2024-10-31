using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1
using UnityEngine.UI;
public class SceneController : MonoBehaviour
{
	// 2
	public Button start;
	void Start()
	{
		// 3
		start.onClick.AddListener(GenericManager.Instance.StartGame);
	}
}
