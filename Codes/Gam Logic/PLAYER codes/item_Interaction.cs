using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class item_Interaction : MonoBehaviour, IPointerClickHandler
{
    public GameObject owner;

    public GameObject player;

    private Player_Item player_items;
    private CoinCode coinCode;

    void Start()
    {
        player_items = owner.GetComponent<Player_Item>();
        coinCode = player.GetComponent<CoinCode>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(transform.name.Equals("ui_use_item_button")){
            if(player_items.LastClickItemName.Equals("slime_jumack")){
                Debug.Log("슬라임의 점액을 먹었습니다!청포도 맛이군요!");
            }
            else if(player_items.LastClickItemName.Equals("apple")){
                Debug.Log("사과를 먹었습니다!슬라임 맛이군요!");
            }
            else if(player_items.LastClickItemName.Equals("potion_health")){
                Debug.Log("체력회복물약을 마셨습니다!토마토 맛이군요!");
            }
            else if(player_items.LastClickItemName.Equals("Spritme_item_5")){
                Debug.Log("갑옷을 먹었습니다!첵스초코 맛이군요!");
            }
            else if(player_items.LastClickItemName.Equals("WoodNife1")){
                player.GetComponent<MovementCode>().ChangWeapon("WoodNife1");
                player_items.Items[player_items.LastClickItemName].count+=1;
            }
            player_items.Items[player_items.LastClickItemName].count-=1;
            if(player_items.Items[player_items.LastClickItemName].count!=0){
                player_items.useItem(player_items.LastClickItemName);
            }
            else{
                player_items.closeInventory();
                player_items.openInventory(10, 5, new Vector3(-750, 375, 0), player_items.Items);
            }
        }
        else if (transform.name.Equals("slime_jumack"))
        {
            player_items.useItem("slime_jumack");
            player_items.LastClickItemName="slime_jumack";
        }
        else if (transform.name.Equals("apple"))
        {
            if(owner.tag=="NPC"){
                Debug.Log("You bought APPLE");
                Debug.Log(name);
                player.GetComponent<Player_Item>().addInventory(name,1);
                coinCode.CoinGiver(5);

                player_items.Items[transform.name].count -= 1;
                player_items.closeInventory();
                player_items.openInventory(owner.GetComponent<ShopCode>().objectList.Count%5,(owner.GetComponent<ShopCode>().objectList.Count/5)+1, new Vector3(0, 0, 0), player_items.Items);
            }
            else{
                player_items.useItem("apple");
                player_items.LastClickItemName="apple";
                // player_items.closeInventory();
                // player_items.openInventory(10, 5, new Vector3(-750, 375, 0), player_items.Items);
            }
        }
        else if (transform.name.Equals("potion_health"))
        {
            if(owner.tag=="NPC"){
                Debug.Log("You bought POTION_HEALTH");
                Debug.Log(name);
                player.GetComponent<Player_Item>().addInventory(name,1);
                coinCode.CoinGiver(5);

                player_items.Items[transform.name].count -= 1;
                player_items.closeInventory();
                player_items.openInventory(owner.GetComponent<ShopCode>().objectList.Count%5,(owner.GetComponent<ShopCode>().objectList.Count/5)+1, new Vector3(0, 0, 0), player_items.Items);
            }
            else{
                player_items.useItem("potion_health");
                player_items.LastClickItemName="potion_health";
            }
        }
        else if (transform.name.Equals("Spritme_item_5"))
        {
            if(owner.tag=="NPC"){
                Debug.Log("You bought ARMOR");
                Debug.Log(name);
                player.GetComponent<Player_Item>().addInventory(name,1);
                coinCode.CoinGiver(5);

                player_items.Items[transform.name].count -= 1;
                player_items.closeInventory();
                player_items.openInventory(owner.GetComponent<ShopCode>().objectList.Count%5,(owner.GetComponent<ShopCode>().objectList.Count/5)+1, new Vector3(0, 0, 0), player_items.Items);
            }
            else{
                player_items.useItem("Spritme_item_5");
                player_items.LastClickItemName="Spritme_item_5";
            }
        }
        else if (transform.name.Equals("WoodNife1"))
        {
            player_items.useItem("WoodNife1");
            player_items.LastClickItemName="WoodNife1";
        }
    }
}
