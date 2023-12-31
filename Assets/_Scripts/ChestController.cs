using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestController : MonoBehaviour
{
    [SerializeField] private GameObject chestCanvas;
    [SerializeField] private TMP_InputField inputField; 
    [SerializeField] private string correctCombination = "837"; 
    [SerializeField] private Animator chestAnimator;


    void Start()
    {
        chestCanvas.SetActive(false); 
        chestAnimator.SetBool("ChestOpen", false);
    }

    public void CheckCombination()
    {
        if (inputField.text == correctCombination)
        {
            Debug.Log("The chest unlocks with a click!");
            chestCanvas.SetActive(false);
            chestAnimator.SetBool("ChestOpen", true);
        }
        else
        {
            Debug.Log("Nothing happens. It seems the combination is incorrect.");
            inputField.text = "Try Aagin";
        }
    }
}
