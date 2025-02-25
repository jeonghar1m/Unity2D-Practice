﻿using UnityEngine;

// 게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour {
    private int speed = 0; // 이동 속도

    private void Update() {
        // 게임 오브젝트를 오른쪽으로 일정 속도로 평행 이동하는 처리
        if (gameObject.name != "FlyingLava(Clone)")
            speed = (GameManager.currentLevel + 1) * 5; //1레벨은 10, 2레벨은 15
        else
            speed = 25;

        if(!GameManager.instance.isGameover)
            transform.Translate(Vector3.right * speed * Time.deltaTime);        //초당 speed의 속도로 왼쪽으로 평행 이동
    }
}