using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			GenericManager.Instance.score += 1;
			Destroy(this.gameObject);
			Debug.Log("Item collected!");
		}
	}
}