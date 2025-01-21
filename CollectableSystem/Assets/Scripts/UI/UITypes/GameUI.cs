using UnityEngine;

public class GameUI : MonoBehaviour, IUIHandler
{
    [SerializeField] private GameObject m_uiHolder;
    
    public virtual void OnShow()
    {
        m_uiHolder.gameObject.SetActive(true);
    }

    public virtual void OnHide()
    {
        m_uiHolder.gameObject.SetActive(false);
    }
}