using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")] [SerializeField]
    private string fileName;
    
    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("found more than one data persistence manager in the scene");
        }

        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        // LoadGame();
        // Debug.Log("Saved in: " + Application.persistentDataPath.ToString());
        Debug.Log("Begin from new game state");
        NewGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {

        this.gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    // preconfigured state for easy testing
    public void LoadTestGame()
    {
        
    }

    // Saves game to a file.
    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        
        dataHandler.Save(gameData);
    }

    // Does not save game to file.  Used for persisting state between scenes.
    public void TempSaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
    }

    // public void OnApplicationQuit()
    // {
    //     SaveGame();
    // }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects =
            FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
                .OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
