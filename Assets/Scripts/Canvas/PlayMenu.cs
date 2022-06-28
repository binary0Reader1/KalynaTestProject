using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayMenu : MenuItem
{
    public override MenuType AssignedMenuType { get; protected set; } = MenuType.Play;
    [SerializeField] private TextMeshProUGUI _levelCounter;

    protected override void OpenInstruction()
    {
        _levelCounter.text = "Level: " + Convert.ToString(SceneManagement.LevelNum);

        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    protected override void CloseInstruction()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
