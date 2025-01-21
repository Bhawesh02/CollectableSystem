
using UnityEngine;

[CreateAssetMenu(fileName = "New Collectable Item", menuName = "New Collectable Item")]
public class CollectableItem : ScriptableObject
{
    public string collectableName;
    public Sprite collectableIcon;
    public ICollectable collectablePrefab;
}
