using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableSpawner : MonoBehaviour
{
    private const float HALF = 0.5f;
    
    [SerializeField] private List<CollectableItem> m_collectableItems;
    [SerializeField] private Vector2 m_spawnBound;
    [SerializeField] private int m_spawnCount;

    private CollectableItem m_collectableItemToSpawn;
    private Vector3 m_spawnPosition;
    private CollectableBehaviour m_spawnedItem;
    private Vector3 m_spawnStartPosition;
    private Vector2 m_halfSpawnBound;
    private void Start()
    {
        m_spawnStartPosition = transform.position;
        m_halfSpawnBound = m_spawnBound * HALF;
        SpawnCollectables();
    }

    private void SpawnCollectables()
    {
        for (int collectableIndex = 0; collectableIndex < m_spawnCount; collectableIndex++)
        {
            m_collectableItemToSpawn = m_collectableItems[Random.Range(0, m_collectableItems.Count)];
            m_spawnPosition = Vector3.zero;
            m_spawnPosition.x = Random.Range(-m_halfSpawnBound.x, m_halfSpawnBound.x);
            m_spawnPosition.z = Random.Range(-m_halfSpawnBound.y, m_halfSpawnBound.y);
            m_spawnPosition += m_spawnStartPosition;
            m_spawnedItem = Instantiate(m_collectableItemToSpawn.collectablePrefab, m_spawnPosition, Quaternion.identity, transform);
            m_spawnedItem.Init(m_collectableItemToSpawn);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(m_spawnBound.x, 0f, m_spawnBound.y));
    }
}
