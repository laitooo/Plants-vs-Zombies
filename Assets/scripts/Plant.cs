using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour {

    [Header("Attributes")]
    public float rotatingSpeed = 20f;
    public float fireRange = 20f;
    public float firstFireTime = 2f;
    public float secondFireTime = 0f;
    private float fireConutdown = 0f;
    private bool hasDoubleChoot;
    private bool isCurrentFirst = true;

    [Header("Unity setup fields")]
    private Transform target;
    public string zombieTag = "Zombie";
    public GameObject bulletPrefab;

    void Start() {
        hasDoubleChoot = secondFireTime != 0f;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(zombieTag);
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < fireRange) {
                if(distanceToEnemy < shortestDistance) {
                    shortestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }
            
        }

        if (closestEnemy != null) { 
            // TODO : check they are on the same lane too
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
            if (!hasDoubleChoot) {
                fireConutdown = firstFireTime;
            } else {
                // TODO: fix the delay that happens sometime
                if (isCurrentFirst) {
                    fireConutdown = firstFireTime;
                } else {
                    fireConutdown = secondFireTime;
                }
                isCurrentFirst = !isCurrentFirst;
            }
        }

        fireConutdown -= Time.deltaTime;
    }

    void shoot() {
        Vector3 newPosition = transform.position;
        newPosition.y += 2f;
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, newPosition, transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.seek(target);
    }
}
