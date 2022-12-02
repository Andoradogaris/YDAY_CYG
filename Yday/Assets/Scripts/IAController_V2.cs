using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class IAController_V2 : MonoBehaviour
{
    [SerializeField]
    private float health;
    private float maxHealth = 100;

    private bool isDead;
    private bool isFollowingPlayer;

    private NavMeshAgent agent;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private GameObject attentionRange;
    [SerializeField]
    private GameObject attackRange;

    private bool canhit = true;

    [SerializeField]
    private float attentionRadius;
    [SerializeField]
    private float attackRadius;

    GameManager gameManager;

    #region Start
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            if (attackRange.GetComponent<checkCollider>().isPlayer)
            {
                Debug.Log("is In attack Range");
                isFollowingPlayer = true;
            }
            else if (attentionRange.GetComponent<checkCollider>().isPlayer && !attackRange.GetComponent<checkCollider>().isPlayer)
            {    
                RaycastHit hit;
                int mask = 1 << LayerMask.NameToLayer("Player");

                if (Physics.Raycast(transform.position, player.transform.position, out hit))
                {
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                    {
                        isFollowingPlayer = true;
                        Debug.Log("is Only in attention Range but I can see you");
                    }
                    else
                    {
                        isFollowingPlayer = false;
                        Debug.Log("is Only in attention Range but hidden");
                    }
                }
            }
            else if (agent.remainingDistance >= attentionRange.GetComponent<SphereCollider>().radius * 5)
            {
                isFollowingPlayer = false;
            }
            Move();




            if (agent.remainingDistance > 0.1 && agent.remainingDistance <= 3.1 && canhit && isFollowingPlayer)
            {
                Debug.Log(agent.remainingDistance);
                canhit = false;
                StartCoroutine(Hit());
            }

         /*   #region Taille Zone Détection
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
            #endregion*/

        }
        else
        {
            Die();
        }
        ClampHealth();
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
        Destroy(gameObject);
    }
    #endregion

    #region Hit
    IEnumerator Hit()
    {
        //gameManager.UpdateHealth(-20f);
        Debug.Log(name + " a fait 20 dégâts");
        yield return new WaitForSeconds(1f);
        canhit = true;
    }
#endregion
}
