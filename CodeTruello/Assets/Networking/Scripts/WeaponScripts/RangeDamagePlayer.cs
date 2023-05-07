using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RangeDamagePlayer : MonoBehaviour
{
    [SerializeField]
    float damage;
    GameObject Enemy;
    PlayerState PS_Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        string EnemyTag;
        //AttributeSet set = PS_Player.PlayerAttribute
        if (other != null)
        {
            EnemyTag = other.transform.gameObject.tag;
            if (EnemyTag == "Player1" || EnemyTag == "Player2")
            {
                Enemy = other.transform.gameObject;
                PS_Enemy = Enemy.GetComponent<PlayerState>();
                UnityEngine.Debug.Log("2) " + EnemyTag);
                if (PS_Enemy != null)
                {
                    PS_Enemy.TakingDamage(damage);
                }
                //PS_Enemy = Enemy.transform.parent.gameObject.GetComponent<PlayerState>();
                UnityEngine.Debug.Log("I am Dealing damage");

            }
        }
    }
}
