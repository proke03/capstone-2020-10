using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SunLightController : PausableMonoBehaviour {
    private Light sunLight;

    private float yAngle = 0;

    private void Awake() {
        sunLight = GetComponent<Light>();
    }

    protected override void PausableUpdate() {
        float sec = TimeManager.Instance.DayToSecond;

        //yAngle = SineFunc(sec / TimeManager.DaySecond) * 180 - 90;
        yAngle = Mathf.Lerp(90, -90, sec / TimeManager.DaySecond);

        sunLight.transform.localRotation = Quaternion.Euler(0, yAngle, 0);
    }

    //https://github.com/acron0/Easings/blob/master/Easings.cs
    //const float HALFPI = Mathf.PI / 2.0f;

    //private float SineFunc(float p) {
    //    if (p < 0.5f) {
    //        return 4 * p * p * p;
    //    } else {
    //        float f = ((2 * p) - 2);
    //        return 0.5f * f * f * f + 1;
    //    }
    //}
}