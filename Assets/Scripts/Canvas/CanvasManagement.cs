using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManagement : MonoBehaviour
{
    [SerializeField] private MenuItem[] _menuItems;

    private MenuItem _currentMenuItem;

    private void Start()
    {
        foreach (MenuItem menuItem in _menuItems)
        {
            menuItem.OnClose += () => _currentMenuItem = null;
        }

        OpenMenu(MenuType.Play);
    }

    public void OpenMenu(MenuType menuType)
    {
        if (_currentMenuItem != null)
        {
            Debug.LogWarning("Ivalid " + menuType.ToString() + " openning!" + " " + _currentMenuItem.AssignedMenuType.ToString() + " is still opened.");
            return;
        }

        for (int i = 0; i < _menuItems.Length; i++)
        {
            if (_menuItems[i].AssignedMenuType == menuType)
            {
                _currentMenuItem = _menuItems[i];
                _currentMenuItem.Open();
                break;
            }
        }
    }
}

public enum MenuType
{
    Lose,
    Win,
    Play
}
