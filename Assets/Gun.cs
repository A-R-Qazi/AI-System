
using UnityEngine;


namespace Qazi.Modules.AI{
    public class Gun : Weapon
    {
        public override void ShootAt(bool shoot, Vector3 target)
        {

            if (!shoot)
            {
                CoolDown_Rem = CoolDown;
                return;
            }
            if (CoolDown_Rem < CoolDown)
            {
                CoolDown_Rem += Time.deltaTime;
                return;
            }
            CoolDown_Rem = 0;
            RaycastHit info;

            bool hit = Physics.Raycast(start.position, start.forward, out info, length,mask);
            Debug.DrawLine(start.position,hit?info.point:start.forward*length, Color.red,0.01f);

            if (hit)
            {
                IDamageable _d = info.collider.GetComponentInParent<IDamageable>();
                if (_d!=null)
                {
                    _d.TakeDamage(Damage);
                }
            }

        }




    }

}