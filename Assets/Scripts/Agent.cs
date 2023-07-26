using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    UITracker _UITracker;


    //                       //

    [Header("Main Properties")]
    public AgentType agentType;
    public string agentName;

    [Header("Health")]
    public bool HasHealth;
    public int MaxHealth;
    public int CurrentHealth;

    [SerializeField] Slider UI_HealthSlider; // debug view

    public GameObject HealthBar_Prefab;



    //Private Variables:
    private bool healthSetupValid
    {
        get { return HasHealth; }
    }

    private GameObject healthBarParent;

    private void Start()
    {


        if (healthSetupValid)
        {
            healthBarParent = GameObject.Find("HealthBarsParent");
            InstantiateHealthBar(healthBarParent.transform);
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

    public AgentType ReturnAgentType() 
    {
        return agentType;
    }

    private void InstantiateHealthBar(Transform UI_HealthParent)
    {
        _UITracker = GetComponent<UITracker>();  // Assigning Tracker
        GameObject myHealthBar = Instantiate(HealthBar_Prefab, UI_HealthParent); // Creating Health bar
        myHealthBar.gameObject.name = "Health Bar - " + agentName;// Giving Health bar agent name
        UI_HealthSlider = myHealthBar.GetComponent<Slider>();    // assigning UI slider for agent
        _UITracker.UItoTrack = myHealthBar;                     // assigning health bar to UI to game tracking.
    }









}
