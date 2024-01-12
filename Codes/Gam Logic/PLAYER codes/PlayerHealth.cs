using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public static int PlayerHp = 100;
    public int PlayerHpNow;

    [SerializeField] private TextMeshProUGUI tx1;

    bool b = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHpNow = PlayerHp;

        // TextMeshProUGUI 필드에 대한 자동 할당
        if (tx1 == null)
        {
            GameObject hpTextObject = GameObject.Find("hpText"); // 여기에 찾아야 할 오브젝트의 이름을 넣어주세요
            if (hpTextObject != null)
            {
                tx1 = hpTextObject.GetComponent<TextMeshProUGUI>();
                if (tx1 == null)
                {
                    Debug.LogError("TextMeshProUGUI 컴포넌트를 찾을 수 없습니다.");
                }
            }
            else
            {
                Debug.LogError("이름이 'YourHPTextObjectName'인 오브젝트를 찾을 수 없습니다.");
            }
        }

        b = true;
    }

    // Update is called once per frame
    void Update()
    {
        tx1.text = $"HP : {PlayerHpNow}";
    }
}
