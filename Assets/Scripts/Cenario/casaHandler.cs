using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class casaHandler : MonoBehaviour
{

    public Sprite[] PlayerPhotos;

    public Image[] ScoreImages;

    public Text[] Scores;


    public float maxHealth = 100;
    public float curHealth = 100;
    public float damage;
    public Image healthBar;

    public Room_Base[] comodos;

    public GameObject EndScreen;
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

    public void Reload(){
        SceneManager.LoadScene(0);
    }

    void Defeat(){
        Time.timeScale = 0;
        defeatScreen.SetActive(true);
        EndScreen.SetActive(true);
    }

    void Victory(){
    Time.timeScale = 0;
    EndScreen.SetActive(true);
    victoryScreen.SetActive(true);

    Player[] AllPlayers = FindObjectsOfType<Player>();

        for(int i=0;i<AllPlayers.Length;i++){
            ScoreImages[i].sprite = ScoreImages[i].sprite;
            Scores[i].text = AllPlayers[i].happyScore.ToString();
        }

    }

   


    // Update is called once per frame

}
