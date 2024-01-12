using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Rigidbody2D rb;
    Transform target;
    public PlayerHealth playerHealth;

    public int damage;

    [Header("�߰� �ӵ�")]
    [SerializeField][Range(1f, 1000f)] public float moveSpeed = 3f;

    [Header("���� �Ÿ�")]
    [SerializeField][Range(0f,1000f)] float contactDistance = 1f;

    bool follow = false;
    bool A = false; 

    public void Start()
    {
        if(target == null && playerHealth == null){
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
            if(target == null && playerHealth == null){
                Debug.Log("component not found. (3)"); 
            }
        }
        rb = GetComponent<Rigidbody2D>();

        A = true; 
    }

    // Update is called once per frame
    void Update()
    {   
        if(A){
            FollowTarget();
        }
    }

    void FollowTarget()
    {
        if (Vector2.Distance(transform.position, target.position) <= contactDistance)
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        else
            rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(!follow)
            {
                Attack();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
    }

    void Attack()
    {
        playerHealth.PlayerHpNow -= damage; 
        Debug.Log(playerHealth.PlayerHpNow); 
    }

    private IEnumerator WaitForSecond(float A)
    {
        yield return null; 
    }
}