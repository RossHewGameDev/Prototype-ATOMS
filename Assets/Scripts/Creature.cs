using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class Creature : MonoBehaviour
{
    public enum Team //TODO: Move to Scenario Master Class
    {
        Ally,
        Enemy,
        Neutral
    }

    [Header("Main Properties")]
    public Team team;
    public string cr_Name;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    [Header("Movement")]
    public float speed;

    [Header("Equipment")]
    public string weapon; //TODO: Implement weapons through Scriptable Objects.


    private void Start()
    {
        currentHealth = maxHealth; // Creatures start with max health on first spawn.
    }

    public void MoveTo(Vector3 Position)
    {
        //TODO: Move Creatures rigidbody using "speed" towards "target".
    }
}
