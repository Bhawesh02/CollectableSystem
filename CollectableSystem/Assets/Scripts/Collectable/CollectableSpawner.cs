using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableSpawner : MonoBehaviour
{
    private const float HALF = 0.5f;
    
    [SerializeField] private List<CollectableItem> m_collectableItems;
    [SerializeField] private CollectableBehaviour m_collectablePrefab;
    [SerializeField] private Vector2 m_spawnBound;
    [SerializeField] private int m_spawnCount;

    private CollectableItem m_collectableItemToSpawn;
    private Vector3 m_spawnPosition = Vector3.zero;
    private CollectableBehaviour m_spawnedItem;
    private Vector2 m_halfSpawnBound;
    private CollectablePoolService m_collectablePool;

    private void Awake()
    {
        GameplayEvents.OnCollectableCollected += HandleOnCollectableCollected;
    }

    private void OnDestroy()
    {
        GameplayEvents.OnCollectableCollected -= HandleOnCollectableCollected;
    }

    private void Start()
    {
        m_halfSpawnBound = m_spawnBound * HALF;
        m_collectablePool = new CollectablePoolService(m_collectablePrefab, transform);
        SpawnCollectables();
    }

    private void SpawnCollectables()
    {
        for (int collectableIndex = 0; collectableIndex < m_spawnCount; collectableIndex++)
        {
            m_collectableItemToSpawn = m_collectableItems[Random.Range(0, m_collectableItems.Count)];
            m_spawnPosition.x = Random.Range(-m_halfSpawnBound.x, m_halfSpawnBound.x);
            m_spawnPosition.z = Random.Range(-m_halfSpawnBound.y, m_halfSpawnBound.y);
            m_spawnedItem = m_collectablePool.GetItem();
            m_spawnedItem.Init(m_collectableItemToSpawn, m_spawnPosition);
        }
    }
    
    private void HandleOnCollectableCollected(CollectableItem collectableItem, CollectableBehaviour collectableBehaviour)
    {
        m_collectablePool.ReturnItem(collectableBehaviour);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(m_spawnBound.x, 0f, m_spawnBound.y));
    }
}
