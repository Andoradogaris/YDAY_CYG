using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAController : MonoBehaviour
{
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
    private bool isRunning;
    [SerializeField]
    private bool isCrouching;
    [SerializeField]
    private bool isShooting;

    private bool canhit = true;

    [SerializeField]
    private float attentionRadius;
    [SerializeField]
    private float attackRadius;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
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

        if(agent.remainingDistance >= 0 && agent.remainingDistance <= 5 && canhit)
        {
            canhit = false;
            StartCoroutine(Hit());
        }

        else
        {
            mat.color = new Color(0, 255, 0);
        }

        if (isShooting)
        {
            attentionRange.GetComponent<SphereCollider>().radius = attentionRadius * 10;
            attackRange.GetComponent<SphereCollider>().radius = attackRadius * 10;
        }
        else if (isRunning)
        {
            attentionRange.GetComponent<SphereCollider>().radius = attentionRadius * 2;
            attackRange.GetComponent<SphereCollider>().radius = attackRadius * 2;
        }
        else if (isCrouching)
        {
            attentionRange.GetComponent<SphereCollider>().radius = attentionRadius / 2;
            attackRange.GetComponent<SphereCollider>().radius = attackRadius / 2;
        }
        else
        {
            attentionRange.GetComponent<SphereCollider>().radius = attentionRadius;
            attackRange.GetComponent<SphereCollider>().radius = attackRadius;

        }

        IEnumerator Hit()
        {
            Debug.Log("Hit");
            yield return new WaitForSeconds(1f);
            canhit = true;
        }
    }
}
