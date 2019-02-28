using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Base : MonoBehaviour{

    public int UseTime;

    public bool Occupied = false;

    public bool Grabbable;

    public float toReduceEnjoy;

    public Material HighLightMat;

    public Material DefaultMat;

    public SpriteRenderer Sprite;
    
    public virtual void Execute(Player activePlayer){}

    public void DeOccupie(){
        Occupied = false;
    }
    
    protected void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Interagir>().Target = this;
            Sprite.material = HighLightMat;
        }
    }

    protected void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            Sprite.material = DefaultMat;
            Interagir PlayerInt = other.gameObject.GetComponent<Interagir>();
            if(PlayerInt.Target == this){
                PlayerInt.Target = null;
            }
        }
    }

    void Start(){
        
    }

    void Update(){
        
    }


}
