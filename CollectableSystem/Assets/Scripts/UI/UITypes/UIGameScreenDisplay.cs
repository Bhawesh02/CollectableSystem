using System;
using UnityEngine;
using UnityEngine.UI;

public class UIGameScreenDisplay : GameUI
{
    
    [SerializeField] private Button m_inventoryButton;

    private void Start()
    {
        m_inventoryButton.onClick.AddListener(HandleOnInventoryButtonPress);
    }

    private void HandleOnInventoryButtonPress()
    {
        GameplayEvents.SendOnShowUI(UITypes.INVENTORY);
    }
}