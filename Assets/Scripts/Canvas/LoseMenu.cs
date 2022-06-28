using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MenuItem
{
    public override MenuType AssignedMenuType { get; protected set; } = MenuType.Lose;
    private bool _isButtonTouched;

    public void RestartLevel()
    {
        if (_isButtonTouched) return;

        SceneManagement.SetLevelResult(false);

        Close();

        _isButtonTouched = true;
    }

    protected override void OpenInstruction()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    protected override void CloseInstruction()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}