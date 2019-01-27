using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Lixo_Balde : Interacao_Base{
 
    public override void Execute(Player activePlayer){
        if(activePlayer.myInteractions.HoldingObj){
            if(activePlayer.myInteractions.HoldingObj is Interacao_Lixo){
                Interacao_Lixo LixoSaco = (Interacao_Lixo) activePlayer.myInteractions.HoldingObj;
                if(activePlayer.isBusy) return;
                Occupied = true;
                Destroy(LixoSaco.gameObject);
                activePlayer.enjoy = Mathf.Clamp(activePlayer.enjoy - toReduceEnjoy,0,activePlayer.enjoy);
                activePlayer.isBusy = true;
                activePlayer.busyTimer = UseTime*30;
                activePlayer.startTimer(activePlayer.busyTimer);
                Invoke("DeOccupie",UseTime);
            }else{
                print("Objeto errado!");
            }
        }else{
            print("Sem objetos!");
        }
    }

    void Start(){
        
    }

    void Update(){
        
    }
}
