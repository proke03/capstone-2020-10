using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TimeManager : PausableMonoBehaviour {

    public static TimeManager Instance;

    // 최소 단위 = 초
    // ulong으로 522억년까지 표현 가능 ㅋㅋ
    public float time = 0;

    // 현실 시간 1초 당 게임 시간(초 단위)
    public float timeUnit = 10;

    // 시간 배율
    public float timeScale = 1.0f;

    // 시작 연도
    public int startYear = 0;
    public int startMonth = 1;
    public int startDay = 1;

    // 하루의 시작 시간
    public int initHour = 1;
    public int initMinute = 1;

    // 알람 추가 대기 큐
    private Queue<Alarm> alarmWaitQueue = new Queue<Alarm>();

    private List<Alarm> alarmList = new List<Alarm>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;

            Initialize();
        } else {
            Destroy(gameObject);
        }
    }

    private void Initialize() {
        time += startYear * YearSecond + (startMonth - 1) * MonthSecond + (startDay - 1) * DaySecond + initHour * HourSecond + initMinute * MinuteSecond;
        //StartCoroutine(TimeUpdate());
    }

    //float tick = 0;

    protected override void PausableUpdate() {
        //tick += Time.deltaTime;
        //if (tick >= 1.0f) {

        //    time += 10;

        //    tick = 0;
        //}
        time += Time.deltaTime * timeUnit * timeScale;

        // 임시 알람 코드(성능을 위해서 수정 할 필요가 있음)
        for (int i = 0; i < alarmList.Count; i++) {
            if (time >= alarmList[i].TargetTime) {  
                alarmList[i].notification?.Invoke();
                alarmList.RemoveAt(i);
                i--;
            }
        }
    }

    //private IEnumerator TimeUpdate() {
    //    while (true) {
    //        yield return new WaitForSeconds(timeInterval / timeScale);

    //        while (alarmWaitQueue.Count > 0) {
    //            var alarm = alarmWaitQueue.Dequeue();
    //            alarm.now = time;
    //            alarmList.Add(alarm);
    //        }

    //        time += timeUnit;

    //        for (int i = 0; i < alarmList.Count; i++) {
    //            if (time >= alarmList[i].TargetTime) {
    //                alarmList[i].notification?.Invoke();
    //                alarmList.RemoveAt(i);
    //                i--;
    //            }
    //        }
    //    }
    //}

    public void AddAlarm(Alarm alarm) {
        alarm.now = time;
        alarmList.Add(alarm);
        //alarmWaitQueue.Enqueue(alarm);
    }

    public uint Second => (uint)(time % 60);

    public uint Minute => (uint)((time / MinuteSecond) % 60);

    // 24 시간 방식 사용
    public uint Hour => (uint)((time / HourSecond) % 24);

    public uint Day => (uint)((time / DaySecond) % 28) + 1;

    // 하루를 초 단위로 바꾼 값
    public uint DayToSecond => (uint)(time % DaySecond);

    // 봄 여름 가을 겨울 4가지만 있음
    public uint Month => (uint)((time / MonthSecond) % 4) + 1;

    public uint Year => (uint)(time / YearSecond);

    // 이름 변경 필요
    public static uint YearSecond => 60 * 60 * 24 * 28 * 4;
    public static uint MonthSecond => 60 * 60 * 24 * 28;
    public static uint DaySecond => 60 * 60 * 24;
    public static uint HourSecond => 60 * 60;
    public static uint MinuteSecond => 60;

    private void OnDrawGizmos() {
#if UNITY_EDITOR
        if (GameManager.Instance)
            Handles.Label(GameManager.Instance.player.transform.position, Year + "년 " + Month + "월 " + Day + "일 " + Hour + "시 " + Minute + "분 " + Second + "초" + " | 테스트 : " + DayToSecond);
#endif
    }

    protected override void OnPaused() {
    }

    protected override void OnResumed() {
    }
}