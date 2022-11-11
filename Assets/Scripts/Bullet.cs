using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 8f;
    public GameObject impactEffect;

  
    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }


        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            //HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy _enemy = collision.gameObject.GetComponent<Enemy>();
            _enemy.ApplyDamage(5);
            Destroy(gameObject);
        }
    }

    /*void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(gameObject);
    }
    */
}