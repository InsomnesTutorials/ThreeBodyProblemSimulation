﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

namespace Michsky.UI.ModernUIPack
{
    [AddComponentMenu("Modern UI Pack/Tooltip/Tooltip Content")]
    public class TooltipContent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Content")]
        [TextArea] public string description;
        public float delay;

        [Header("Resources")]
        public GameObject tooltipRect;
        public TextMeshProUGUI descriptionText;

        [Header("Settings")]
        public bool forceToUpdate = false;

        TooltipManager tpManager;
        [HideInInspector] public Animator tooltipAnimator;

        void Start()
        {
            if (tooltipRect == null || descriptionText == null)
            {
                try
                {
                    tooltipRect = GameObject.Find("Tooltip Rect");
                    descriptionText = tooltipRect.transform.GetComponentInChildren<TextMeshProUGUI>();
                }

                catch { Debug.LogError("<b>[Tooltip Content]</b> Tooltip Rect is missing.", this); return; }
            }

            if (tooltipRect != null)
            {
                tpManager = tooltipRect.GetComponentInParent<TooltipManager>();
                tooltipAnimator = tooltipRect.GetComponentInParent<Animator>();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (tooltipRect == null)
                return;

            descriptionText.text = description;
            tpManager.allowUpdating = true;
            tooltipAnimator.gameObject.SetActive(false);
            tooltipAnimator.gameObject.SetActive(true);

            if (delay == 0)
                tooltipAnimator.Play("In");
            else
                StartCoroutine("ShowTooltip");

            if (forceToUpdate == true)
                StartCoroutine("UpdateLayoutPosition");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (tooltipRect == null)
                return;

            if (delay != 0)
            {
                StopCoroutine("ShowTooltip");

                if (tooltipAnimator.GetCurrentAnimatorStateInfo(0).IsName("In"))
                     tooltipAnimator.Play("Out");
            }

            else
                tooltipAnimator.Play("Out");

            tpManager.allowUpdating = false;
        }

        IEnumerator ShowTooltip()
        {
            yield return new WaitForSeconds(delay);
            tooltipAnimator.Play("In");
            StopCoroutine("ShowTooltip");
        }

        IEnumerator UpdateLayoutPosition()
        {
            yield return new WaitForSeconds(0.1f);
            LayoutRebuilder.ForceRebuildLayoutImmediate(tooltipAnimator.gameObject.GetComponent<RectTransform>());
        }
    }
}