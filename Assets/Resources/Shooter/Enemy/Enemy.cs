using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private Animator animator;

    [SerializeField] private GameObject boom;
    [SerializeField] private float speed;
    [SerializeField] private float health;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (target != null)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.position = newPosition;
        }
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    public void Dead()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        animator.Play("Dead");
        boom.SetActive(true);
    }

    public void DestroyObject()
    {
        AudioManager.Instance.AddScore();
        Destroy(gameObject);
    }
}
