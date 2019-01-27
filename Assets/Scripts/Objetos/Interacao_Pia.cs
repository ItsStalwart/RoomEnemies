using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Pia : Interacao_Base{

    public Vector2[] SlotPos = new Vector2[4];

    public override void Execute(Player activePlayer){
         if(activePlayer.myInteractions.HoldingObj){
            if(activePlayer.myInteractions.HoldingObj is Interacao_Prato){
                Interacao_Prato Prato = (Interacao_Prato) activePlayer.myInteractions.HoldingObj;
                if(!Prato.Clean){
                    if(activePlayer.isBusy) return;
                    Occupied = true;
                    Prato.Clean = true;
                    activePlayer.enjoy = Mathf.Clamp(activePlayer.enjoy - toReduceEnjoy,0,activePlayer.enjoy);
                    activePlayer.isBusy = true;
                    activePlayer.busyTimer = UseTime*30;
                    activePlayer.startTimer(activePlayer.busyTimer);
                    Invoke("DeOccupie",UseTime);
                }else{
                    print("Prato limpo!");
                }
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
