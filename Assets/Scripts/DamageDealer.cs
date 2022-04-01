using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
  
    [SerializeField] long damage_amount;

    private void OnCollisionEnter2D(Collision2D other) {
        var health = other.gameObject.GetComponent<Health>();
        if (health != null) {
            health.ApplyDamage(damage_amount);
        }
    }
  
}
