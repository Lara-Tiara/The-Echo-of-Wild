using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject playerCanvas;
    [SerializeField] private float displayDuration = 3.0f;
    private bool isShowingCanvas = false;

    void Start() {
        playerCanvas.SetActive(false);
    }

    private void Update()
    {
        if (GameDataManager.hasChest && !isShowingCanvas)
        {
            Debug.Log("Showing player canvas");
            StartCoroutine(ShowCanvasTemporarily());
        }
    }

    private IEnumerator ShowCanvasTemporarily()
    {
        isShowingCanvas = true; // Set the flag to indicate the canvas is being shown
        yield return new WaitForSeconds(2.0f);
        playerCanvas.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        playerCanvas.SetActive(false);
        isShowingCanvas = false; // Reset the flag after displaying the canvas
    }
}

