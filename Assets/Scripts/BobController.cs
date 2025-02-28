using UnityEngine;

public class BobController : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rb;
    Animator anim;
    Controls controls;
    Vector2 movement;

    void Awake()
    {
        controls = new Controls();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        movement = controls.Player.Move.ReadValue<Vector2>();
        anim.SetFloat("x", movement.x);
        anim.SetFloat("y", movement.y);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
