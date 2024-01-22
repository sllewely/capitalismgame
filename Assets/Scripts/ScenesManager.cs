using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    
    public static ScenesManager Instance;

    // Must be in the same order as in Build Settings
    public enum Scene
    {
        MainMenu,
        Dungeon1,
        AlyciaScene,
    }
    
    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Dungeon1.ToString());
    }

    public void LoadTestGame()
    {
        SceneManager.LoadScene(Scene.AlyciaScene.ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }
}
