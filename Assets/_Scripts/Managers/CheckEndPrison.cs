using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CheckEndPrison : MonoBehaviour
{
    private PlayableDirector director;
   
    [SerializeField] private GameObject canvas;

    private void Start() {
        director = GetComponent<PlayableDirector>();
    }

    private void Update() {
        if(director.state != PlayState.Playing)
        {
            Destroy(canvas);
        }
    }
}
