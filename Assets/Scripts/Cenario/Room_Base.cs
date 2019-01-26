using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Base : MonoBehaviour{

    public float DirtynessMax = 100;
    public float Dirtyness = 0;

    public float dirtRate;

    public void getDirty(){
        Dirtyness += dirtRate * Time.deltaTime;
        if(Dirtyness > DirtynessMax){
            Dirtyness = DirtynessMax;
        }
    }

    protected void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Player>().currentRoom = this;
        }
    }

    protected void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            Player Player = other.gameObject.GetComponent<Player>();
            Player.currentRoom = null;
        }
    }

    void Start(){
        
    }

    void Update(){
        
    }
}
