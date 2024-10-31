using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICopy
{
    public ICopy Copy(Transform parent);
}

public abstract class BaseEnemy : MonoBehaviour, ICopy
{
    [SerializeField] protected int Damage;
    [SerializeField] protected string Message;
    [SerializeField] protected string Name;

    public void OnEnable()
    {
        Debug.LogFormat($"{Message} - an {Name} entered the arena.");
    }

    public virtual void Attack()
    {
        Debug.LogFormat($"{Name} attacks for {Damage} HP!");
    }

    public ICopy Copy(Transform parent)
    {
        BaseEnemy clone = Instantiate(this);
        var clonePosition = new Vector3(Random.Range(-7, 7), 0, Random.Range(-7, 7));

        clone.transform.SetParent(parent);
        clone.transform.localPosition = clonePosition;

        return clone;
    }
}