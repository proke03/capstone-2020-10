using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausableYieldInstruction : CustomYieldInstruction {
    public override bool keepWaiting {
        get {
            return GameManager.Instance.IsPaused;
        }
    }
}