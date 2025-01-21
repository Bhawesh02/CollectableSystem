using UnityEngine;

public class CollectablePoolService : PoolService<CollectableBehaviour>
{
    private CollectableBehaviour m_collectablePrefab;
    private Transform m_collectableParent;

    public CollectablePoolService(CollectableBehaviour collectablePrefab, Transform collectableParent)
    {
        m_collectablePrefab = collectablePrefab;
        m_collectableParent = collectableParent;
    }

    public override void ReturnItem(CollectableBehaviour item)
    {
        base.ReturnItem(item);
        item.gameObject.SetActive(false);
    }

    public override CollectableBehaviour GetItem()
    {
        CollectableBehaviour item = base.GetItem();
        item.gameObject.SetActive(true);
        return item;
    }

    protected override CollectableBehaviour CreateItem()
    {
        return GameObject.Instantiate(m_collectablePrefab, m_collectableParent);
    }
    
    
}