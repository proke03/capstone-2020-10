using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace IN {

    public abstract class GridBaseItem : Item {
        public override void Activated(CharacterController2D controller) {
            //CursorController.Instance.SetMouseTargetMode(value: true, interaction: false);
            //CursorController.Instance.SetAutoGridPosition(value: true, interaction: false);
        }

        public override IEnumerator Use(CharacterController2D controller, Vector2 mousePosition) {
            Vector3Int selected = new Vector3Int(Mathf.FloorToInt(mousePosition.x), Mathf.FloorToInt(mousePosition.y), Mathf.FloorToInt(-controller.transform.position.z));

            yield return UseInGrid(controller, selected);
        }

        /// <summary>
        /// 아이템이 사용될 때 마우스가 클릭한 칸의 좌표를 같이 얻는 Use 상속 함수
        /// </summary>
        /// <param name="selected">마우스로 클릭된 칸의 좌표(x: 그리드 x, y: 그리드 y, z: 캐릭터 z축 위치)</param>
        /// <returns></returns>
        protected abstract IEnumerator UseInGrid(CharacterController2D controller, Vector3Int selected);
    }

}