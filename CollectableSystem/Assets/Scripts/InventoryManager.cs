using System.Collections.Generic;

public class InventoryManager : MonoSingleton<InventoryManager>
{
    private Dictionary<CollectableItem, int> m_playerItemCollectedData;
    protected override void Init()
    {
        m_playerItemCollectedData = new();
        GameplayEvents.OnCollectableCollected += HandleOnCollectableCollected;
    }

    private void OnDestroy()
    {
        GameplayEvents.OnCollectableCollected -= HandleOnCollectableCollected;
    }

    private void HandleOnCollectableCollected(CollectableItem collectableItem, CollectableBehaviour collectableBehaviour)
    {
        if (!m_playerItemCollectedData.TryAdd(collectableItem, 1))
        {
            m_playerItemCollectedData[collectableItem] += 1;
        }
        GameplayEvents.SendOnInventoryUpdated(collectableItem, m_playerItemCollectedData[collectableItem]);
    }
}