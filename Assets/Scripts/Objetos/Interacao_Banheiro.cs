using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Banheiro : Interacao_Base{

    public float Filth;
    public float FilthMax;
    public float FilthRate;
    public int CleanTime;

    public override void Execute(Player activePlayer){
        if(Filth < 80){
            if(activePlayer.isBusy) return;
            
            Occupied = true;
            activePlayer.higiene = 100;
            activePlayer.isBusy = true;
            activePlayer.busyTimer = UseTime*30;
            Filth += FilthRate;
            
            if(Filth > FilthMax){
                Filth = FilthMax;
            }
            
            activePlayer.startTimer(activePlayer.busyTimer);
            
            Invoke("DeOccupie",UseTime);
        }else{
            if(activePlayer.myInteractions.HoldingObj){
               if(activePlayer.myInteractions.HoldingObj is Interacao_Rodo){
                   if(activePlayer.isBusy) return;
            
                    Occupied = true;
                    Filth = 0;
                    activePlayer.isBusy = true;
                    activePlayer.busyTimer = CleanTime*30;
                    activePlayer.enjoy = Mathf.Clamp(activePlayer.enjoy - toReduceEnjoy,0,activePlayer.enjoy);

                    activePlayer.startTimer(activePlayer.busyTimer);

                    Invoke("DeOccupie",UseTime);
               }
            }
        }
        
    }

    void Start(){
        
    }

    void Update(){
        
    }
}
