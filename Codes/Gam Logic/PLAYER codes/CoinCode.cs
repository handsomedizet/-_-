using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCode : MonoBehaviour
{
    public int coin = 0;

    [SerializeField] private TextMeshProUGUI tx2;

    // OnStartClient 대신 Start 메서드를 사용하여 초기화
    private void Start()
    {
            if (tx2 == null)
            {
                GameObject coinTextObject = GameObject.Find("coinText");
                if (coinTextObject != null)
                {
                    tx2 = coinTextObject.GetComponent<TextMeshProUGUI>();
                    if (tx2 == null)
                    {
                        Debug.LogError("TextMeshProUGUI 컴포넌트를 찾을 수 없습니다. (2)");
                    }
                }
                else
                {
                    Debug.LogError("coinText라는 이름을 가진 오브젝트를 찾을 수 없습니다.");
                }
            }

            // 초기화 시 동기화된 값으로 텍스트 설정
            tx2.text = $"coin : {coin}";
    }


    public void CoinGiver(int give)
    {
        coin -= give;
        //tx2.text = $"coin : {coin}";
    }

    public void CoinReseiver(int give)
    {
        coin += give;
        tx2.text = $"coin : {coin}";
    }
}
