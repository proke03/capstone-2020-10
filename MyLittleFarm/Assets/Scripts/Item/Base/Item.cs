using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// item namespace
namespace IN {

    public abstract class Item : MonoBehaviour {

        /// <summary>
        /// 사용 후 재사용 대기시간
        /// </summary>
        public float delay = 0.2f;

        /// <summary>
        /// 아이템이 활성화 될 때 한 번 호출됨(아이템을 손에 든 경우 호출)
        /// </summary>
        public virtual void Activated(CharacterController2D controller) { }

        /// <summary>
        /// 아이템이 비활성화 될 때 한 번 호출됨(아이템을 다른 것으로 교체 할 때 호출)
        /// </summary>
        public virtual void Deactivated(CharacterController2D controller) { }

        /// <summary>
        /// 도구 사용할 때 업데이트가 필요한 경우 이용(커서 표시 등)
        /// </summary>
        public virtual void UpdateFunction(CharacterController2D controller, Vector2 mousePosition) { }

        /// <summary>
        /// 사용 시 호출 될 함수
        /// </summary>
        public abstract IEnumerator Use(CharacterController2D controller, Vector2 mousePosition);

    }

}