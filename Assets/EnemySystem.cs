using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Qazi.Modules.AI
{
    public class EnemySystem : MonoBehaviour
    {
        public static EnemySystem Instance;
        [SerializeField]
        Enemy EnemyResource;

        [SerializeField] List<Enemy> enemies;

        [SerializeField]
        int Max_Enemies = 1;

        [SerializeField]
        float SpawnDistance;
        [SerializeField] int areaMask;
        public EnemySystem()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        public void Start()
        {
            enemies = new List<Enemy>();
        }
        public void UpdateEnemies()
        {
            Player p = GameManager.Instance._player;
            for (int i = 0; i < Max_Enemies; i++)
            {
                NavMeshHit hit = new NavMeshHit();
                while (!hit.hit)
                {
                    if(NavMesh.SamplePosition(p.transform.position,out hit, SpawnDistance, NavMesh.AllAreas))
                    {
                        Enemy e = Instantiate<Enemy>(EnemyResource);
                        e.transform.position = hit.position;
                        enemies.Add(e);
                    }

                }
            }
        }
    }

}