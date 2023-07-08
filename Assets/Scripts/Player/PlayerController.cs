using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(
    typeof(BoxCollider2D), 
    typeof(Rigidbody2D)
)]
public class PlayerController : MonoBehaviour
{

    #region Singleton
    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [Header("Movement")]
    [SerializeField] private float speed = 5.0f;

    public Rigidbody2D body { get; private set; }
    public BoxCollider2D boxCollider { get; private set; }
    public bool isWalking { get; private set; }

    private Vector2 moveDeltaInput;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        moveDeltaInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (moveDeltaInput.x > 0)
            transform.localScale = new Vector2(1, transform.localScale.y);
        else if (moveDeltaInput.x < 0)
            transform.localScale = new Vector2(-1, transform.localScale.y);
    }

    private void FixedUpdate()
    {
        isWalking = moveDeltaInput != Vector2.zero;
        body.velocity = new Vector2(moveDeltaInput.x, moveDeltaInput.y).normalized * speed;
    }

}
