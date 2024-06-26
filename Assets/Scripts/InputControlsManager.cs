using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputControlsManager : MonoBehaviour
{
    
    private InputControls input = null;

    public GameObject inventoryUI;
    public GameObject gameMenuUI;
    
    private void Awake()
    {
        input = new InputControls();
        input.Enable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (inventoryUI == null)
        {
            Debug.LogError("InputControlsManager missing inventoryUI");
        }
        input.Player.OpenInventory.performed += pressed =>
        {
            // Toggle Inventory open/close
            var isInventoryOpen = inventoryUI.activeSelf;
            inventoryUI.SetActive(!isInventoryOpen);
        };

        if (gameMenuUI == null)
        {
            Debug.LogError("InputControlsManager missing gameMenuUI");
        }
        input.Player.OpenMainMenu.performed += pressed =>
        {
            var isGameMenuOpen = gameMenuUI.activeSelf;
            gameMenuUI.SetActive(!isGameMenuOpen);
        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
