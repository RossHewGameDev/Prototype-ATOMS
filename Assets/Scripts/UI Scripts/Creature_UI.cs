using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature_UI : MonoBehaviour
{
    public bool hasHealth;
    public GameObject healthBar_Prefab;

    private UITracker _uITracker;
    private Creature _creature;
    private GameObject _healthBarParent;
    private Slider _healthSlider;

    private bool healthSetupValid
    {
        get { return hasHealth; }
    }

    void Start()
    {
        _creature = gameObject.GetComponent<Creature>();
        _uITracker = gameObject.GetComponent<UITracker>();

        if (healthSetupValid)
        {
            _healthBarParent = GameObject.Find("HealthBarsParent");
            InstantiateHealthBar(_healthBarParent.transform);
            UI_HealthSetup(_healthSlider, _creature.maxHealth, _creature.currentHealth);
        }
        else
        {
            Debug.LogWarning("!!! - Health setup failed for: " + gameObject.name + " - !!!");
        }
    }

    private void Update()
    {
        if (healthSetupValid)
        {
            UI_HealthUpdate(_healthSlider, _creature.currentHealth);
        }
    }

    public void UI_HealthSetup(Slider _HealthSlider, int _MaxHealth, int _CurrentHealth)
    {
        _HealthSlider.minValue = 0;
        _HealthSlider.maxValue = _MaxHealth;
        _HealthSlider.value = _CurrentHealth;
    }

    private void InstantiateHealthBar(Transform UI_HealthParent)
    {
        _uITracker = GetComponent<UITracker>();  // Assigning Tracker
        GameObject myHealthBar = Instantiate(healthBar_Prefab, UI_HealthParent); // Creating Health bar
        myHealthBar.gameObject.name = "Health Bar || " + _creature.cr_Name;// Giving Health bar agent name
        _healthSlider = myHealthBar.GetComponent<Slider>();    // assigning UI slider for agent
        _uITracker.UItoTrack = myHealthBar;                     // assigning health bar to UI to game tracking.
    }

    public void UI_HealthUpdate(Slider _HealthSlider, int _CurrentHealth)
    {
        _HealthSlider.value = _CurrentHealth;
    }
}
