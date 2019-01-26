using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockHandler : MonoBehaviour
{
    public float maxTime;
    public float curTime;
    void FixedUpdate(){
        curTime--;
        this.gameObject.GetComponent<Image>().fillAmount = curTime/maxTime;
        if (curTime == 0)
        this.gameObject.SetActive(false);
        
    }
}
