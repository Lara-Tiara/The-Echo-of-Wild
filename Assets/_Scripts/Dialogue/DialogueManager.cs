using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] public GameObject dialogueCanvas;
    public DialogueCanvasController canvasController;
    public Story currentStory;
    public UserInput input;

    public static bool dialogueIsPlaying;
    private static DialogueManager instance;

    private void Awake() {
        if(instance != null){
            //Destroy(gameObject);
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
        //Debug.Log(dialogueIsPlaying);
        if(!dialogueIsPlaying){
            return;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
    currentStory = new Story(inkJSON.text);

    currentStory.BindExternalFunction("playSound", (string name) => {
        AudioManager.Instance.PlayOneShot(name);
    });

    currentStory.BindExternalFunction("loadScene", (string sceneName) => {
        SceneManager.LoadScene(sceneName);
    });

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
