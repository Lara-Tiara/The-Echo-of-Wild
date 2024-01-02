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
    }

    private IEnumerator ToScene(string target)
    {
        
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