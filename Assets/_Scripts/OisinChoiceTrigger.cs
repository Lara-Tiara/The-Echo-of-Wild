using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OisinChoiceTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!DialogueManager.dialogueIsPlaying) {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }
}