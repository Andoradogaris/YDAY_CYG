using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAController_V2 : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth = 100;

    private bool isDead;
    [SerializeField]
    private bool isFollowingPlayer;

    private NavMeshAgent agent;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject spawnPoint;

    private bool canhit = true;

    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float attentionRange;
    [SerializeField]
    private float farerPos;

    GameManager gameManager;

    RaycastHit hit;

    float dissolveValue = 1;

    #region Start
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        health = maxHealth;
    }
    #endregion

    private void Update()
    {


        #region Gestion de la mort
        if (health > 0)
        {
            isDead = false;
        }
        else
        {
            isDead = true;
        }
        #endregion

        if (!isDead)
        {
            if (!isFollowingPlayer)
            {
                if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit))
                {
                    float distance = hit.distance;
                    int mask = 1 << LayerMask.NameToLayer("Player");
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player") && distance <= attackRange)
                    {
                        Chase();
                    }
                    else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player") && distance <= attentionRange)
                    {
                        Chase();
                    }
                    else
                    {
                        isFollowingPlayer = false;
                    }
                }
            }
            else
            {
                if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, ~(LayerMask.NameToLayer("Ignore Raycast"))))
                {
                    float distance = hit.distance;
                    int mask = 1 << LayerMask.NameToLayer("Player");
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player") && distance <= attackRange)
                    {
                        Chase();
                    }
                    else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player") && distance <= attentionRange)
                    {
                        Chase();
                    }
                    else
                    {
                        isFollowingPlayer = false;
                    }
                }
            }

            #region Taille Zone D�tection
            if (gameManager.isShooting)
            {
                attentionRange *= 10;
                attackRange *= 10;
            }
            else if (gameManager.isRunning)
            {
                attentionRange *= 2;
                attackRange *= 2;
            }
            else if (gameManager.isCrouching)
            {
                attentionRange /= 2;
                attackRange /= 2;
            }
            else
            {
                attentionRange = 12;
                attackRange = 24;
            }
            #endregion*/

            Move();
        }
        else
        {
            Die();
        }
        ClampHealth();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.transform.position);
    }

    void Chase()
    {
        isFollowingPlayer = true;
        if (agent.remainingDistance > 0.1 && agent.remainingDistance <= 3.1 && canhit && isFollowingPlayer)
        {
            StartCoroutine(Hit());
        }
        else
        {
            if (hit.distance >= farerPos)
            {
                isFollowingPlayer = false;
            }
            else
            {
                Move();
            }
        }
    }

    void Move()
    {
        if (isFollowingPlayer)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            if (transform.position != spawnPoint.transform.position)
            {
                agent.SetDestination(spawnPoint.transform.position);
            }
        }
    }

    #region TakeDamage
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    #endregion

    #region ClampHealth
    void ClampHealth()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health < 0)
        {
            health = 0;
        }
    }
    #endregion

    #region Die
    void Die()
    {
        agent.speed = 0;
        dissolveValue -= Time.deltaTime;
        GetComponent<MeshRenderer>().material.SetFloat("_DissolveValue", dissolveValue);
        Destroy(gameObject, 1);
    }
    #endregion

    #region Hit
    IEnumerator Hit()
    {
        canhit = false;
        gameManager.UpdateHealth(-20f);
        Debug.Log(name + " a fait 20 dégâts");
        yield return new WaitForSeconds(1f);
        canhit = true;
    }
    #endregion
}