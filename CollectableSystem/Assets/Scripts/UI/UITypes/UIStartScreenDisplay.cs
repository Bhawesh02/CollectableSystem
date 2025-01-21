using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStartScreenDisplay : GameUI
{
    [SerializeField] private Button m_startButton;

    private void Start()
    {
        m_startButton.onClick.AddListener( HandleOnStartButtonPress);
    }

    private void HandleOnStartButtonPress()
    {
        GameplayEvents.SendOnHideUI();
    }
    
}