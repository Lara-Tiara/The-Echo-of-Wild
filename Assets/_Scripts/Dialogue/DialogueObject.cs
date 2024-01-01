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
        //跳转到CutScene
        if(newDialogue.Contains("forbidden magic") || newDialogue.Contains("your hands."))
        {
            StartCoroutine(ToScene("CutscenePrison"));
        }
        //结局4
        if(newDialogue.Contains("You are safe now"))
        {
            StartCoroutine(ToScene("Ending4"));
        }
        //结局3
        if(newDialogue.Contains("This is not the end"))
        {
            StartCoroutine(ToScene("Ending3"));
        }
    }

    private IEnumerator ToScene(string target)
    {
        //场面过渡
        SceneTrans.Instance.img.gameObject.SetActive(true);
        if(SceneTrans.Instance.isFadeIn)
            StartCoroutine(SceneTrans.Instance.FadeIn());
        else
            StartCoroutine(SceneTrans.Instance.FadeOut());

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(target);
        DialogueManager.dialogueIsPlaying = false;
    }
}