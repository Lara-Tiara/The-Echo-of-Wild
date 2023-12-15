using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : Interactable
{
    [Header("Que Sign")]
    [SerializeField] private GameObject queSign;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
   
    private void Awake() {
        playerInRange = false;
        if (queSign == null) {
            Debug.LogError("Que Sign is not assigned in DialogueTrigger.");
            return;
        }
        queSign.SetActive(false);
    }
    private void Update(){
            if (queSign == null || inkJSON == null) {
                return; // Skip the update if either is null
            }
            Keyboard kb = InputSystem.GetDevice<Keyboard>();
            if(playerInRange){
                queSign.SetActive(true);
                
                if(kb.spaceKey.wasPressedThisFrame){
                    Debug.Log(inkJSON.text);
                }
            }else{
                queSign.SetActive(false);
            }
        }
}
