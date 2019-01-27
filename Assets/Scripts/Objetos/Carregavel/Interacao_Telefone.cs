using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Telefone : Interacao_Base{

    public float BatteryMax;
    public float Battery;

    public bool onBase;
    public bool Held;

    public float dischargeRate;

    public float chargeRate;

    public void Discharge(){
        Battery -= dischargeRate * Time.deltaTime;
        if(Battery < 0){
            Battery = 0;
        }
    }

    public void Charge(){
        Battery += chargeRate * Time.deltaTime;
        if(Battery > BatteryMax){
            Battery = BatteryMax;
        }
    }

    public override void Execute(Player activePlayer){
        if(Battery > 0 && activePlayer.currentRoom.Dirtyness < 80){
            if(activePlayer.isBusy) return;
            Occupied = true;
            activePlayer.social = 100;
            activePlayer.isBusy = true;
            activePlayer.busyTimer = UseTime*30;
            activePlayer.startTimer(activePlayer.busyTimer);
            Invoke("DeOccupie",activePlayer.busyTimer);
        }
    }

    void Start(){
        
    }

    void Update(){
        if(onBase || Held){
            GetComponent<Rigidbody2D>().isKinematic = true;
        }else{
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    void FixedUpdate(){
        if(!onBase && Battery > 0){
            Discharge();
        }else if(onBase && Battery < BatteryMax){
            Charge();
        }
    }
}
