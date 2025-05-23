﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Michsky.UI.ModernUIPack
{
    public class ProgressBar : MonoBehaviour
    {
        // Content
        public float currentPercent;
        [Range(0, 100)] public int speed;
        public float maxValue = 100;

        // Resources
        public Image loadingBar;
        public TextMeshProUGUI textPercent;

        // Settings
        public bool isOn;
        public bool restart;
        public bool invert;
        public bool addPrefix;
        public bool addSuffix = true;
        public string prefix = "";
        public string suffix = "%";
        public bool isFilled;

        void Start()
        {
            if (isOn == false)
            {
                loadingBar.fillAmount = currentPercent / maxValue;
                textPercent.text = ((int)currentPercent).ToString("F0") + "%";
            }
        }

        void Update()
        {
            if (isOn == true)
            {
                if (currentPercent <= maxValue && invert == false)
                    currentPercent += speed * Time.deltaTime;
                else if (currentPercent >= 0 && invert == true)
                    currentPercent -= speed * Time.deltaTime;

                if (currentPercent >= maxValue && speed != 0 && restart == true && invert == false)
                    currentPercent = 0;
                else if (currentPercent <= 0 && speed != 0 && restart == true && invert == true)
                    currentPercent = maxValue;

                UpdateUI();
            }
        }

        public void UpdateUI()
        {
            loadingBar.fillAmount = currentPercent / maxValue;
          
            if (addSuffix == true)
                textPercent.text = ((int)currentPercent).ToString("F0") + suffix;
            else
                textPercent.text = ((int)currentPercent).ToString("F0");

            if (addPrefix == true)
                textPercent.text = prefix + textPercent.text;
        }
    }
}