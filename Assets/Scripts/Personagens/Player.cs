using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Player : MonoBehaviour
{

    public Interagir myInteractions;
    public Room_Base currentRoom;
    public int playerNumber;
    public bool isBusy;
    public int busyTimer;
    public Image busyClock;
    public float hunger = 100*30;
    public float higiene = 100*30;
    public float tired = 100*30;
    public float social = 100*30;
    public float enjoy = 100*30;
    
    public float hungerRate;
    public float higieneRate;
    public float tiredRate;
    public float socialRate;
    public float enjoyRate;

    public void eat(){
        if(isBusy) return;
        this.hunger = 100;
        isBusy = true;
        busyTimer = 20*30;
        startTimer(busyTimer);
    }
    public void sleep(){
        if(isBusy) return;
        this.tired = 100;
        isBusy = true;
        busyTimer = 30*30;
        startTimer(busyTimer);
    }

    public void clean(){
        if(isBusy) return;
        this.higiene = 100;
        isBusy = true;
        busyTimer = 40*30;
        startTimer(busyTimer);
    }
    public void socialize(){
        if(isBusy) return;
        this.social = 100;
        isBusy = true;
        busyTimer = 50*30;
        startTimer(busyTimer);
    }

    public void entertain(){
        if(isBusy) return;
        this.enjoy = 100;
        isBusy = true;
        busyTimer = 60*30;
        startTimer(busyTimer);
    }

    void FixedUpdate(){
        if(busyTimer>0){
            busyTimer--;
        }else{
            busyTimer = 0;
            isBusy = false;
            consumeResources();
        }
    }

    public void consumeResources(){
        if(hunger>0)
        hunger -= hungerRate;
        if(higiene>0)
        higiene -= higieneRate;
        if(tired>0)
        tired -= tiredRate;
        if(enjoy>0)
        enjoy -= enjoyRate;
        if(social>0)
        social -= socialRate;
    }


    public void startTimer(int time){
        busyClock.gameObject.SetActive(true);
        busyClock.gameObject.GetComponent<ClockHandler>().maxTime = time;
        busyClock.gameObject.GetComponent<ClockHandler>().curTime = time;
    }
}
