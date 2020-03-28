using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace IN {

    public class Sword : NonGridBasedItem, IRotateable {
        private int combo = 0;

        public override void Activated(CharacterController2D controller) {
            controller.hand.defaultAngle = 40;
            controller.hand.Origin = new Vector2(0.18f, 0.25f);
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

        public override IEnumerator Use(CharacterController2D controller, Vector2 mousePosition) {
            yield return Animation(controller);

            combo = (combo + 1) % 2;
        }
    }

}