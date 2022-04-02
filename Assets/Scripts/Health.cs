using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] long hp_max;
    long hp_current;
    [SerializeField] float invuln_time;
    float time_of_last_hit;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color color_blink;
    Color color_normal;
    Animator animator;
    [SerializeField] HealthDisplay healthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        hp_current = hp_max;
        color_normal = spriteRenderer.color;
        time_of_last_hit = float.MinValue;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Heal(long dmg)
    {
        hp_current = Math.Min(hp_current + dmg, hp_max);
        UpdateHealthDisplay();
    }

    public void ApplyDamage(long dmg)
    {
        float cur_time = Time.time;
        if (cur_time - time_of_last_hit > invuln_time)
        {
            hp_current = Math.Max(hp_current - dmg, 0);
            time_of_last_hit = cur_time;
            StartCoroutine(Blink());
            UpdateHealthDisplay();
            if (hp_current <= 0) {
                Die();
            }
        }


    }

    void UpdateHealthDisplay() 
    {
        if (healthDisplay != null) 
        {
            healthDisplay.SetHealth((float)hp_current / (float)hp_max);
        }
    }

    IEnumerator Blink()
    {
        animator.Play("Change Color");
        yield return new WaitForSeconds(invuln_time);
        animator.Play("Idle");
    }

    void Die() {
        Destroy(gameObject);
    }
}
