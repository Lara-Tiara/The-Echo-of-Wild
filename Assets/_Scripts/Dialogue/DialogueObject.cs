using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class DialogueObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myText;

    public void Setup(string newDialogue) {
        myText.text = newDialogue;
        Debug.Log(newDialogue == "You opend the trap with your hands." || newDialogue == "You decide to use the forbidden magic to save the lion.");
        if(newDialogue.Contains("forbidden magic") || newDialogue.Contains("your hands."))
        {
            StartCoroutine(ToCutScene());
        }
    }

    private IEnumerator ToCutScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("CutscenePrison");
        DialogueManager.dialogueIsPlaying = false;
    }
}