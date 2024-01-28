using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be attached to the active parent of GameMenuUI

public class GameMenuUIBehavior : MonoBehaviour
{
    
    private DataPersistenceManager _dataPersistenceManager;
    public GameObject gameMenuUI;
    
    void Awake()
    {
        _dataPersistenceManager = GameObject.Find("Managers/DataPersistenceManager").GetComponent<DataPersistenceManager>();
        if (_dataPersistenceManager == null)
        {
            Debug.LogError("DataPersistenceManager not found");
        }

        if (gameMenuUI == null)
        {
            Debug.LogError("GameMenuUI not found");
        }
    }

    public void OnSaveGameButton()
    {
        _dataPersistenceManager.SaveGame();
        gameMenuUI.SetActive(false);
    }

    public void OnLoadGameButton()
    {
        _dataPersistenceManager.LoadGame();
        gameMenuUI.SetActive(false);
    }

    public void OnExitGameButton()
    {
        Application.Quit();
        Debug.Log("I think this doesn't work while running in the unity editor");
        gameMenuUI.SetActive(false);
    }
}
