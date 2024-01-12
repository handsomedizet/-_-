using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(this.transform.position, new Vector2(3f,3f),0f);
        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject.transform.name.Equals("slime(Clone)")) {
                EnemyControl CommonEnemy = collider.gameObject.GetComponent<EnemyControl>();
                CommonEnemy.damage=5;
                CommonEnemy.moveSpeed=5.0f;
            }
        }
    }
}
