using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
	public Animator diceAni;
	public SpriteRenderer sr;
	private Color oColor;

	void Awake()
	{
		diceAni = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
		oColor = sr.color;
	}

	void Update()
	{
		CenterDice();
		if(Input.GetMouseButtonDown(0))
		{
			sr.color = new Color32(219,204,170,255);
			diceAni.SetBool("stop",false);
			diceAni.SetTrigger("roll");

			Debug.Log("roll the dice");
			StartCoroutine(RollDice());
			diceAni.SetFloat("present",(float)Random.Range(1,5));

		} else {
			sr.color = oColor;
		}
	}

	private void CenterDice()
	{
		Camera mainCamera = Camera.main;

		if(mainCamera != null){
			Vector3 cameraCenter = mainCamera.ViewportToWorldPoint(new Vector3(0.5f,0.5f,mainCamera.nearClipPlane));
			transform.position = new Vector3(cameraCenter.x, cameraCenter.y,transform.position.z);
		}
	}

	IEnumerator RollDice()
	{
		yield return new WaitForSeconds(2f);
		diceAni.SetBool("stop",true);
	}
}