using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public GameObject impactEffect;
    public int damage = 5;
    public float speed = 1f;

    void Start() {
        
    }

    public void seek(Transform _target) {
        target = _target;
    }

    void Update() {
        if (target == null) {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        } 
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget() {
        GameObject effect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(gameObject);
        makeDamage(target);
    }

    void makeDamage(Transform target) {
        if (target != null) {
            Zombie1 zombie = target.GetComponent<Zombie1>();
            zombie.takeDamage(damage);
        }
    }
}
