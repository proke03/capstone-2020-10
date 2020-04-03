using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public static TimeManager Instance;

    // 최소 단위 = 분
    public ulong time = 0;

    // 한 틱당 지나는 게임 시간(분)
    public uint timeUnit = 10;

    // 시간 배율
    public float timeScale = 1.0f;

    // 실제 시간 흐르는 간격(초 단위)
    public static float timeInterval = 1.0f;

    // 시작 연도
    public const uint startYear = 2020;

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
        StartCoroutine(TimeUpdate());
    }

    //float tick = 0;

    //private void Update() {
    //    tick += Time.deltaTime;
    //    if (tick >= 1.0f) {

    //        time += 10;

    //        tick = 0;
    //    }
    //}

    private IEnumerator TimeUpdate() {
        while (true) {
            yield return new WaitForSeconds(timeInterval / timeScale);

            time += timeUnit;

            //while (alarmWaitQueue.Count > 0) alarmList.Add(alarmWaitQueue.Dequeue());

            //foreach (var alarm in alarmList) {
            //    if (alarm.time + time >= alarm.now) {
            //        alarm.Notification();
            //    }
            //    //alarm.
            //}
        }
    }

    public void AddAlarm(Alarm alarm) {
        alarmWaitQueue.Enqueue(alarm);
    }

    public uint Minute => (uint)(time % 60);

    // 24 시간 방식 사용
    public uint Hour => (uint)((time / 60) % 24);

    public uint Day => (uint)((time / (60 * 24)) % 28) + 1;

    // 봄 여름 가을 겨울 4가지만 있음
    public uint Month => (uint)((time / (60 * 24 * 28)) % 4) + 1;

    public uint Year => (uint)(time / (60 * 24 * 28 * 4)) + startYear;

    private void OnDrawGizmos() {
#if UNITY_EDITOR
        if (GameManager.Instance)
            Handles.Label(GameManager.Instance.player.transform.position, Year + "년 " + Month + "월 " + Day + "일 " + Hour + "시 " + Minute + "분");
#endif
    }
}