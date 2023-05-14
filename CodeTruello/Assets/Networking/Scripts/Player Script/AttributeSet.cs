using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSet : MonoBehaviour
{

    private float CurrentHealth;
    private float MaxHealth;
    private float Damage;
    private float Armor;
    
    public void SetCurrentHealth(float CurrentHealth) {
        this.CurrentHealth = CurrentHealth;
    }
    public void SetMaxHealth(float MaxHealth) {
        this.MaxHealth = MaxHealth;
    }
    public void SetDamage(float Damage) {
        this.Damage = Damage;
    }
    public void SetArmor(float Armor) {
        this.Armor = Armor;
    }
    public float GetCurrentHealth() {
        return CurrentHealth;
    }
    public float GetMaxHealth() {
        return MaxHealth;
    }
    public float GetDamage() {
        return Damage;
    }
    public float GetArmor() {
        return Armor;
    }
    
}
