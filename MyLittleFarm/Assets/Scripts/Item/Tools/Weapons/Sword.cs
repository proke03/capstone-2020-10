using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

namespace IN {

    public class Sword : NonGridBasedItem, IRotateable {
        [System.Serializable]
        public struct AttackRange {
            /// <summary>
            /// 무기 좌표 기준 offset
            /// </summary>
            public Vector2 offset;

            /// <summary>
            /// 공격 범위의 절반
            /// </summary>
            public Vector2 extends;
        }

        public AttackRange attackRange;

        //private float angle;
        private Bounds collisionBounds;

        private int combo = 0;

        private float tempAngle;

        public override void Activated(CharacterController2D controller) {
            controller.hand.defaultAngle = 20;
            controller.hand.Origin = new Vector2(0.25f, 0.25f);
        }

        public override void Deactivated(CharacterController2D controller) {
            controller.hand.defaultAngle = 0;
            controller.hand.Origin = new Vector2(0.0f, 0.25f);
        }

        public IEnumerator Animation(CharacterController2D controller) {
            if (combo == 0)
                yield return controller.hand.RotatePlusAngle(-220, 0.1f).WaitForCompletion();
            else
                yield return controller.hand.RotatePlusAngle(0, 0.1f).WaitForCompletion();
        }

        public override void UpdateFunction(CharacterController2D controller, Vector2 mousePosition) {
            tempAngle = controller.hand.Angle;
        }

        public override IEnumerator Use(CharacterController2D controller, Vector2 mousePosition) {
            collisionBounds.size = attackRange.extends * 2;
            collisionBounds.center = transform.parent.position + Quaternion.AngleAxis(controller.hand.Angle, Vector3.forward) * attackRange.offset;

            var swingCoroutine = StartCoroutine(SwingStart(controller, collisionBounds, controller.hand.Angle));

            yield return Animation(controller);

            combo = (combo + 1) % 2;

            StopCoroutine(swingCoroutine);
            HitListClear();
        }

        private List<HitCheckModule> hitObjects = new List<HitCheckModule>();

        IEnumerator SwingStart(CharacterController2D controller, Bounds bounds, float _angle) {
            // 카메라 흔들기나 효과음 출력 한번만 하기 위한 플래그
            bool impulseFlag = true;

            while (true) {
                int z = controller.CurrentLayer;
                var hits = Physics2D.OverlapBoxAll(bounds.center, bounds.size, _angle, 1 << z).Where(x => x.CompareTag("Hitable")).ToList();

                for (int i = 0; i < Mathf.Min(hits.Count, /*임시 hitableCount*/1); i++) {
                    var hit = hits[i];

                    if (hit) {
                        if (impulseFlag) { GameManager.Instance.impulseSource.GenerateImpulse(); impulseFlag = false; }

                        /// 임시 코드 (나중에 캐싱해서 사용해야 할 듯)
                        var hitCheckModule = hit.transform.parent.GetComponent<HitCheckModule>();
                        hitCheckModule.OnHit((hit.transform.parent.position - transform.parent.position).normalized, /*임시 knockback*/100);

                        hitObjects.Add(hitCheckModule);
                    }
                }

                yield return new WaitForSeconds(/*임시 hitCheckInterval*/0.2f);
            }
        }

        /// <summary>
        /// 공격 끝났을 때 피격된 오브젝트들 피격가능판정 초기화 하기 위한 메소드
        /// </summary>
        private void HitListClear() {
            foreach (var i in hitObjects) {
                //i.Clear();
            }
            hitObjects.Clear();
        }   

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            //Debug.Log(transform.lossyScale);
            Gizmos.matrix = Matrix4x4.TRS(transform.parent.parent.position, Quaternion.Euler(0, 0, tempAngle), transform.localScale);
            Gizmos.DrawWireCube(attackRange.offset, attackRange.extends * 2);
        }
    }

}