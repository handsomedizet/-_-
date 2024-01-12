using UnityEngine;

public class Entity : MonoBehaviour
{
    public float health = 10.0f;
    bool A = false;

    public Quest quest;
    public MobSponer mobSponer;

    public string item_Name; 
    public GameObject item_prefab;
    public void Death(string name, Vector2 pos)
    {
        Debug.Log("itme! ");
        item death = item_prefab.GetComponent<item>();
        death.SpawnItem(name, pos);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("weapon"))
        {
            A = true;
        }

        quest = GameObject.FindGameObjectWithTag("Player").GetComponent<Quest>();
        mobSponer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MobSponer>();
    }

    public void TakeDamage(float damage)
    {
        if (A)
        {
            health -= damage;

            Debug.Log("Health: " + health);

            if (health <= 0.0f)
            {
                Debug.Log("Object is dead!");
                quest.Achievements -= 1;
                Debug.Log(quest.Achievements);
                mobSponer.SlimeNum -= 1;
                Death(item_Name , this.gameObject.transform.position);
                Debug.Log("work(1)");
            }
        }
    }
}
