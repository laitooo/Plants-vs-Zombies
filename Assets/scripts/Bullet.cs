using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public int damage = 5;
    public float speed = 1f;
    public bool canSlowZombie = false;

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
        Destroy(gameObject);
        makeDamage(target);
        // TODO: change sound depending on zombie type
        AudioManager.instance.play("HitNormal");
    }

    void makeDamage(Transform target) {
        if (target != null) {
            Zombie zombie = target.GetComponent<Zombie>();
            if (canSlowZombie) {
                zombie.slowAndDamge(damage, 2f);
            } else {
                zombie.takeDamage(damage);
            }
        }
    }
}
