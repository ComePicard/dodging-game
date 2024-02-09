using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    public Animator Anim;
    public SpriteRenderer Sprite;
    public CharacterData Character;

    private Rigidbody2D _rb;
    private Vector3 _targetPosition;
    private bool _isDead;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _isDead = false;
    }

    void Update()
    {
        if (_rb.velocity.x >= 0)
        {
            Sprite.flipX = false;
        }
        else Sprite.flipX = true;

        //Debug.Log((int)(_rb.position.x * 100));
        CheckDestinationReached();
        if (Input.GetMouseButtonDown(0) && !_isDead)
        {
            _rb.velocity = Vector3.zero;
            _targetPosition = GetMouseClickPosition();
            _targetPosition.z = 0;
            MoveToPosition(_targetPosition);
        }
        if (Input.GetKey(KeyCode.S) && !_isDead)
        {
            _rb.velocity = Vector3.zero;
            Anim.SetBool("running", false);
        }
    }

    Vector3 GetMouseClickPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0));
    }

    public void MoveToPosition(Vector3 newTargetPosition)
    {
        Anim.SetBool("running", true);
        Vector2 direction = (newTargetPosition - transform.position).normalized;
        _rb.AddForce(direction * Character.Speed);
    }

    private void CheckDestinationReached()
    {
        float dest_x_min = _targetPosition.x - 0.1f;
        float dest_x_max = _targetPosition.x + 0.1f;
        float dest_y_min = _targetPosition.y - 0.1f;
        float dest_y_max = _targetPosition.y + 0.1f;
        if (_rb.position.x >= dest_x_min && _rb.position.x <= dest_x_max && _rb.position.y >= dest_y_min && _rb.position.y <= dest_y_max)
        {
            _rb.velocity = Vector3.zero;
            Anim.SetBool("running", false);
        }
    }

    public void Die()
    {
        _isDead = true;
        _rb.velocity = Vector2.zero;
        Anim.SetTrigger("die");
    }
}
