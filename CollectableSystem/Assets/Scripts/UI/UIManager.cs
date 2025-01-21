using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private IUIHandler m_startUI;
    [SerializeField] private IUIHandler m_gameScreenUI;
    [SerializeField] private IUIHandler m_inventoryUI;

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

    private void HandleOnShowUI(UITypes obj)
    {
        throw new System.NotImplementedException();
    }
}