using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAlarmObject : P3DObject {
    public Alarm alarm;

    private void Awake() {
        P3DInitialize();

        alarm = new Alarm();
        alarm.time = 120;
        TimeManager.Instance.AddAlarm(alarm);
    }
}