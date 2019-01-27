using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class casaHandler : MonoBehaviour
{
    public float maxHealth = 100;
    public float curHealth = 100;
    public float damage;
    public Image healthBar;

    public Room_Base[] comodos;

    public GameObject victoryScreen;
    public GameObject defeatScreen;

    void Start()
    {
        comodos = gameObject.GetComponentsInChildren<Room_Base>();
        InvokeRepeating("causeDamage", 10,10);
    }

    float calculateDamage(){
        for(int i=0;i<comodos.Length;i++){
            if (comodos[i].Dirtyness/comodos[i].DirtynessMax >= 0.5){
                damage+= comodos[i].Dirtyness/comodos[i].DirtynessMax * comodos[i].damageRatio;
            }
        }
        return damage;
    }

    void causeDamage(){
        curHealth -= calculateDamage();
        healthBar.fillAmount = curHealth/maxHealth;
       // healthBar.color = Color.Lerp(Color.red,Color,green,healthBar.fillAmount);
        if(Time.time >= 300){
            Victory();
        }else if (curHealth <=0){
            Defeat();
        }
            
    }

    void Defeat(){
        Time.timeScale = 0;
        defeatScreen.SetActive(true);
    }

    void Victory(){
      Time.timeScale = 0;
      victoryScreen.SetActive(true);
    }

   


    // Update is called once per frame

}
