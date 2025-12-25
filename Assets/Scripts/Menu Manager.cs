using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Provides functions for maintaining menus in game.
/// 
/// Author: William Min
/// Date: 12/25/25
/// </summary>
public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Toggles pause of game.
    /// </summary>
    /// <param name="isPaused"></param>
    public void TogglePause(bool isPaused)
    {
        Time.timeScale = isPaused ? 0 : 1;
    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public void ExitGame()
    {
        #if UNITY_EDITOR

                EditorApplication.isPlaying = false;

        #else

        // For a built game, you would use Application.Quit();
        Application.Quit();

        #endif
    }
}
