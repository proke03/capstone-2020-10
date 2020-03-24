//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using CreativeSpore.SuperTilemapEditor;
//using DG.Tweening;

//public class SickleTool : ToolBase {
//    public override IEnumerator Action(CharacterController2D controller, params object[] args) {
//        yield return Animation();


//    }

//    public override IEnumerator Animation() {
//        var sequence = DOTween.Sequence();

//        sequence.Append(transform.parent.DOLocalRotate(Vector3.forward * 120, 0.2f).SetRelative());
//        sequence.Append(transform.parent.DOLocalRotate(Vector3.forward * -180, 0.1f).SetRelative());
//        sequence.Append(transform.parent.DOLocalRotate(Vector3.forward * 60, 0.2f).SetRelative());

//        yield return sequence.WaitForCompletion();
//    }
//}