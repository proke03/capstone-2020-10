using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

namespace IN {

    public class Pickaxe : RangeGridItem {

        //public override void UpdateFunction(CharacterController2D controller, Vector2 mousePosition) {
        //    Vector2Int pos = Vector2Int.FloorToInt(mousePosition);

        //    GameManager.Instance.triTarget.SetActive(false);

        //    if (MapObjectManager.Instance.objectData.ContainsKey( (pos.x, pos.y) )) {
        //        GameManager.Instance.triTarget.SetActive(true);
        //        GameManager.Instance.SetTriTargetPosition(mousePosition + Vector2.up * 1);
        //    }

        //    //GameManager.Instance.SetRectTargetPosition(mousePosition);

        //    // 나중에 선택된 오브젝트 세로 길이 구해서 그 위에 화살표 띄워주도록 하는게 좋을듯.
        //}

        protected IEnumerator Animation(CharacterController2D controller) {
            var sequence = DOTween.Sequence();

            sequence.Append(controller.hand.DOLocalRotate(new Vector3(0, 0, 120), 0.2f).SetOptions(false));
            sequence.Append(controller.hand.DOLocalRotate(new Vector3(0, 0, -90), 0.1f).SetOptions(false));

            sequence.AppendCallback(() => GameManager.Instance.impulseSource.GenerateImpulse());

            sequence.Append(controller.hand.DOLocalRotate(new Vector3(0, 0, 0), 0.1f).SetOptions(true));

            yield return sequence.WaitForCompletion();
        }



        protected override IEnumerator UseInRangeGrid(CharacterController2D controller, Vector3Int s) {
            if (!MapObjectManager.Instance.objectData.ContainsKey((s.x, s.y, s.z))) {
                yield break;
            }

            yield return Animation(controller);

            MapObjectManager.Instance.objectData[(s.x, s.y, s.z)].DoDamage(1);

            yield return null;
        }
    }

}