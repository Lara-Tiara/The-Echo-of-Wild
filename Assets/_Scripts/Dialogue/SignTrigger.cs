using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SignTrigger : MonoBehaviour
{
    public string targetTag = "Player";
    [SerializeField] private GameObject queSign;
    [SerializeField] private GameObject signCanvas;
    //[SerializeField] private ChestController chestController;
    

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
        signCanvas.SetActive(false);
    }

    private void ValidateGameObjects() {
        if (queSign == null) {
            Debug.LogError("Que Sign is not assigned in DialogueTrigger.");
        }
        if (signCanvas == null) {
            Debug.LogError("Sign Canvas is not assigned in DialogueTrigger.");
        }
        
    }

    private void Update() {
        queSign.SetActive(playerInRange && !isSignCanvasActive);
        if (isSignCanvasActive && Input.GetKeyDown(KeyCode.Return)) {
            ToggleSignCanvas(); 
        }
    }

    private void ToggleSignCanvas() {
        if (playerInRange) {
            isSignCanvasActive = !isSignCanvasActive;
            signCanvas.SetActive(isSignCanvasActive);

            //GameDataManager.hasChest = true;

            if (isSignCanvasActive) {
                //chestController.OnChestInteraction(); 
            }

            //Debug.Log(isSignCanvasActive ? "Talk is pressed" : "Exit sign is pressed");
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(targetTag)) {
            playerInRange = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag(targetTag)) {
            playerInRange = false;
        }
    }
}
