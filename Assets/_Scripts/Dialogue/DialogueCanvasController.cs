using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCanvasController : DialogueManager
{
    [SerializeField] private GameObject dialoguePrefab;
    [SerializeField] private GameObject choicePrefab;
    [SerializeField] private TextAssetValue dialogueValue;
    [SerializeField] private GameObject dialogueHolder;
    [SerializeField] private GameObject choiceHolder;
    [SerializeField] private ScrollRect dialogueScroll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshView() {
        while (currentStory.canContinue) {
            MakeNewDialogue(currentStory.Continue());
        }

        if(currentStory.currentChoices.Count > 0) {
            MakeNewChoice();
        } else {
            dialogueCanvas.SetActive(false);
        }
        StartCoroutine(ScrollCo());
    }

    IEnumerator ScrollCo() {
        yield return null;
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

    private void MakeNewChoice() {
        for (int i = 0; i < choiceHolder.transform.childCount; i++) {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < currentStory.currentChoices.Count; i++) {
            MakeNewResponse(currentStory.currentChoices[i].text, i);
        }
    }

    public void ChooseChoice(int choice) {
        currentStory.ChooseChoiceIndex(choice);
        RefreshView();
    }
}
