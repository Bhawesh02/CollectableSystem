using System;
using System.Collections.Generic;

public static class GameplayEvents
{
    public static event Action<CollectableItem, CollectableBehaviour> OnCollectableCollected;

    public static void SendOnCollectableCollected(CollectableItem collectableItem, CollectableBehaviour collectableBehaviour)
    {
        OnCollectableCollected?.Invoke(collectableItem, collectableBehaviour);
    }
    
    public static event Action<CollectableItem, int> OnInventoryUpdated;

    public static void SendOnInventoryUpdated(CollectableItem collectableItem, int count)
    {
        OnInventoryUpdated?.Invoke(collectableItem, count);
    }

    public static event Action<UITypes> OnShowUI;

    public static void SendOnShowUI(UITypes uiType)
    {
        OnShowUI?.Invoke(uiType);
    }
    
    public static event Action OnHideUI;

    public static void SendOnHideUI()
    {
        OnHideUI?.Invoke();
    }
}