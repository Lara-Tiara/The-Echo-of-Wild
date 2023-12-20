using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
<<<<<<< HEAD
    [SerializeField] public GameObject dialogueCanvas;
    public Story currentStory;
    public UserInput input;
    public DialogueCanvasController canvasController;
    public static bool dialogueIsPlaying;
=======
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject dialogueText;
    private Story currentStory;
    public UserInput input;
    
    public bool dialogueIsPlaying{get; set; }
    //private bool canContinueToNextLine = false;
    private Coroutine displayLineCoroutine;
>>>>>>> parent of 5b93594f (Update)
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
        dialogueBox.SetActive(false);
    }

    private void Update() {
        Debug.Log(dialogueIsPlaying);
        if(!dialogueIsPlaying){
            return;
        }
    }
<<<<<<< HEAD

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
=======
    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogueBox.SetActive(true);

        //dialogueVariables.StartListening(currentStory);

        //ContinueStory();
    }

    private void ContinueStory() {
        if (currentStory.canContinue) {
            //dialogueText.text = currentStory.Continue();
        } else {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode() {
        //yield return new WaitForSeconds(0.2f);

        //dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);
        //dialogueText.text = "";
    }
    /*
     private void ContinueStory() {
        if (currentStory.canContinue) 
        {
            // set text for the current dialogue line
            if (displayLineCoroutine != null) 
            {
                StopCoroutine(displayLineCoroutine);
            }
            //displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            // handle tags
            //HandleTags(currentStory.currentTags);
        }
        else 
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    */
>>>>>>> parent of 5b93594f (Update)
}
