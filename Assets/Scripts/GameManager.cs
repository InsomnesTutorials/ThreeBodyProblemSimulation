using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject uiMenu;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text sliderValueText;

    private void Start()
    {
        uiMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }
    
    public void ToggleMenu()
    {
        uiMenu.SetActive(!uiMenu.activeSelf);
        Time.timeScale = uiMenu.activeSelf ? 0 : 1;
        
        if (!uiMenu.activeSelf)
        {
            slider.value = 1;
            sliderValueText.text = "1.00";
        }
    }

    public void OnSliderChanged()
    {
        sliderValueText.text = slider.value.ToString("0.00");
        Time.timeScale = slider.value;
    }
}
