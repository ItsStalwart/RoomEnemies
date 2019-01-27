using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Cama : Interacao_Base{

    public override void Execute(Player activePlayer){
        if(!activePlayer.myInteractions.HoldingObj && activePlayer.currentRoom.Dirtyness < 80){
            if(activePlayer.isBusy) return;
            activePlayer.tired = 100;
            activePlayer.isBusy = true;
            activePlayer.busyTimer = UseTime*30;
            activePlayer.startTimer(activePlayer.busyTimer);
        }
    }

    void Start(){
        
    }

    void Update(){
        
    }
}
