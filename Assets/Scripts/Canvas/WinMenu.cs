using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MenuItem
{
    public override MenuType AssignedMenuType { get; protected set; } = MenuType.Win;

    private bool _isButtonTouched = false;

    public void NextLevel()
    {
        if (_isButtonTouched) return;

        Close();
        SceneManagement.SetLevelResult(true);

        _isButtonTouched = true;
    }

    protected override void OpenInstruction()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    protected override void CloseInstruction()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}