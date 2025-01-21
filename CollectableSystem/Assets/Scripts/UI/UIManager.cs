using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private IUIHandler m_startUI;
    [SerializeField] private IUIHandler m_gameScreenUI;
    [SerializeField] private IUIHandler m_inventoryUI;
    [SerializeField] private Image m_background;
    
    private Dictionary<UITypes, IUIHandler> m_uiHandlerMap;
    private UITypes m_currentActiveUI;
    
    protected override void Init()
    {
        m_uiHandlerMap = new Dictionary<UITypes, IUIHandler>()
        {
            { UITypes.START , m_startUI},
            { UITypes.GAME_SCREEN , m_gameScreenUI},
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
    
    private void HideUI()
    {
        m_background.gameObject.SetActive(false);
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
        m_background.gameObject.SetActive(true);
        IUIHandler uiHandler = m_uiHandlerMap.GetValueOrDefault(uiType);
        uiHandler.OnShow();
    }
    
    
        
}