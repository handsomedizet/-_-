using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectinteraction : MonoBehaviour
{
    public String ObjectInteractionType;

    public GameObject SpawnObject;
    private void OnTriggerStay2D(Collider2D other){
        if(Input.GetKeyDown(KeyCode.E)){
            if(other.transform.tag.Equals("Player")){
                if(ObjectInteractionType.Equals("SpawnItem")){
                    Debug.Log("Spawn apple");
                    item death = SpawnObject.GetComponent<item>();
                    death.SpawnItem(death.name1, gameObject.transform.position);
                }
            }
        }   
    }
}
