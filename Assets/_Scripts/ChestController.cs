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
    [SerializeField] private Animator portalAnimator;
    [SerializeField] private GameObject firstPlaceholder;
    [SerializeField] private GameObject secondPlaceholder;
    [SerializeField] private GameObject sceneTransition;
    [SerializeField] private GameObject signTrigger;
    private PlayerState playerState = new PlayerState();

    void Awake() {
        sceneTransition.SetActive(false);
    }
    void Start() {
        chestCanvas.SetActive(false);
    }

    public void OnChestInteraction() {
        playerState.SetChestOpened(true);
        inputField.text = "";
        firstPlaceholder.SetActive(true);
        secondPlaceholder.SetActive(false);
        chestCanvas.SetActive(true);
    }

    public void OnSubmitCombination() {
        if (inputField.text == correctCombination) {
            Debug.Log("The chest unlocks with a click!");
            chestAnimator.SetTrigger("isOpen");
            chestCanvas.SetActive(false);
            AudioManager.Instance.PlayOneShot("ChestOpen");
            StartCoroutine(portalOpen());
            signTrigger.SetActive(false);

            SignTrigger.isSignCanvasActive = false;
        }
        else {
            Debug.Log("Nothing happens. It seems the combination is incorrect.");
            firstPlaceholder.SetActive(false);
            secondPlaceholder.SetActive(true);
            inputField.text = "";
        }
    }

     private IEnumerator portalOpen() {
        int time = 5;
        yield return new WaitForSeconds(time);
        portalAnimator.SetTrigger("portalOpen");
        AudioManager.Instance.PlayOneShot("PortalOpen");
        sceneTransition.SetActive(true);
    }
}
