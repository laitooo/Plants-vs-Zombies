using System.Collections;
using UnityEngine;

public class Plant1 : MonoBehaviour {
    private Transform target;

    [Header("Attributes")]
    public float rotatingSpeed = 5f;
    public float fireRate = 1f;
    private float fireConutdown = 0f;

    [Header("Unity setup fields")]
    public string zombieTag;

    void Start() {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(zombieTag);
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null) { // TODO: check they are on the same lane too
            target = closestEnemy.transform;
        } else {
            target = null;
        }
    }

    void Update() {
        if (target == null) {
            return;
        }

        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotatingSpeed)
        .eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireConutdown <= 0f) {
            shoot();
            fireConutdown = 1f / fireRate;
        }

        fireConutdown -= Time.deltaTime;
    }

    void shoot() {
        print("shoot");
    }
}
