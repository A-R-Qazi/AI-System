using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qazi.Modules.AI
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] Transform PlayerStart;
        [SerializeField] Player playerResource;

        public Player _player;

        public GameManager()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            _player = Instantiate<Player>(playerResource);
            _player.transform.position = PlayerStart.position;
            _player.transform.rotation= PlayerStart.rotation;

            EnemySystem e = EnemySystem.Instance;
            e.UpdateEnemies();
        }
    }
}
