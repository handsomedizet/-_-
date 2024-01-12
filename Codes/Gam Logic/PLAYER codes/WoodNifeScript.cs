using UnityEngine;
public class WoodNifeScript : MonoBehaviour
{
    private Animator animator;

    private Entity damageReceiver; // Ŭ���� ������ ����

    private BoxCollider2D colider;

    public int MaxAttackEnemy;
    public int goodHitNumber = 0; 
    public float DamageNow; 
    public float Damage; 

    // public override void OnStartClient()
    // {
    //     colider=GetComponent<BoxCollider2D>();

    //     animator = GetComponent<Animator>();

    //     if (animator == null)
    //     {
    //         Debug.LogError("Animator component not found on the GameObject.");
    //     }

    //     if (damageReceiver == null)
    //     {
    //         Debug.LogError("DamageReceiver component not found on the OtherObject.");
    //     }
    // }

    private void Start() {
        colider=GetComponent<BoxCollider2D>();

        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }

        if (damageReceiver == null)
        {
            Debug.LogError("DamageReceiver component not found on the OtherObject.");
        }
    }

    public void attack(int MaxEnemy)
    {
        Debug.Log("attack!");
        int count=0;
        GameObject otherObject;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(this.transform.position, new Vector2(colider.size.x,colider.size.y),0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("EM"))
            {
                Debug.Log("work");   
                otherObject = collider.gameObject;
                damageReceiver = otherObject.GetComponent<Entity>();
                damageReceiver.TakeDamage(Damage);
                count++;
                if(count > MaxEnemy)
                {
                    break;
                }

                if(goodHitNumber == 2)
                {
                    GoodHit(DamageNow += Damage / 2);
                    DamageNow = Damage; 
                    Debug.Log("Critical Hit!");
                    goodHitNumber = 0;  
                    break; 
                }
                else
                {
                    goodHitNumber++;
                    break;  
                }
            }
        }
    }

    // void Update()
    // {
    //     if(isLocalPlayer){
    //         AttakF();
    //     }
    // }

    public void AttakF()
    {
        animator.SetTrigger("WoodNifeTrigger");

        attack(MaxAttackEnemy);

        //Invoke("WoodNife", 1f);
        
        animator.SetBool("ABool", true);

    }

    public void GoodHit(float damage)
    {
        damageReceiver.TakeDamage(damage); 
    }
}
