using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CheckEnd : MonoBehaviour
{
    private PlayableDirector director;

    private void Start() {
        director = GetComponent<PlayableDirector>();
    }

    private void Update() {
        if(director.state != PlayState.Playing)
        {
            SceneManager.LoadScene(0);
        }
    }
}
