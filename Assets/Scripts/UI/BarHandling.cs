using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHandling : MonoBehaviour
{
    public Player associatedPlayer;
    public int barType;

    void FixedUpdate(){
        if (barType ==0)
        this.gameObject.GetComponent<Image>().fillAmount = associatedPlayer.hunger*30/3000;
        else if (barType ==1)
        this.gameObject.GetComponent<Image>().fillAmount = associatedPlayer.higiene*30/3000;
        else if (barType ==2)
        this.gameObject.GetComponent<Image>().fillAmount = associatedPlayer.tired*30/3000;
        else if (barType ==3)
        this.gameObject.GetComponent<Image>().fillAmount = associatedPlayer.enjoy*30/3000;
        else if (barType ==4)
        this.gameObject.GetComponent<Image>().fillAmount = associatedPlayer.social*30/3000;
    }
}
