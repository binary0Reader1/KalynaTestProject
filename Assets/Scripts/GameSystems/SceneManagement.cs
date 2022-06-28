using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static int LevelNum { get; private set; } = 1;
    public static bool IsLevelCompleted { get; private set; }

    private int LevelsCount => SceneManager.sceneCountInBuildSettings - 1;

    private void Start()
    {
        if (IsLevelCompleted) LevelNum++;

        if (LevelNum > LevelsCount) LevelNum = 1; 

        LoadLevel();
    }

    public static void SetLevelResult(bool isLevelCompleted)
    {
        IsLevelCompleted = isLevelCompleted;
        SceneManager.LoadScene(0);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(LevelNum);
        IsLevelCompleted = false;
    }
}
