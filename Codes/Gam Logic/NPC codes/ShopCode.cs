using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class ShopCode : MonoBehaviour
{
    //public List
    public CoinCode coincode; 

    private Player_Item item;
    public List<GameObject> objectList = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        item=this.GetComponent<Player_Item>();
        StartCoroutine(NPCinventory());
    }

    IEnumerator NPCinventory()
    {
        yield return new WaitForSeconds(0.25f);
        foreach(GameObject item_value in objectList){
            Debug.Log(item_value);
            item.addInventory(item_value.name,5);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    private bool isInShop = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Welcome to the shop!");
            if (collision.gameObject.CompareTag("Player"))
            {
                item.closeInventory();
                item.openInventory(objectList.Count%5,(objectList.Count/5)+1,new Vector3(0,0,0),item.Items);
                //StartCoroutine(WaitForPurchase());
            }
        }
    }

    private IEnumerator WaitForPurchase()
    {
        isInShop = true;

        while (isInShop)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                if(coincode.coin >= 5)
                {
                    Debug.Log("You bought APPLE");
                    coincode.CoinGiver(5);
                    SpawnItem2("Apple" , this.gameObject.transform.position , 0);
                    isInShop = false;
                }
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                if(coincode.coin >= 5)
                {
                    Debug.Log("You bought POTION");
                    coincode.CoinGiver(5);
                    SpawnItem2("Potion" , this.gameObject.transform.position , 1);
                    isInShop = false;
                }
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                if(coincode.coin >= 5)
                {
                    Debug.Log("You bought ARMOR");
                    coincode.CoinGiver(5);
                    SpawnItem2("Armor" , this.gameObject.transform.position , 2);
                    isInShop = false;
                }
            }

            // 대기 시간 조절 (optional)
            yield return null;
        }
    }

    public void SpawnItem2(string id,Vector2 pos , int N)
    {
        GameObject instance = Instantiate(objectList[N] , pos , Quaternion.identity);
        item tmp=instance.GetComponent<item>();
        tmp.name = id;
    }  


}
