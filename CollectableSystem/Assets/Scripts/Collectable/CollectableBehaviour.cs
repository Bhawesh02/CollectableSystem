using System;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour, ICollectable
{
    [SerializeField] private MeshRenderer m_meshRenderer;
    
    private CollectableItem m_collectableItemData;

    public void Init(CollectableItem collectableItemData, Vector3 position)
    {
        m_collectableItemData = collectableItemData;
        m_meshRenderer.material = collectableItemData.collectableMaterial;
        transform.localPosition = position;
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
        GameplayEvents.SendOnCollectableCollected(m_collectableItemData, this);
    }
}