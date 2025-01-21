using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const KeyCode INVENTORY_KEY_CODE = KeyCode.I;
    
    [SerializeField] private PlayerData m_playerData;

    private float m_horizontalInput;
    private float m_verticalInput;
    private bool m_isInputAllowed = true;

    private void Awake()
    {
        GameplayEvents.OnShowUI += HandleOnShowUI;
        GameplayEvents.OnHideUI += HandleOnHideUI;
    }

    private void OnDestroy()
    {
        GameplayEvents.OnShowUI -= HandleOnShowUI;
        GameplayEvents.OnHideUI -= HandleOnHideUI;
    }

    private void HandleOnShowUI(UITypes uiType)
    {
        m_isInputAllowed = uiType == UITypes.INVENTORY;
    }
    private void HandleOnHideUI()
    {
        m_isInputAllowed = true;
    }

    private void Update()
    {
        if (!m_isInputAllowed)
        {
            return;
        }
        m_horizontalInput = Input.GetAxis(HORIZONTAL_AXIS);
        m_verticalInput = Input.GetAxis(VERTICAL_AXIS);
        Move();
        Rotate();
        if (Input.GetKeyDown(INVENTORY_KEY_CODE))
        {
            GameplayEvents.SendOnShowUI(UITypes.INVENTORY);
        }
    }

    private void Move()
    {
        transform.position += transform.forward * (m_verticalInput * m_playerData.movementSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.rotation *= Quaternion.Euler(0f, (m_horizontalInput * m_playerData.rotationSpeed * Time.deltaTime), 0);;
    }
}