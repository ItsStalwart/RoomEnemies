using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Vassoura : Interacao_Base{

    public GameObject sacoLixoPrefab;

    public void DropLixo(){
        Instantiate(sacoLixoPrefab,transform.position,Quaternion.identity);
    }

    public override void Execute(Player activePlayer){
        if(activePlayer.currentRoom.Dirtyness > 80){
            if(activePlayer.isBusy) return;
            Occupied = true;
            activePlayer.currentRoom.Dirtyness = 0;
            activePlayer.isBusy = true;
            activePlayer.busyTimer = UseTime*30;
            activePlayer.startTimer(activePlayer.busyTimer);
            Invoke("DeOccupie",activePlayer.busyTimer);
            Invoke("DropLixo",0);
        }
    }

    void Start(){
        
    }

    void Update(){
        
    }
}
