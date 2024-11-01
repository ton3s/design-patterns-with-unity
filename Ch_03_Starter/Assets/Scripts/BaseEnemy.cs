using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1
public interface ICopy
{
	public ICopy Copy(Transform parent);
}

// 2
public class BaseEnemy : MonoBehaviour, ICopy
{
	[SerializeField] protected int Damage;
	[SerializeField] protected string Message;
	[SerializeField] protected string Name;

	private int enemyRange = 4;

	public void OnEnable()
	{
		Debug.LogFormat($"{Message} - an {Name} entered the arena.");
	}
	public virtual void Attack()
	{
		Debug.LogFormat($"{Name} attacks for {Damage} HP!");
	}
	// 3
	public ICopy Copy(Transform parent)
	{
		// 4
		BaseEnemy clone = Instantiate(this);
		// 5
		var clonePosition = new Vector3(Random.Range(-enemyRange, enemyRange), 0, Random.Range(-enemyRange, enemyRange));
		// 6
		clone.transform.SetParent(parent);
		clone.transform.localPosition = clonePosition;
		// 7
		return clone;
	}
}
