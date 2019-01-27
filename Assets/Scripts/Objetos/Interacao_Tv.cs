using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Tv : Interacao_Base{

    public override void Execute(Player activePlayer){
         if(activePlayer.myInteractions.HoldingObj){
            if(activePlayer.myInteractions.HoldingObj is Interacao_Remoto){
                if(activePlayer.isBusy) return;
                Occupied = true;
                activePlayer.enjoy = 100;
                activePlayer.isBusy = true;
                activePlayer.busyTimer = UseTime*30;
                activePlayer.startTimer(activePlayer.busyTimer);
                Invoke("DeOccupie",UseTime);
            }else{
                print("Objeto errado!");
            }
        }else{
            print("Sem objeto!");
        }
    }

    void Start(){
        
    }

    void Update(){
        
    }
}
