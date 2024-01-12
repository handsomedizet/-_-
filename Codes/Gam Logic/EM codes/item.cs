using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public string name1;
    
    public void SpawnItem(string id,Vector2 pos)
    {
        GameObject instance = Instantiate(gameObject,pos, Quaternion.identity);
        item tmp=instance.GetComponent<item>();
        tmp.name1 = id;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_Item player_Item = collision.gameObject.GetComponent<Player_Item>();
            player_Item.addInventory(name1,1);
            Debug.Log(name1);
            Destroy(this.gameObject);
        }
    }

}
