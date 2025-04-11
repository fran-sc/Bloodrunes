using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    PushBack pushBack;

    Vector2 moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        pushBack = GetComponent<PushBack>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        SetAnimation();
    }

    void Move()
    {
        if (pushBack.IsPushed)
            return;

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);       
    }

    void SetAnimation()
    {
        anim.SetFloat("Move", moveDirection.magnitude);
        sr.flipX = moveDirection.x < 0;
    }

    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }
    
}
