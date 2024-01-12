using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmpCamera : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-7.35f);
    }
}
