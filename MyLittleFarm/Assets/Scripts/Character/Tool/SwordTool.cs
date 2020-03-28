//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
////using CreativeSpore.SuperTilemapEditor;
//using DG.Tweening;

//public class SwordTool : ToolBase {
//    // 나중에 weapon scriptableobject 만들면 거기로 옮기기
//    [System.Serializable]
//    public struct AttackRange {
//        /// <summary>
//        /// 무기 좌표 기준 offset
//        /// </summary>
//        public Vector2 offset;

//        /// <summary>
//        /// 공격 범위의 절반
//        /// </summary>
//        public Vector2 extends;
//    }

//    public AttackRange attackRange;

//    private Bounds collisionBounds;

//    private float angle;

//    private int combo = 0;

//    private SpriteRenderer sprite;

//    private WeaponData weaponData;

//    private void Awake() {
//        sprite = GetComponent<SpriteRenderer>();
//        collisionBounds.size = attackRange.extends * 2;

//        weaponData = data as WeaponData;

//        sprite.sprite = weaponData.sprite;
//    }

//    public override void UpdateFunction(CharacterController2D controller, int direction) {
//        MouseTrackingHelper(direction);

//        Vector2 characterPosition = controller.transform.position;
//        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//        angle = Mathf.Atan2(mousePosition.y - characterPosition.y, mousePosition.x - characterPosition.x) * Mathf.Rad2Deg;

//        transform.parent.rotation = Quaternion.Euler(0, 0, angle + combo * -220 * direction);

//        /// Quaternion.AngleAxis(회전 각도, 회전시킬 축(2D니까 z축만 회전) * 회전시킬 축?) = angle 값 만큼 회전된 좌표값 나옴
//        collisionBounds.center = transform.parent.position + Quaternion.AngleAxis(angle, Vector3.forward) * attackRange.offset;
//    }

//    public override IEnumerator Action(CharacterController2D controller, params object[] args) {
//        var swingCoroutine = StartCoroutine(SwingStart(collisionBounds, angle));

//        yield return Animation();

//        StopCoroutine(swingCoroutine);
//        HitListClear();

//        combo = (combo + 1) % 2;

//        yield return new WaitForSeconds(weaponData.speed - weaponData.swingAnimationSpeed);
//    }

//    public override IEnumerator Animation() {
//        if (combo == 0)
//            yield return transform.parent.DOLocalRotate(Vector3.forward * -220, weaponData.swingAnimationSpeed).SetRelative().SetOptions(false).WaitForCompletion();
//        else
//            yield return transform.parent.DOLocalRotate(Vector3.forward * 220, weaponData.swingAnimationSpeed).SetRelative().SetOptions(false).WaitForCompletion();
//    }

//    private List<HitCheckModule> hitObjects = new List<HitCheckModule>();

//    IEnumerator SwingStart(Bounds bounds, float _angle) {
//        // 카메라 흔들기나 효과음 출력 한번만 하기 위한 플래그
//        bool impulseFlag = true;

//        while (true) {
//            var hits = Physics2D.OverlapBoxAll(bounds.center, bounds.size, _angle, LayerMask.GetMask("Hitable"));

//            for (int i = 0; i < Mathf.Min(hits.Length, weaponData.hitableCount); i++) {
//                var hit = hits[i];

//                if (hit) {
//                    if (impulseFlag) { GameManager.Instance.impulseSource.GenerateImpulse(); impulseFlag = false; }

//                    /// 임시 코드 (나중에 캐싱해서 사용해야 할 듯)
//                    var hitCheckModule = hit.transform.parent.GetComponent<HitCheckModule>();
//                    hitCheckModule.OnHit((hit.transform.parent.position - transform.parent.position).normalized, weaponData.knockback);

//                    hitObjects.Add(hitCheckModule);
//                }
//            }

//            yield return new WaitForSeconds(weaponData.hitCheckInterval);
//        }
//    }

//    /// <summary>
//    /// 공격 끝났을 때 피격된 오브젝트들 피격가능판정 초기화 하기 위한 메소드
//    /// </summary>
//    private void HitListClear() {
//        foreach (var i in hitObjects) {

//        }
//        hitObjects.Clear();
//    }

//    private void OnDrawGizmos() {
//        Gizmos.color = Color.red;
//        Gizmos.matrix = Matrix4x4.TRS(transform.parent.position, Quaternion.Euler(0, 0, angle), transform.lossyScale);
//        Gizmos.DrawWireCube(attackRange.offset, attackRange.extends * 2);
//    }
//}