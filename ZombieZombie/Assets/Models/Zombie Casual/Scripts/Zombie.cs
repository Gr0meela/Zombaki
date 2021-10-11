using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public GameObject[] good;
    public GameObject attackIt;
    public Zombies parametrs;
    public float currentHealth;

    [HideInInspector] public Animator animator;
    [HideInInspector] public NavMeshAgent meshAgent;
    [SerializeField] private Rigidbody[] bones;

    void Awake()
    {
        animator = GetComponent<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
        currentHealth = parametrs._health;

        for (int i = 0; i < bones.Length; i++)
        {
            bones[i].isKinematic = true;
            bones[i].gameObject.AddComponent<ZombieHealth>();
        }
    }

    private void Update()
    {
        if (currentHealth == 0)
        {
            Death();
        }
        good = GameObject.FindGameObjectsWithTag("Good");
        if (attackIt != null)
            animator.SetBool("run", true);
        FindTarget();
    }
    
    //Проверка, жив ли зомби
    void Death()
    {
        for (int i = 0; i < bones.Length; i++)
        {
            bones[i].isKinematic = false;
            bones[i].tag = "Dead";
        }
        animator.enabled = false;
        meshAgent.enabled = false;
        gameObject.tag = "Dead";
    }

    void FindTarget()
    {
        if (GameObject.FindWithTag("Player"))
            attackIt = closestGood();
        else
        {
            animator.SetBool("idle", true);
            attackIt = null;
        }
    }

    //Метод используется другими объектами. Изменяет здоровье зомби
    public void SetHealth(float difference)
    {
        currentHealth += difference;
        if (currentHealth > parametrs._health)
            currentHealth = parametrs._health;
        if (currentHealth < 0)
            currentHealth = 0;
    }

    //Определение ближайшей к зомби цели
    GameObject closestGood()
    {
        var minDistance = 10f;
        var target = GameObject.FindWithTag("Player");
        for (int i = 0; i < good.Length; i++)
        {
            if (Vector3.Distance(transform.position, good[i].transform.position) <= minDistance)
            {
                target = good[i];
                minDistance = Vector3.Distance(transform.position, good[i].transform.position);
            }
        }
        return target;
    }
}
