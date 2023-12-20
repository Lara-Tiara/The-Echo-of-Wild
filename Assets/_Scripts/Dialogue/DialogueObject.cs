using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myText;

    public void Setup(string newDialogue) {
        myText.text = newDialogue;
    }
}