using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagement : MonoBehaviour
{
    private CanvasManagement _canvasManagement;

    private void Start()
    {
        _canvasManagement = FindObjectOfType<CanvasManagement>();
    }

    public void SetLevelStatus(GameStatusType gameStatusType)
    {
        switch (gameStatusType)
        {
            case GameStatusType.Win:
                _canvasManagement.OpenMenu(MenuType.Win);
                break;

            case GameStatusType.Lose:
                _canvasManagement.OpenMenu(MenuType.Lose);
                break;
        }
    }
}

public enum GameStatusType
{
    Win,
    Lose
}
