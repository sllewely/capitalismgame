using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button newGame;
    public Button loadGameButton;
    public Button testGameButton;
    public Button newGameButton;

    private void Awake()
    {
        loadGameButton = transform.Find("NewGameButton").GetComponent<Button>();
        if (loadGameButton is null)
        {
            Debug.LogError("NewGameButton not found");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        newGame.onClick.AddListener(StartNewGame);
        
    }

    private void StartNewGame()
    {
        ScenesManager.Instance.LoadNewGame();
    }
}
