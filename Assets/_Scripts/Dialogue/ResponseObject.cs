using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myText;

    private int choiceValue;

    public void Setup(string newDialogue, int myChoice) {
        myText.text = newDialogue;
        choiceValue = myChoice;
    }
}