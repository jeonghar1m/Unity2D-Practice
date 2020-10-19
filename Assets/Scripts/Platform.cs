﻿using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour {
    public GameObject[] obstacles; // 장애물 오브젝트들
    private bool stepped = false; // 플레이어 캐릭터가 밟았었는가
    private Vector2 trapTarget;  //가시 이동 목표 지점
    private bool[] isTrap = new bool[3] { false, false, false };

    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    private void OnEnable()
    {
        // 발판을 리셋하는 처리
        //밟힘 상태를 리셋
        stepped = false;

        //장애물 수 만큼 루프
        for (int i = 0; i < obstacles.Length; i++)
        {
            //현재 순번의 장애물을 1/3 확률로 활성화
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
                isTrap[i] = true;
            }
            else
                obstacles[i].SetActive(false);
        }
    }
    private void Update()
    {
        trapTarget = new Vector2(transform.position.x, 1.8f);

        for(int i=0;i<obstacles.Length;i++)
        {
            if(isTrap[i])
                obstacles[i].transform.position = Vector2.MoveTowards(transform.position, trapTarget, 0.1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // 플레이어 캐릭터가 자신을 밟았을때 점수를 추가하는 처리
        if(collision.collider.tag=="Player"&&!stepped)
        {
            //점수를 추가하고 밟힘 상태를 참으로 변경
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}