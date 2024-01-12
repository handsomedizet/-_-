using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class AiMovementCode : MonoBehaviour
{
    public SpriteRenderer otherObjectSpriteRenderer;

    SpriteRenderer rend;
    float timer;
    int waitingTime;
    int currentState; 


    // Start is called before the first frame update
    void Start()
    {
        otherObjectSpriteRenderer = GetComponent<SpriteRenderer>();
        timer = 0.0f;
        waitingTime = 1;
        WoodNifeScript woodNifeScriptInstance = FindObjectOfType<WoodNifeScript>();
    }

    int speed = 3;
    int life = 2;  
    void Update()
    {
        timer += Time.deltaTime;
        int a = Random.Range(1, 4);
        //float playerMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (timer > waitingTime && a == 1)
        {
            transform.Translate(-0.25f, 0, 0);
            timer = 0;
        }
        if (timer > waitingTime && a == 2)
        {
            transform.Translate(0.25f, 0, 0);
            timer = 0;

        }
        if (timer > waitingTime && a == 3)
        {
            transform.Translate(0, -0.25f, 0);
            timer = 0;
        }
        if (timer > waitingTime && a == 4)
        {
            transform.Translate(0, 0.25f, 0);
            timer = 0;
        }

        //this.transform.Translate(new Vector3(playerMove, 0, 0));
    }
}
