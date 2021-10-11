using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject[] evil;
    public GameObject attackIt;
    public Props parametrs;
    public float currentHealth;
    [SerializeField] private Transform roll;
    public Transform head;
    public Transform turret;
    public Transform shootPoint;
    public float headRotationSpeed = 360;
    public float turretRotationSpeed = 180;
    [SerializeField] private Collider[] bones;
    [SerializeField] private float rollRotationSpeed = 360;
    [HideInInspector] public Animator animator;

    [HideInInspector] public Ray ray;
    void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = parametrs._health;
        for (int i = 0; i < bones.Length; i++)
        {
            bones[i].gameObject.AddComponent<TurretHealth>();
        }
    }

    private void Update()
    {
        if (currentHealth == 0)
        {
            //Instantiate(Взрыв);
            Death();
        }
        evil = GameObject.FindGameObjectsWithTag("Evil");
        FindTarget();

        Shoot();
    }
    void Death()
    {
        Destroy(gameObject);
    }
    void FindTarget()
    {
        if (closestEvil() != null)
        {
            attackIt = closestEvil();
            animator.SetBool("rotate", true);
            RotateRoll();
        }
        else
        {
            animator.SetBool("search", true);
            attackIt = null;
        }
    }
    public void SetHealth(float difference)
    {
        currentHealth += difference;
        if (currentHealth > parametrs._health)
            currentHealth = parametrs._health;
        if (currentHealth < 0)
            currentHealth = 0;
    }
    GameObject closestEvil()
    {
        var minDistance = 10f;
        GameObject target = null;
        for (int i = 0; i < evil.Length; i++)
        {
            if (Vector3.Distance(transform.position, evil[i].transform.position) <= minDistance)
            {
                target = evil[i];
                minDistance = Vector3.Distance(transform.position, evil[i].transform.position);
            }
        }
        return target;
    }
    private void RotateRoll()
    {
        roll.rotation*= Quaternion.AngleAxis(rollRotationSpeed * Time.deltaTime, Vector3.forward);
    }

    void Shoot()
    {
        ray = new Ray(shootPoint.position, shootPoint.forward * 9f);
        Debug.DrawRay(shootPoint.position, shootPoint.forward * 9f, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<ZombieHealth>())
            {
                Debug.Log(hit.collider.name);
                hit.collider.gameObject.GetComponent<ZombieHealth>().SetHealth(-1f);
            }
        }
    }
}
