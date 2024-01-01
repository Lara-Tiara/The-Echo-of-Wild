using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTrans : Singleton<SceneTrans>
{
    public bool isFadeIn;
    public float tranSpeed;

    public Image img;

    private void Start() {
        if(!isFadeIn)
        {
            img.gameObject.SetActive(true);
            StartCoroutine(FadeOut());
        }
    }

    public IEnumerator FadeOut()
    {
        while(img.color.a > 0.05f)
        {
            img.color -= new Color(0,0,0,tranSpeed);
            yield return new WaitForSeconds(0.05f);
        }

    }

    public IEnumerator FadeIn()
    {
        while(img.color.a < 1f)
        {
            Debug.Log(img.color.a);
            img.color += new Color(0,0,0,tranSpeed);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
