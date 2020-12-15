using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Qazi.Modules.AI
{

public class Player : MonoBehaviour
{
        Fighter f;
        [SerializeField]
        LayerMask mask;
        [SerializeField]
        Image CrossHair = null;

        private void Start()
        {
            f = GetComponent<Fighter>();
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                f.SwitchWeapon(EWeaponType.Primary);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                f.SwitchWeapon(EWeaponType.Secondary);
            }
            float h = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, h);
            if (f.weapon != null)
            {
                Vector3 t = FindTarget();
                if (Input.GetKey(KeyCode.Space))
                {
                    //transform.LookAt(t, Vector3.up);    //Look At Target
                    //f.weapon.GetComponent<Transform>().LookAt(t, Vector3.up);     //Turn Weapon towards target
                    f.weapon.ShootAt(true, t);
                }
            }
        }

        Vector3 FindTarget()
        {
            Vector3 t;
            RaycastHit info;
            Transform wt = f.weapon.GetComponent<Transform>();
            if (Physics.Raycast(wt.position, wt.forward,out info, 250,mask))
            {
                t = info.point;
                CrossHair.color = Color.red;
            }
            else
            {
                t = wt.position + (wt.forward * 250);
                CrossHair.color = Color.green;
            }
            Debug.DrawLine(wt.position, t, Color.blue);

            CrossHair.transform.position = Camera.main.WorldToScreenPoint(t);
            
            return t;
        }
    }

}