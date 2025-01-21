using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour
{
    private const string COUNT_TEXT_PREFIX = "Count : ";
    
    [SerializeField] private Image m_iconHolder;
    [SerializeField] private TextMeshProUGUI m_itemName;
    [SerializeField] private TextMeshProUGUI m_count;

    public void Config(CollectableItem collectableItem, int count)
    {
        m_iconHolder.sprite = collectableItem.collectableIcon;
        m_itemName.text = collectableItem.collectableName;
        UpdateCount(count);
    }

    public void UpdateCount(int count)
    {
        m_count.text = COUNT_TEXT_PREFIX + count;
    }
}