using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator m_animator;

    public int maxHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play hurt sound
        AudioManager.Instance.PlaySFX(SFX.HIT);

        // Play hurt animation
        m_animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioManager.Instance.PlaySFX(SFX.DEATH);
        m_animator.SetTrigger("Death");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        Destroy(gameObject, 0.8f);
    }
}
