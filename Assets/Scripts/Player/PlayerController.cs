using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float normalSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashTime;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    Controls controls;
    Vector2 movement;
    float speed;

    public bool IsLookingRight {get; private set;} = true;
    public bool IsAttacking {get; private set;} = false;

    void Awake()
    {
        controls = new Controls();
        controls.Player.Attack.performed += _ => Attack();
        controls.Player.Dash.performed += _ => Dash();

        speed = normalSpeed;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        ReadInput();        
        SetAnimation();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void ReadInput()
    {
        movement = controls.Player.Move.ReadValue<Vector2>();

    }

    void SetAnimation()
    {
        anim.SetFloat("move", movement.magnitude);
        if (movement.magnitude > 0)
        {
            sr.flipX = movement.x < 0;
            IsLookingRight = !sr.flipX;
        }
    }

    void Attack()
    {
        anim.SetTrigger("attack");
    }

    void Dash()
    {
        speed = dashSpeed;
        Invoke("ResetSpeed", dashTime);
    }

    void ResetSpeed()
    {
        speed = normalSpeed;
    }

    void OnAttackStart()
    {
        IsAttacking = true;
    }
    void OnAttackEnd()
    {
        IsAttacking = false;
    }
}
