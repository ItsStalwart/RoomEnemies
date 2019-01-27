using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Mesa : Interacao_Base{

    public override void Execute(Player activePlayer){
        if(activePlayer.myInteractions.HoldingObj){
            if(activePlayer.myInteractions.HoldingObj is Interacao_Prato){
                Interacao_Prato Prato = (Interacao_Prato) activePlayer.myInteractions.HoldingObj;
                if(Prato.Clean && Prato.HasFood && !Occupied){
                    if(activePlayer.isBusy) return;
                    Occupied = true;
                    Prato.Clean = false;
                    Prato.HasFood = false;
                    activePlayer.hunger = 100;
                    activePlayer.isBusy = true;
                    activePlayer.busyTimer = UseTime*30;
                    activePlayer.startTimer(activePlayer.busyTimer);
                    Invoke("DeOccupie",UseTime);
                }else{
                    print("Prato s/ comida");
                }
            }else{
                print("Objeto errado");
            }
        }else{
            print("Sem Objeto");
        }
    }

    void Start(){
        
    }

    void Update(){
        
    }
}
