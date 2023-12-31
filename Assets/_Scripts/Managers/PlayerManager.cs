using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerControl pc;
    public LionController lc;

    public bool pcBool;
    public bool lcBool;

    public float pcTime;
    public float lcTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetPc());
        StartCoroutine(SetLc());
    }

    private IEnumerator SetPc()
    {
        yield return new WaitForSeconds(pcTime);
        pc.enabled = pcBool;
    }

    private IEnumerator SetLc()
    {
        yield return new WaitForSeconds(lcTime);
        lc.enabled = lcBool;
        if(lcBool)
        {
            lc.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
