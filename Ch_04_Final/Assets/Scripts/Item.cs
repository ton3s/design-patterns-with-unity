using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    void Equip();
}

public class Pebble : MonoBehaviour, IItem
{
    public void Equip()
    {
        Debug.Log("You skipped your pebble at a nearby lake.");
    }
}

public class CursedKnife : MonoBehaviour, IItem
{
    public void Equip()
    {
        var player = GameObject.FindAnyObjectByType<Player>();    
        player.SetColor(Color.magenta);    

        Debug.Log($"Woops, you're cursed...");
    }
}

public class Potion : MonoBehaviour, IItem    
{
    public void Equip()    
    {
        var player = GameObject.FindAnyObjectByType<Player>();    
        player.SetColor(Color.green);    

        var manager = GameObject.FindAnyObjectByType<Manager>();    
        manager.HP += 5;    
        manager.Boost++;    

        Debug.Log($"Potion healed you for 5 HP!");    
    }
}