using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Qazi.Modules.AI
{

    public class Enemy : MonoBehaviour
    {
        Player target;
        NavMeshAgent m_agent;

        Fighter f;
        [SerializeField]
        EWeaponType DefaultWeapon;

        public LayerMask lookFor;
        public float DetectionRange = 20;
        [Range(0, 180)]
        public float PeripheralVision = 60;

        [SerializeField]
        float ForgetDistance = 20;
        float lookAngle;

        private void Start()
        {
            f = GetComponent<Fighter>();
            lookAngle = 0;
            m_agent = GetComponent<NavMeshAgent>();
            f.SwitchWeapon(DefaultWeapon);
        }
        private void Update()
        {
            if (!target)
            {
                RaycastHit info;
                bool found = Physics.Raycast(transform.position, Quaternion.AngleAxis(lookAngle, Vector3.up) * transform.forward, out info, DetectionRange, lookFor);
                Debug.DrawLine(transform.position, transform.position + (Quaternion.AngleAxis(lookAngle, Vector3.up) * transform.forward * DetectionRange), Color.red);

                if (lookAngle >= PeripheralVision)
                {
                    lookAngle = -PeripheralVision;
                }
                lookAngle += 4f;
                print(found);
                if (found)
                {
                    target = info.collider.GetComponent<Player>();
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, target.transform.position) > ForgetDistance)
                {
                    target = null;
                }
                else
                {
                    if (Vector3.Distance(transform.position, target.transform.position) <= m_agent.stoppingDistance)
                    {
                        transform.LookAt(target.transform.position, Vector3.up);
                        if (f.weapon != null)
                        {
                            f.weapon.GetComponent<Transform>().LookAt(target.transform.position, Vector3.up);
                            f.weapon.ShootAt(true, target.transform.position);
                        }
                        return;
                    }
                    m_agent.SetDestination(target.transform.position);
                }
            }
        }
    }

}