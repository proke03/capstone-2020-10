using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    enum AIState
    {
        Wait,   //대기
        Roam,   //배회
        Chase,  //공격하려고 다가감
        Attack
    }

    AIState state = AIState.Wait;

    private void Awake()
    {
        //상태 초기화
    }
    private void Start()
    {
        StartCoroutine("FSM");  //FSM 코루틴 실행.
    }

    private IEnumerator FSM() {
        while (true) {
            yield return StartCoroutine(state.ToString());
        }
    }
}
