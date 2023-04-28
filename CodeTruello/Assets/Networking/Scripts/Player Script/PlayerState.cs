using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public AttributeSet PlayerAttribute;
    GameObject weapon;
    public string playerTag;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAttribute.SetCurrentHealth(5000);
        PlayerAttribute.SetMaxHealth(5000);
        PlayerAttribute.SetDamage(120);
        PlayerAttribute.SetArmor(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakingDamage(float dmg) {
        float totalDamage;
        if(dmg >= PlayerAttribute.GetArmor()) {
            totalDamage = dmg * 2 - PlayerAttribute.GetArmor();
        }
        else {
            totalDamage = dmg * dmg / PlayerAttribute.GetArmor();
        }

        if(PlayerAttribute.GetCurrentHealth() <= 0) {
            Destroy(this, 2);
        }
        else {
            float currentHealth = PlayerAttribute.GetCurrentHealth();
            PlayerAttribute.SetCurrentHealth(currentHealth);
        }
        Debug.Log("armor: " + PlayerAttribute.GetArmor());
        Debug.Log("I took " + totalDamage + " damage");
    }
}
