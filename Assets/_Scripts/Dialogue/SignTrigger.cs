using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SignTrigger : MonoBehaviour
{
    [SerializeField] private GameObject queSign;
    [SerializeField] private GameObject signCanvas;

    private bool playerInRange;
    private bool isSignCanvasActive;
    private UserInput input;

    private void Awake() {
        input = new UserInput();
        input.Gameplay.Enable();

        playerInRange = false;
        isSignCanvasActive = false;

        ValidateGameObjects();

        input.Gameplay.Talk.performed += ctx => ToggleSignCanvas();
    }

    private void Start() {
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
    }

    private void ToggleSignCanvas() {
        if (playerInRange) {
            isSignCanvasActive = !isSignCanvasActive;
            signCanvas.SetActive(isSignCanvasActive);

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
