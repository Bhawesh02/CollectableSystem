using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameUI m_startUI;
    [SerializeField] private GameUI m_gameScreenUI;
    [SerializeField] private GameUI m_inventoryUI;
    
    private Dictionary<UITypes, IUIHandler> m_uiHandlerMap;
    private UITypes m_currentActiveUI;
    
    protected override void Init()
    {
        m_uiHandlerMap = new Dictionary<UITypes, IUIHandler>()
        {
            { UITypes.START , m_startUI},
            { UITypes.INVENTORY , m_inventoryUI}
        };
        GameplayEvents.OnShowUI += HandleOnShowUI;
        GameplayEvents.OnHideUI += HideUI;
    }

    private void OnDestroy()
    {
        GameplayEvents.OnShowUI -= HandleOnShowUI;
        GameplayEvents.OnHideUI -= HideUI;
    }

    private void Start()
    {
        GameplayEvents.SendOnShowUI(UITypes.START);
    }

    private void HideUI()
    {
        foreach (KeyValuePair<UITypes,IUIHandler> uiHandlerPair in m_uiHandlerMap)
        {
            uiHandlerPair.Value.OnHide();
        }
    }
    private void HandleOnShowUI(UITypes uiType)
    {
        if ( uiType == UITypes.NULL || m_currentActiveUI == uiType)
        {
            return;
        }
        HideUI();
        IUIHandler uiHandler = m_uiHandlerMap.GetValueOrDefault(uiType);
        uiHandler.OnShow();
    }
    
    
        
}