using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    private List<quest> quests=new List<quest> {};
    List<object> quests_name = new List<object> {};

    public int Achievements; 

    public CoinCode coincode; 

    class quest
    {
        public string title;
        public string type;
        public string description;
        public string target;
        public int Achievement; 
        public int rewardType; // 1 = 코인 , 2 = 아이템 , 3 = 스텟 ..
        public int rewardNum; 
    }

    public int State = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(State == 1 && Achievements <= 0)
        {
            State = 2;
            Debug.Log($"State : {State}.");  
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
            if(Input.GetKey(KeyCode.E))
            {
                if(State != 2)
                {
                    if (collision.gameObject.CompareTag("NPC"))
                    {
                        NPC_Quest npc_quest = collision.gameObject.GetComponent<NPC_Quest>();
                        bool isDuplicate = quests_name.Contains(npc_quest.title);
                        if (!isDuplicate)
                        {        
                            quest addQuest=new quest();
                            addQuest.title = npc_quest.title;
                            addQuest.type = npc_quest.type;
                            addQuest.description = npc_quest.description;
                            addQuest.target = npc_quest.target;
                            addQuest.Achievement = npc_quest.Achievement; 
                            Achievements = addQuest.Achievement; 
                            addQuest.rewardType = npc_quest.rewardType; 
                            addQuest.rewardNum = npc_quest.rewardNum; 

                            Debug.Log($"quest title : {addQuest.title}");
                            Debug.Log($"quset type : {addQuest.type}");

                            quests.Add(addQuest);
                            quests_name.Add(npc_quest.title);

                            State = 1; 
                        }
                        else
                        {
                            //Debug.Log("퀘스트를 찾지못했습니다. ");
                        }     
                    }
                }
                else if(State == 2)
                {
                    NPC_Quest npc_quest2 = collision.gameObject.GetComponent<NPC_Quest>();
                    if (collision.gameObject.CompareTag("NPC"))
                    {
                        if(npc_quest2.rewardType == 1)
                        {
                            coincode.CoinReseiver(npc_quest2.rewardNum);
                            State = 0; 
                        }
                    }
                }
            }
        }
}
