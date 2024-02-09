using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LauncherBehaviour : MonoBehaviour
{
    public BulletBehaviour BulletPrefab;

    private Vector2 _direction;
    private bool _cooldown;

    void Start()
    {
        _cooldown = false;
    }

    void Update()
    {
        if(_cooldown == false)
        {
            StartCoroutine(fireBullet());
        }
    }

    IEnumerator fireBullet()
    {
        _cooldown = true;
        BulletBehaviour firedBullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        _direction = GenerateRandomDirection();
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
        firedBullet.transform.rotation = rotation;
        firedBullet.FireBullet(_direction, GameManager.Instance.GetSpeedMulti());
        yield return new WaitForSeconds(Random.Range(2f, 3.5f) * GameManager.Instance.GetCooldownMulti());
        _cooldown = false;
    }

    private Vector2 GenerateRandomDirection()
    {
        if (transform.position.x > 14 || transform.position.x < -14)
        {
            return (new Vector3(0, Random.Range(-7.0f, 7.0f), 0) - transform.position).normalized;
        }
        else if (transform.position.y > 7 || transform.position.y < -7)
        {
            return (new Vector3(Random.Range(-13.0f, 13.0f), 0, 0) - transform.position).normalized;
        }
        else return new Vector2(0, 0);
    }
}
