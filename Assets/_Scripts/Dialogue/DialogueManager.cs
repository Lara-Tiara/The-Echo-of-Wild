using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.PlayerLoop;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story currentStory;
    private bool dialogueIsPlaying;
    private static DialogueManager instance;

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
        dialogueBox.SetActive(false);
    }

    private void Update(){
        if(!dialogueIsPlaying){
            return;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogueBox.SetActive(true);

        ContinueStory();
    }

    private void ContinueStory(){
        if(currentStory.canContinue){
            dialogueText.text = currentStory.Continue();
        }else{
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode(){
        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);
        dialogueText.text = "";
    }
}
