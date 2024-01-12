using UnityEngine;
using UnityEditor;
using Mirror; 

[ExecuteInEditMode]
public class ForceNetworkIdentity : MonoBehaviour
{
    void OnEnable()
    {
        // 에디터에서 스크립트가 실행될 때마다 프리팹 루트에 NetworkIdentity를 강제로 추가
        ForceNetworkIdentityInPrefab();
    }

    void ForceNetworkIdentityInPrefab()
    {
        GameObject prefab = PrefabUtility.FindPrefabRoot(gameObject);
        if (prefab != null)
        {
            NetworkIdentity existingIdentity = prefab.GetComponent<NetworkIdentity>();
            if (existingIdentity == null)
            {
                prefab.AddComponent<NetworkIdentity>();
            }
            else
            {
                // 이미 NetworkIdentity가 있을 경우, 이전의 NetworkIdentity 컴포넌트를 제거
                DestroyImmediate(existingIdentity);
                prefab.AddComponent<NetworkIdentity>();
            }
        }
    }

    void Update()
    {
        // 에디터 모드에서는 계속해서 감지
        ForceNetworkIdentityInPrefab();
    }
}
