using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using Ink.UnityIntegration;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] public GameObject dialogueCanvas;
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    public DialogueCanvasController canvasController;
    public Story currentStory;
    public UserInput input;

    public static bool dialogueIsPlaying;
    private static DialogueManager instance;
    private DialogueVariables dialogueVariables;

    private void Awake() {
        if(instance != null){
            //Destroy(gameObject);
        }
        instance = this;

        //dialogueVariables = new DialogueVariables();
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
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
        if(GameDataManager.hasChest == true){
            currentStory.variablesState["check_chest"] = true;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        canvasController.CloseDialogs();
        currentStory = new Story(inkJSON.text);

        currentStory.BindExternalFunction("playSound", (string name) => {
            AudioManager.Instance.PlayOneShot(name);
        });

        currentStory.BindExternalFunction("loadScene", (string sceneName) => {
            SceneManager.LoadScene(sceneName);
        });

        

        dialogueIsPlaying = true;
        dialogueCanvas.SetActive(true);

        dialogueVariables.StartListening(currentStory);
    
        canvasController.currentStory = currentStory;
        canvasController.RefreshView();
    }


    public void ExitDialogueMode() {
        dialogueIsPlaying = false;
        dialogueCanvas.SetActive(false);

        dialogueVariables.StopListening(currentStory);

        canvasController.CloseDialogs();
        canvasController.CloseChoices();
    }
}
