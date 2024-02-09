using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletBehaviour : MonoBehaviour
{
    public BulletData Bullet;

    private Rigidbody2D _rb;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(Vector3 direction, float speedMulti)
    {
        _rb.AddForce(direction * Bullet.Speed * speedMulti);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("WorldEnd"))
        {
            Destroy(gameObject);
        }

        if (collider.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
