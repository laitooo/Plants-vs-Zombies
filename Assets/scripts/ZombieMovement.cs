using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Zombie))]
public class ZombieMovement : MonoBehaviour {
    private Zombie zombie;
    private Transform target;
    private int waveNumber;
    public Animator animator;
    private int isEatingHash;
    private bool isEating = false;
    public Collider plant;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Plant") {
            isEating = true;
            plant=other;
            animator.SetBool(isEatingHash, true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Plant") {
            isEating = false;
            animator.SetBool(isEatingHash, false);
        }
    }
    

    void Start() {
        zombie = GetComponent<Zombie>();
        int index = (int) (transform.position.x / 4);
        target = WayPoints.points[index];

        isEatingHash = Animator.StringToHash("isEating");
    }

    void Update() {
        if (!isEating ) {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * zombie.speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.5f) {
                reachedEnd();
            }

            if (zombie.slownessTimer <= 0f) {
                zombie.speed = zombie.defaultSpeed;
            } else {
                zombie.slownessTimer -= Time.deltaTime;
            }
        } else if (plant == null){
            isEating = false;
            animator.SetBool(isEatingHash, false);
        }
    }

    void reachedEnd() {
        PlayerManager.instance.looseLife();
        WaveSpawner.zombiesAlive--;
        Destroy(gameObject);
    }
}
