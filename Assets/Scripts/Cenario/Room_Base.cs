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
        }else if(other.gameObject.tag == "SacoLixo"){
            Dirtyness += 15;
            if(Dirtyness > DirtynessMax){
                Dirtyness = 0;
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            Player Player = other.gameObject.GetComponent<Player>();
            if(Player.currentRoom == this){
                Player.currentRoom = null;
            }
        }else if(other.gameObject.tag == "SacoLixo"){
            Dirtyness -= 15;
            if(Dirtyness < 0){
                Dirtyness = 0;
            }
        }
    }

    void Start(){
        
    }

    void Update(){
        
    }
}
