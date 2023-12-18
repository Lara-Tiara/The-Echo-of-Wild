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
    //[SerializeField] private TextAssetValue dialogueValue;
    //[SerializeField] private DialogueCanvasController canvasController;
    public Story currentStory;
    public UserInput input;
    
    public bool dialogueIsPlaying{get; set; }
    private Coroutine displayLineCoroutine;
    private static DialogueManager instance;
    //private DialogueVariables dialogueVariables;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance(){
        return instance;
    }

    private void Start(){
        dialogueIsPlaying = false;
        dialogueCanvas.SetActive(false);
    }

    private void Update(){
        if(!dialogueIsPlaying){
            return;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogueCanvas.SetActive(true);
        //SetStory();
        //canvasController.RefreshView();
    }

    /*
    public void SetStory() {
        if (dialogueValue.value) {
            currentStory = new Story(dialogueValue.value.text);
        } else {
            Debug.Log("Story setup error");
        }
    }
    */

    private void ExitDialogueMode() {
        dialogueIsPlaying = false;
        dialogueCanvas.SetActive(false);
    }
}
