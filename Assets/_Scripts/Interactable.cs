using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[SerializeField] public bool playerInRange;
	[SerializeField] public string otherTag;
	//[SerializeField] public Notification myNotify;

	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag(otherTag))
		{
			Debug.Log("trigger enter");
			playerInRange = true;
			//myNotify.Raise();
		}
	}

	public virtual void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.CompareTag(otherTag))
		{
			Debug.Log("trigger exit");
			playerInRange = false;
			//myNotify.Raise();
		}
	}

}