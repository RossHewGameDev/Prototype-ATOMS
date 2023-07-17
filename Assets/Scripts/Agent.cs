using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Agent : MonoBehaviour
{
    public enum AgentType
    {
        Ally,
        Enemy,
        Neutral
    }
    // Essential Controllers //

    UICommands uICommands;


    //                       //

    [Header("Main Properties")]
    public AgentType agentType;
    public string agentName;

    [Header("Health")]
    public bool HasHealth;
    public int MaxHealth;
    public int CurrentHealth;

    [Header("TEMP")]
    public Slider UI_HealthSlider; // assign slider here... 
                                  // Would be nice to just have healthbars be a part of the whole guy prefab, 
                                 // not sure how to best go about that right now.


    //Private Variables:
    private bool healthSetupValid
    {
        get { return HasHealth && UI_HealthSlider != null; }
    }


    private void Start()
    {
        if (healthSetupValid)
        {
            UI_HealthSetup(UI_HealthSlider, MaxHealth, CurrentHealth);
        }
    }

    private void Update()
    {
        if (healthSetupValid)
        {
            UI_HealthUpdate(UI_HealthSlider,CurrentHealth);
        }
    }

    public void UI_HealthSetup(Slider _HealthSlider, int _MaxHealth, int _CurrentHealth)
    {
        _HealthSlider.minValue = 0;
        _HealthSlider.maxValue = _MaxHealth;
        _HealthSlider.value = _CurrentHealth;
    }

    public void UI_HealthUpdate(Slider _HealthSlider, int _CurrentHealth)
    {
        _HealthSlider.value = _CurrentHealth;
    }











}
