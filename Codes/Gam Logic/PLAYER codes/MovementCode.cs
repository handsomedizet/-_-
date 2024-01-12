using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementCode : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float knifeSpeed = 0.5f;

    public GameObject weapon;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        ChangWeapon(null);
    }

    void Update()
    {
        attackF();
        MoveF(); 
    }

    void CmdMove(float horizontalInput, float verticalInput)
    {
        // 서버에서만 실행되어야 하는 이동 명령
        // 이동 벡터 계산
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        // 서버에서만 이동 명령 실행
        RpcMove(movement);

        // 다른 서버에서도 실행되어야 하는 코드 추가 가능
    }

    void RpcMove(Vector3 movement)
    {
        // 모든 클라이언트에서 실행되어야 하는 이동 명령
        // 이동 벡터를 이용한 이동
        transform.Translate(movement);
    }

    void attackF()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.K))
        {
            WoodNifeScript weapon_script=weapon.GetComponent<WoodNifeScript>();
            weapon_script.AttakF();
        }
    }

    public void ChangWeapon(string WeaponName) {
        Transform parentTransform = transform;
        foreach (Transform child in parentTransform)
        {
            
            if(child.gameObject.tag.Equals("weapon")) {
                if(child.name.Equals(WeaponName)) {
                    child.gameObject.SetActive(true);
                    weapon=child.gameObject;
                    Debug.Log("무기 변경 완료");
                }
                else{
                    
                    child.gameObject.SetActive(false);
                }
                Debug.Log(child.name);
            }
        }
    }

    void MoveF()
    {
        // WASD 입력을 감지
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // 이동 명령을 서버로 전송
        //CmdMove(horizontalInput, verticalInput);

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // 나머지 코드는 클라이언트에서만 실행
        // A 키를 누르면 캐릭터를 반전
        if (Input.GetKeyDown(KeyCode.A))
        {
            FlipCharacter(true);
            MoveKnife(-knifeSpeed);
        }

        // D 키를 누르면 캐릭터를 다시 원래대로 돌림
        if (Input.GetKeyDown(KeyCode.D))
        {
            FlipCharacter(false);
            MoveKnife(knifeSpeed);
        }        
    }

    void CmdFlipCharacter(bool facingLeft)
    {
        // 서버에서만 실행되어야 하는 반전 명령
        RpcFlipCharacter(facingLeft);
    }

    void RpcFlipCharacter(bool facingLeft)
    {
        // 모든 클라이언트에서 실행되어야 하는 반전 명령
        // SpriteRenderer의 Flip X 속성을 사용하여 스프라이트 반전
        spriteRenderer.flipX = facingLeft;
    }

    void CmdMoveKnife(float offset)
    {
        // 서버에서만 실행되어야 하는 칼 이동 명령
        RpcMoveKnife(offset);
    }

    void RpcMoveKnife(float offset)
    {
        // 모든 클라이언트에서 실행되어야 하는 칼 이동 명령
        // 칼의 현재 위치를 가져와서 좌표 이동
        Vector3 knifePosition = transform.GetChild(0).position;
        knifePosition.x = transform.position.x + offset;
        transform.GetChild(0).position = knifePosition;
    }

    void FlipCharacter(bool facingLeft)
    {
        // 클라이언트에서만 실행되어야 하는 반전 명령
        CmdFlipCharacter(facingLeft);
    }

    void MoveKnife(float offset)
    {
        // 클라이언트에서만 실행되어야 하는 칼 이동 명령
        CmdMoveKnife(offset);
    }
}
