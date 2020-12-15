using UnityEngine;

namespace Qazi.Modules.AI
{
    public class Weapon :ChildComponent
    {
        public Transform start;

        [SerializeField]
        public LayerMask mask;
        public float CoolDown = 0.1f;
        public float CoolDown_Rem = 0;
        public float Damage;

        public EWeaponType WeaponType;
        [Range(100, 500)]
        public int length = 350;
        public virtual void ShootAt(bool shoot, Vector3 target) { }
        public EWeaponType GetWeaponType()
        {
            return WeaponType;
        }
    }
    public enum EWeaponType
    {
        None,
        Melee,
        Primary,
        Secondary,
        Side
    }
}