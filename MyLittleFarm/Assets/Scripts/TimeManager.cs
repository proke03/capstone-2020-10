using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 현실 시간으로 1초가 게임 시간으로 10분
/// </summary>
public class TimeManager : MonoBehaviour {
    public class DateAndTime {
        float tick;

        public int minute;
        public int hour;

        public int day = 1;
        public int quarter = 1;
        public int year = 1;

        public void Calculate(float dt) {
            tick += dt;
            if (tick >= 1) {    
                NextTick();
                tick = 0;
            }
        }

        void NextTick() {
            minute += 10;
            if (minute >= 60) {
                minute = 0;

                hour += 1;
                if (hour >= 24) {
                    hour = 0;

                    day += 1;
                    if (day > 30) {
                        day = 1;

                        quarter += 1;
                        if (quarter > 4) {
                            quarter = 1;

                            year += 1;
                        }
                    }
                }
            }
        }

        public override string ToString() {
            return string.Format("{0} {1} {2} {3:D2}:{4:D2}", year, quarter, day, hour, minute);
        }
    }

    public static TimeManager Instance;

    public TMPro.TMP_Text timeText;

    DateAndTime dateTime = new DateAndTime();

    /// <summary>
    /// 시간 흐르는 속도 배율
    /// </summary>
    public float timeScale = 1.0f;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
    }

    private void Update() {
        dateTime.Calculate(Time.deltaTime * timeScale);

        timeText.text = dateTime.ToString() + "";

    }
}