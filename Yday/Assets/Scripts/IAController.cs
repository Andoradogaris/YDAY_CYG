using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAController : MonoBehaviour
{
    [SerializeField]
    private float health;
    private float maxHealth = 100;

    private bool isDead;

    private NavMeshAgent agent;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject attentionRange;
    [SerializeField]
    private GameObject attackRange;

    [SerializeField]
    private Material mat;

    [SerializeField]
    private bool isShooting;

    private bool canhit = true;

    [SerializeField]
    private float attentionRadius;
    [SerializeField]
    private float attackRadius;

    GameManager gameManager;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        health = maxHealth;
    }

    private void Update()
    {
        if(health > 0)
        {
            isDead = false;
        }
        else
        {
            isDead = true;
        }

        if (!isDead)
        {
            if (attentionRange.GetComponent<checkCollider>().isPlayer)
            {
                mat.color = new Color(255, 255, 0);

                if (attackRange.GetComponent<checkCollider>().isPlayer)
                {
                    mat.color = new Color(255, 0, 0);
                    agent.SetDestination(player.transform.position);
                }
                else
                {
                    mat.color = new Color(255, 255, 0);
                }
            }

            if(agent.remainingDistance > 0 && agent.remainingDistance <= 3.1 && canhit)
            {
                canhit = false;
                StartCoroutine(Hit());
            }

            else
            {
                mat.color = new Color(0, 255, 0);
            }

            if (gameManager.isShooting)
            {
                attentionRange.GetComponent<SphereCollider>().radius = attentionRadius * 10;
                attackRange.GetComponent<SphereCollider>().radius = attackRadius * 10;
            }
            else if (gameManager.isRunning)
            {
                attentionRange.GetComponent<SphereCollider>().radius = attentionRadius * 2;
                attackRange.GetComponent<SphereCollider>().radius = attackRadius * 2;
            }
            else if (gameManager.isCrouching)
            {
                attentionRange.GetComponent<SphereCollider>().radius = attentionRadius / 2;
                attackRange.GetComponent<SphereCollider>().radius = attackRadius / 2;
            }
            else
            {
                attentionRange.GetComponent<SphereCollider>().radius = attentionRadius;
                attackRange.GetComponent<SphereCollider>().radius = attackRadius;

            }

        }
        else
        {
            Die();
        }
        ClampHealth();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    void ClampHealth()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if(health < 0)
        {
            health = 0;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator Hit()
    {
        gameManager.UpdateHealth(-20);
        yield return new WaitForSeconds(1f);
        canhit = true;
    }
}
