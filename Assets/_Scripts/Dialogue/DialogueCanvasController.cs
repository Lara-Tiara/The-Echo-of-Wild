using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCanvasController : MonoBehaviour
{
    [SerializeField] private float dialogueDelay = 0.5f;
    [SerializeField] private GameObject dialoguePrefab;
    [SerializeField] private GameObject choicePrefab;
    [SerializeField] private TextAssetValue dialogueValue;
    [SerializeField] private GameObject dialogueHolder;
    [SerializeField] private GameObject choiceHolder;
    [SerializeField] private ScrollRect dialogueScroll;
    [HideInInspector] public Story currentStory;

     public void RefreshView() {
        StartCoroutine(ShowDialogueWithDelay());
    }

    IEnumerator ShowDialogueWithDelay() {
        while (currentStory.canContinue) {
            MakeNewDialogue(currentStory.Continue());
            yield return new WaitForSeconds(dialogueDelay);
            yield return StartCoroutine(ScrollCo()); 
        }

        if(currentStory.currentChoices.Count > 0) {
            MakeNewChoice();
        } else {
            CloseChoices();
        }
    }

    IEnumerator ScrollCo()
    {
        yield return null;
        Canvas.ForceUpdateCanvases();
        dialogueScroll.verticalNormalizedPosition = 0f;
    }

    public void MakeNewDialogue(string newDialogue) {
        DialogueObject newDialogueObject = 
            Instantiate(dialoguePrefab, dialogueHolder.transform).GetComponent<DialogueObject>();
        newDialogueObject.Setup(newDialogue);
    }

    public void MakeNewResponse(string newDialogue, int choiceValue) {
        ResponseObject newResponseObject =
            Instantiate(choicePrefab, choiceHolder.transform).GetComponent<ResponseObject>();
        newResponseObject.Setup(newDialogue, choiceValue);

        Button responseButton = newResponseObject.gameObject.GetComponent<Button>();

        if (responseButton) {
            responseButton.onClick.AddListener(delegate{ChooseChoice(choiceValue);});
        }
    }

    public void CloseChoices()
    {
        for (int i = 0; i < choiceHolder.transform.childCount; i++)
        {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }
    }

    public void CloseDialogs()
    {
        for (int i = 0; i < dialogueHolder.transform.childCount; i++)
        {
            Destroy(dialogueHolder.transform.GetChild(i).gameObject);
        }
    }

    private void MakeNewChoice() {
        CloseChoices();

        for (int i = 0; i < currentStory.currentChoices.Count; i++) {
            MakeNewResponse(currentStory.currentChoices[i].text, i);
        }
    }

    public void ChooseChoice(int choice) {
        currentStory.ChooseChoiceIndex(choice);
        RefreshView();
    }
}