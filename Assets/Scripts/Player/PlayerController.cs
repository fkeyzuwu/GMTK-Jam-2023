using System;
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

    [Header("Sprite")]
    public SpriteRenderer spriteRenderer;

    [Header("Movement")]
    public float speed = 5.0f;

    [Header("Interactions")]
    [SerializeField] private float interactionRadius = 0.5f;

    public Rigidbody2D body { get; private set; }
    public BoxCollider2D boxCollider { get; private set; }
    public bool isWalking { get; private set; }

    private Vector2 moveDeltaInput;

    [Header("Health")]
    public PlayerHealth health;

    [Header("UpgradeSystem")]
    public UpgradeSystem upgradeSystem;
    public UpgradePicker upgradePicker;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        AudioManager.Instance.PlayGameMusic();
    }

    void Update()
    {
        moveDeltaInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (moveDeltaInput.x > 0)
            spriteRenderer.flipX = false;
        else if (moveDeltaInput.x < 0)
            spriteRenderer.flipX = true;
    }

    private void FixedUpdate()
    {
        isWalking = moveDeltaInput != Vector2.zero;
        body.velocity = new Vector2(moveDeltaInput.x, moveDeltaInput.y).normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<Pickable>())
        {
            collision.transform.GetComponent<Pickable>().PickUp();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    public void ActivateUpgradePicker()
    {
        upgradePicker.gameObject.SetActive(true);
        upgradePicker.GenerateUpgrades();
        Time.timeScale = 0f;
    }

    public void UpgradePicked(UpgradeData upgradePicked)
    {
        upgradeSystem.AddUpgrade(upgradePicked);
        upgradePicker.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
