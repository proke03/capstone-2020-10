using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IN {

    /// <summary>
    /// 마우스가 정해진 범위 내에 있으면 마우스 위치에 있는 타일을 선택
    /// 정해진 범위 밖을 벗어나면 캐릭터를 기준으로 마우스 방향 앞 타일 선택하는 아이템 기본 클래스
    /// </summary>
    public abstract class RangeGridItem : Item {
        public float range = 1.5f;

        static Vector3Int[] direction = { Vector3Int.left, Vector3Int.down, Vector3Int.right, Vector3Int.up };
        int index = 0;

        public override void Activated(CharacterController2D controller) {
            GameManager.Instance.rectTarget.SetActive(true);
        }

        public override void Deactivated(CharacterController2D controller) {
            GameManager.Instance.rectTarget.SetActive(false);
        }

        public override void UpdateFunction(CharacterController2D controller, Vector2 mousePosition) {
            Vector3 characterPosition = VectorExt.FloorToInt(controller.transform.position) + Vector3.one * 0.5f;

            float length = (mousePosition - (Vector2)characterPosition).magnitude;
            if (length <= range) {

                GameManager.Instance.SetRectTargetPosition(mousePosition);

            } else {
                float angle = Mathf.Atan2(mousePosition.y - characterPosition.y, mousePosition.x - characterPosition.x) * Mathf.Rad2Deg;
                /// 0: left, 1: down, 2: right, 3: up
                index = Mathf.RoundToInt((angle + 180) / 90.0f) % 4;
                GameManager.Instance.SetRectTargetPosition(characterPosition + direction[index]);
            }
        }

        public override IEnumerator Use(CharacterController2D controller, Vector2 mousePosition) {
            Vector3 characterPosition = VectorExt.FloorToInt(controller.transform.position) + Vector3.one * 0.5f;

            Vector3Int selected = Vector3Int.zero;

            /// 마우스와 캐릭터 사이 거리가 특정 범위 내인 경우 마우스 위치를 전달.
            float length = (mousePosition - (Vector2)characterPosition).magnitude;
            if (length <= range) {
                selected = Vector3Int.FloorToInt(mousePosition);
            } else {
                selected = Vector3Int.FloorToInt(controller.transform.position) + direction[index];
            }

            selected.z = Mathf.FloorToInt(-controller.transform.position.z);

            yield return UseInRangeGrid(controller, selected);
        }

        protected abstract IEnumerator UseInRangeGrid(CharacterController2D controller, Vector3Int selected);

        //private void OnDrawGizmos() {
        //    Gizmos.color = Color.white;
        //    Gizmos.DrawWireSphere(cp, length);
        //    Gizmos.color = Color.magenta;
        //    Gizmos.DrawWireSphere(cp, range);
        //    Gizmos.color = Color.blue;
        //    Gizmos.DrawWireCube(cp, Vector3.one * 3.0f);
        //}
    }

}