using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject queSign;
    [SerializeField] private TextAsset inkJSON;
     private bool playerInRange;
     public UserInput input;
   
    private void Awake() {
        input = new UserInput();
        input.Gameplay.Enable();
        
        playerInRange = false;
        
        if (queSign == null) {
            Debug.LogError("Que Sign is not assigned in DialogueTrigger.");
            return;
        }
        queSign.SetActive(false);
        input.Gameplay.Talk.performed += ctx => Talk(ctx);
    }
    private void Update() {
        if (queSign == null || inkJSON == null) {
            return; // Skip the update if either is null
        }
        
        if (playerInRange){
            queSign.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (!DialogueManager.dialogueIsPlaying) {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                } else {
                    DialogueManager.GetInstance().ExitDialogueMode();
                    Debug.Log("Talk is pressed");
                }
            }
        }else {
            queSign.SetActive(false);
        }
    }

    public void Talk(InputAction.CallbackContext context) {
        
    }
    public virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            playerInRange = false;
        }
    }

}
