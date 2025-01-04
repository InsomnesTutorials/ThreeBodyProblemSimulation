using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject uiMenu;

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
    
    private void ToggleMenu()
    {
        uiMenu.SetActive(!uiMenu.activeSelf);
        Time.timeScale = uiMenu.activeSelf ? 0 : 1;
    }
}
