using System;
using UnityEngine;

namespace Stratagems
{
    [CreateAssetMenu(menuName = "Stratagem")]
    [Serializable]
    public class Stratagem : ScriptableObject
    {
        public float Timer;
        public int[] Arrows;
        public Sprite Icon;

        // [ContextMenu(nameof(MachineGun))]
        // public void MachineGun()
        // {
        //     Timer = 2;
        //     Arrows = new[] { 270, 0, 270, 90 };
        // }
        // [ContextMenu(nameof(MineField))]
        // public void MineField()
        // {
        //     Timer = 3;
        //     Arrows = new[] { 270, 270, 0, 180,90,270,0,0 };
        // }
        // [ContextMenu(nameof(Laser))]
        // public void Laser()
        // {
        //     Timer = 2;
        //     Arrows = new[] { 180, 90, 0, 180,};
        // }
        // [ContextMenu(nameof(Car))]
        // public void Car()
        // {
        //     Timer = 2;
        //     Arrows = new[] { 0, 180, 180, 0,90,270};
        // }
        // [ContextMenu(nameof(EagleNuke))]
        // public void EagleNuke()
        // {
        //     Timer = 3;
        //     Arrows = new[] { 0, 180, 180, 180 };
        // }
        // [ContextMenu(nameof(Patriot))]
        // public void Patriot()
        // {
        //     Timer = 4;
        //     Arrows = new[] { 270, 0, 0, 180,90};
        // }

    }
}
