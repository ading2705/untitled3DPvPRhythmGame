using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class GachaTestBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI itemText;
    [SerializeField] private TextMeshProUGUI pityText;
    [SerializeField] GachaCalculator gacha;

    private void Update()
    {
        pityText.text = "Pity: " + gacha.GetCurrentPity();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        itemText.text = "Last Item: " + gacha.Pull();
    }
}
