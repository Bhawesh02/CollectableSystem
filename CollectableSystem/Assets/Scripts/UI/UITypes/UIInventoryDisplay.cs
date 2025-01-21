using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryDisplay : GameUI
{
    [SerializeField] private LayoutGroup m_itemViewContainer;
    [SerializeField] private InventoryItemView m_itemViewPrefab;
    
    private Dictionary<CollectableItem, InventoryItemView> m_itemViewMap = new();

    private void Awake()
    {
        GameplayEvents.OnInventoryUpdated += HandleOnUIUpdate;
    }

    private void OnDestroy()
    {
        GameplayEvents.OnInventoryUpdated -= HandleOnUIUpdate;
    }

    private void HandleOnUIUpdate(CollectableItem collectableItem, int count)
    {
            if (m_itemViewMap.ContainsKey(collectableItem))
            {
                m_itemViewMap[collectableItem].UpdateCount(count);
            }
            else
            {
                InventoryItemView itemView = Instantiate(m_itemViewPrefab, m_itemViewContainer.transform);
                itemView.Config(collectableItem, count);
                m_itemViewMap.Add(collectableItem, itemView);
            }
        
    }
}