using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Geladeira : Interacao_Base{

     public override void Execute(Player activePlayer){
        if(activePlayer.myInteractions.HoldingObj){
            if(activePlayer.myInteractions.HoldingObj is Interacao_Prato){
                Interacao_Prato Prato = (Interacao_Prato) activePlayer.myInteractions.HoldingObj;
                if(Prato.Clean && !Prato.HasFood){
                    if(activePlayer.isBusy) return;
                    Occupied = true;
                    Prato.HasFood = true;
                    activePlayer.isBusy = true;
                    activePlayer.busyTimer = UseTime*30;
                    activePlayer.startTimer(activePlayer.busyTimer);
                    Invoke("DeOccupie",UseTime);
                }else{
                    print("Prato sujo ou com comida!");
                }
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
