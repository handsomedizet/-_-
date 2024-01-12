using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Player_Item : MonoBehaviour
{
    private UImanager uImanager;


    public Texture2D ItemTextures;
    public Sprite[] inventory_texture;

    public Dictionary<string, Item> Items = new Dictionary<string, Item>();

    public string LastClickItemName;

    private int Inven;

    private void Start()
    {
        uImanager = GetComponent<UImanager>();

        Sprite[] item = Resources.LoadAll<Sprite>(ItemTextures.name);
        foreach (Sprite a in item)
        {  
            Items.Add(a.name, new Item { name = a.name , sprite = a , count = 0 });
        }
        Sprite[] Testitem = Resources.LoadAll<Sprite>("ItemTestFolder");
        foreach (Sprite a in Testitem)
        {  
            Items.Add(a.name, new Item { name = a.name , sprite = a , count = 0 });
        }
        addInventory("WoodNife1",1);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            closeInventory();
        }
        if (Input.GetKeyDown(KeyCode.Tab) && gameObject.tag.Equals("Player"))
        {
            if (Inven % 2 == 0)
            {
                Debug.Log("Open Inventory");
                openInventory(10, 5, new Vector3(-750, 375, 0), Items);
            }
            else
            {
                Debug.Log("Close Inventory");
                GameObject[] uiObjects = GameObject.FindGameObjectsWithTag("Inventory");

                foreach (GameObject uiObject in uiObjects)
                {
                    Destroy(uiObject);
                }
            }
            Inven++;
        }
    }
    public class Item
    {
        public string name;
        public int count=0;
        public Sprite sprite;
    }

    public void addInventory(string name,int count)
    {
        Items[name].count+=count;
    }

    public void useItem(string name){
        closeInventory();
        openInventory(8, 7, new Vector3(-1000, 450, 0),Items);
        StartCoroutine(useItemUi(name));
    }

    IEnumerator useItemUi(string name){
        yield return new WaitForEndOfFrame();
        uImanager.SpawnImage(new Vector3(650,0,0),Quaternion.identity,new Vector2(520f,880f),inventory_texture[6],gameObject);
        
        inventory_texture[5]=Items[name].sprite;
        
        uImanager.SpawnImage(new Vector3(650,312,0),Quaternion.identity,new Vector2(175f,200f),inventory_texture[5],gameObject);
        if(name.Equals("apple")){
            uImanager.SpawnText(new Vector3(660,-350),Quaternion.identity,15,"평범한 사과입니다.어디서든 구할수 있으므로 만약 이 아이템을 상점에서 파는걸 목격했다면 당장 도망치고 공정거래위원회에 전화하세요.",270,500,1);
        }
        else if(name.Equals("slime_jumack")){
            uImanager.SpawnText(new Vector3(660,-350),Quaternion.identity,15,"슬라임의 점액입니다.강한 부식성을 띄지만 일부 매니아 층은 오히려 이런 부식성을 즐기기 위해 먹는다는 소문이 있습니다.",270,500,1);
        }
        else if(name.Equals("potion_health")){
            uImanager.SpawnText(new Vector3(660,-350),Quaternion.identity,15,"가장 일반적으로 구할수 있는 회복용 물약입니다.여러 맛이 있으며 그중 딸기맛이 가장 인기가 좋고,토마토 맛이 가장 가격이 싸다고 합니다.",270,500,1);
        }
        else if(name.Equals("Spritme_item_5")){
            uImanager.SpawnText(new Vector3(660,-350),Quaternion.identity,15,"평범한 갑옷으로,보통 달여먹거나,믹서기에 갈아서 스무디로 만들어 먹거나,국밥에 넣어 먹습니다.",270,500,1);
        }
        else if(name.Equals("WoodNife1")){
            uImanager.SpawnText(new Vector3(660,-350),Quaternion.identity,15,"평범한 나뭇가지로 만든 초보적인 수준의 나무검입니다.공격력은 허접해 보일수도 있지만, 사실 이 검은 무려 가장 공격력이 허접합니다.",270,500,1);
        }
        uImanager.SpawnImage(new Vector3(650,-350,0),Quaternion.identity,new Vector2(480f,135f),inventory_texture[7],gameObject);
    }

    public void closeInventory()
    {
        GameObject[] uiObjects = GameObject.FindGameObjectsWithTag("Inventory");

        foreach (GameObject uiObject in uiObjects)
        {
            Destroy(uiObject);
        }
    }

    public void openInventory(int width,int height,Vector3 pos,Dictionary<string,Item> Item)
    {
        Vector3 tmp = pos;
        Quaternion angle = Quaternion.Euler(0, 0, 0);

        float sizex = 150;
        float sizey = 150;
        int cnt = 0;
        List<Item> ItemValue = Item.Values.ToList();
        for (float i = 0; i < height; i++)
        {
            for(float j= 0; j < width; j++)
            {
                pos = new Vector3(pos.x + (150f), pos.y, pos.z);
                if (i == 0 && width==1)
                {
                    angle = Quaternion.Euler(0, 0, 270);
                    uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[3],gameObject);
                }
                else if (i == height-1 && width == 1)
                {
                    angle = Quaternion.Euler(0, 0, 90);
                    uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[3],gameObject);
                }
                else if (width == 1)
                {
                    angle = Quaternion.Euler(0, 0, 90);
                    uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[4],gameObject);
                }
                else if (j == 0 && height == 1)
                {
                    angle = Quaternion.Euler(0, 0, 0);
                    uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[3], gameObject);
                }
                else if (j == width-1 && height == 1)
                {
                    angle = Quaternion.Euler(0, 0, 180);
                    uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[3], gameObject);
                }
                else if (height== 1)
                {
                    angle = Quaternion.Euler(0, 0, 0);
                    uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[4], gameObject);
                }
                else if (i == 0 && j==0)
                {
                    angle = Quaternion.Euler(0, 0, 0);
                    uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[0], gameObject);
                }
                else if (i == 0 && j == width - 1)
                {
                    angle = Quaternion.Euler(0, 0, 270);
                    uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[0], gameObject);
                }
                else if (i == height-1 && j == 0)
                {
                    angle = Quaternion.Euler(0, 0, 90);
                    uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[0], gameObject);
                }
                else if (i == height-1 && j == width-1)
                {
                    angle = Quaternion.Euler(0, 0, 180);
                    uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[0], gameObject);
                }
                else
                {
                    if (j == 0)
                    {
                        angle = Quaternion.Euler(0, 0, 90);
                        uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[1], gameObject);
                    }
                    else if (j == width-1)
                    {
                        angle = Quaternion.Euler(0, 0, 270);
                        uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[1], gameObject);
                    }
                    else if (i == 0)
                    {
                        angle = Quaternion.Euler(0, 0, 0);
                        uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[1], gameObject);
                    }
                    else if (i == height-1)
                    {
                        angle = Quaternion.Euler(0, 0, 180);
                        uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[1], gameObject);
                    }
                    else
                    {
                        uImanager.SpawnImage(pos, angle, new Vector2(sizex, sizey), inventory_texture[2], gameObject);
                    }
                }
                if (cnt < ItemValue.Count)
                {
                    for(int k=cnt;k<Item.Count;k++)
                    {
                        cnt++;
                        if (ItemValue[k].count > 0)
                        {
                            inventory_texture[5]=ItemValue[k].sprite;
                            inventory_texture[5].name = ItemValue[k].name;
                            uImanager.SpawnImage(pos, angle, new Vector2(sizex - 35, sizey - 35), inventory_texture[5], gameObject);
                            uImanager.SpawnText(new Vector3(pos.x-40,pos.y-112,0), Quaternion.identity, 25, ItemValue[k].count.ToString(),100,100,0);
                            break;
                        }
                    }
                }
            }
            pos = new Vector3(tmp.x, pos.y-150f, pos.z);
        }
        pos = tmp;
    }
}
