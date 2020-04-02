using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm {
    // 주어진 시간 이후 Notification 함수 실행(게임 시간 분 단위)
    public uint time;

    // 이 시간 이후로 얼마나 지났는지 체크 함. 시간 기준점
    public uint now;

    // 주어진 시간이 다 됐을 경우 실행 될 함수.
    public void Notification() {

    }

    // 알람 울리는 시간 갱신
    public void Renewal(uint time) {

    }
}