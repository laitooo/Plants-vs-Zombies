using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public GameObject impactEffect;
    public float speed = 1f;

    void Start() {
        
    }

    public void seek(Transform _target) {
        target = _target;
    }

    void Update() {
        if (target == null) {
            destroyObject();
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
        Destroy(target.gameObject);
        destroyObject();
    }

    void destroyObject() {
        Destroy(gameObject);
    }
}
