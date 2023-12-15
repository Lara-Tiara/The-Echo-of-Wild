using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField] public bool playerInRange;
    [SerializeField] public string otherTag;
	[SerializeField] public Notification myNotification;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }

    public virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            playerInRange = true;
			myNotification.Raise();
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            playerInRange = false;
			myNotification.Raise();
        }
    }
}