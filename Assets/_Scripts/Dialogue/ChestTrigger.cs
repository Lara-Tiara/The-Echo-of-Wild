using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChestTrigger : MonoBehaviour
{
    [SerializeField] private GameObject queSign;
    [SerializeField] private GameObject chestCanvas;
    [SerializeField] private ChestController chestController;
    

    private bool playerInRange;
    public static bool isSignCanvasActive;
    private UserInput input;

    private void Awake() {
        input = new UserInput();
        input.Gameplay.Enable();

        playerInRange = false;
        
        //chestController = transform.parent.GetComponent<ChestController>();
        ValidateGameObjects();

        input.Gameplay.Talk.performed += ctx => ToggleSignCanvas();
    }

    private void Start() {
        isSignCanvasActive = false;
        chestCanvas.SetActive(false);
    }

    private void ValidateGameObjects() {
        if (queSign == null) {
            Debug.LogError("Que Sign is not assigned in DialogueTrigger.");
        }
        if (chestCanvas == null) {
            Debug.LogError("Sign Canvas is not assigned in DialogueTrigger.");
        }
        if (chestController == null) {
            Debug.LogError("ChestController is not assigned.");
        }
    }

    private void Update() {
        queSign.SetActive(playerInRange && !isSignCanvasActive);
        if (isSignCanvasActive && Input.GetKeyDown(KeyCode.Return)) {
            chestController?.OnSubmitCombination(); 
            //ToggleSignCanvas(); 
        }
    }

    private void ToggleSignCanvas() {
        if (playerInRange) {
            isSignCanvasActive = !isSignCanvasActive;
            chestCanvas.SetActive(isSignCanvasActive);

            GameDataManager.hasChest = true;

            if (isSignCanvasActive) {
                chestController.OnChestInteraction(); 
            }

            Debug.Log(isSignCanvasActive ? "Talk is pressed" : "Exit sign is pressed");
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = false;
        }
    }
}

