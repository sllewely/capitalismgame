using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button newGame;
    
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
