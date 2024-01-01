using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class MainCanvasController : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject creditPanel;

    
    void Start()
    {
        creditsButton.onClick.AddListener(ToggleCredits);
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);

        creditPanel.SetActive(false);
    }

    
    void Update()
    {
        
    }

    
    void ToggleCredits()
    {
        creditPanel.SetActive(!creditPanel.activeSelf);
    }

    
    void StartGame()
    {
        
        SceneManager.LoadScene("Scene1_Forest");
    }

    void ExitGame()
    {
        Application.Quit();

        // If running in the Unity editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
