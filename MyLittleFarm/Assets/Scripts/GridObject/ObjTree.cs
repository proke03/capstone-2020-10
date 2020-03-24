//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;

//public class ObjTree : GridObject {
//    public GameObject dropItem;

//    public override void OnDamaged(uint damage) {
//        //transform.DOShakePosition(0.15f, 0.15f, 16, 90, false, true);
//    }

//    public override void OnDestroyed() {
//        Debug.Log("destroy");
//        Instantiate(dropItem, (Vector2)transform.position, Quaternion.identity);

//        GameManager.Instance.objectMap.RemoveObject(x, y);
//        Destroy(gameObject);
//    }
//}