using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class UI_Health : MonoBehaviour
    {
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

