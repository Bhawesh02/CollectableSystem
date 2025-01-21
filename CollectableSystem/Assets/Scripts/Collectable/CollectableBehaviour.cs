using System;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour, ICollectable
{
    private CollectableItem m_collectableItemData;

    public void Init(CollectableItem collectableItemData)
    {
        m_collectableItemData = collectableItemData;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Player>())
        {
            return;
        }
        Collect();
    }

    public void Collect()
    {
        //TODO
    }
}