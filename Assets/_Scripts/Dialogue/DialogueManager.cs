using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] public GameObject dialogueCanvas;
    public Story currentStory;
    public UserInput input;
    public DialogueCanvasController canvasController;
    public static bool dialogueIsPlaying;

    
    //private bool canContinueToNextLine = false;
    private Coroutine displayLineCoroutine;
    private static DialogueManager instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance() {
        return instance;
    }

    private void Start() {
        dialogueIsPlaying = false;
    }

    private void Update() {
        Debug.Log(dialogueIsPlaying);
        if(!dialogueIsPlaying){
            return;
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON) {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogueCanvas.SetActive(true);
        canvasController.currentStory = currentStory;
        canvasController.RefreshView();
    }

    public void ExitDialogueMode() {
        dialogueIsPlaying = false;
        dialogueCanvas.SetActive(false);

        canvasController.CloseDialogs();
        canvasController.CloseChoices();
    }
}
