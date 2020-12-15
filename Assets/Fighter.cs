using System.Collections.Generic;
using UnityEngine;
namespace Qazi.Modules.AI
{
    public class Fighter:MonoBehaviour,IDamageable
    {
        public float health = 10;
        public Weapon weapon;

        public Dictionary<EWeaponType, Weapon> weapons;

        public Fighter()
        {
            weapons = new Dictionary<EWeaponType, Weapon>();
        }
        public void Die()
        {
            Destroy(gameObject);
        }
        private void Start()
        {
            weapons.Add(EWeaponType.None, null);
            foreach(Weapon w in GetComponentsInChildren<Weapon>())
            {
                weapons.Add(w.GetWeaponType(), w);
                w.gameObject.SetActive(false);
            }
        }
        public void TakeDamage(float Damage)
        {
            health -= Damage;
            if (health <= 0)
            {
                Die();
            }
        }
        public bool SwitchWeapon(EWeaponType type)
        {
            if (weapons.ContainsKey(type))
            {
                if(weapon != null)
                {
                    weapon.GetComponent<Transform>().gameObject.SetActive(false);
                    if(type == weapon.GetWeaponType())
                    {
                        weapon = weapons[EWeaponType.None];
                        return true;
                    }
                }
                weapon = weapons[type];
                weapon.gameObject.SetActive(true);
                return true;
            }
            return false;
        }
    }
}