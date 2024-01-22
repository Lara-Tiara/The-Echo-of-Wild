using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAttacted : MonoBehaviour
{
    [SerializeField] Transform Hp;
    [SerializeField] GameObject codeSign;

    // Start is called before the first frame update
    void Start()
    {
        codeSign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int BeActtackedCount = 0;
    public void BeActtacked(){
        BeActtackedCount++;
        switch(BeActtackedCount)
        {
            case 1:
                Hp.localPosition = new Vector3(-0.035f,Hp.localPosition.y,0);
                Hp.localScale = new Vector3(.05f,Hp.localScale.y,Hp.localScale.z);
                break;
            case 2:
                Hp.localScale = Vector3.zero;
                gameObject.SetActive(false);
                codeSign.SetActive(true);
                break;
        }
    }
}
