using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using static RandomMultipleRange;

public class ProjectileTrap : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    [SerializeField] private int minOffset = 5;
    [SerializeField] private int maxOffset = 10;

    private float lifetime;
    private Rigidbody2D body;
    private Vector3 targetPos;

    private bool isMagnetized = false;

    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
        lifetime = 0;
        targetPos = PlayerController.Instance.transform.position;
        float offsetX = RandomMultipleRange.RandomValueFromRanges(new Range(-maxOffset, -minOffset), new Range(minOffset, maxOffset));
        float offsetY = RandomMultipleRange.RandomValueFromRanges(new Range(-maxOffset, -minOffset), new Range(minOffset, maxOffset));
        Vector3 direction = (new Vector2(targetPos.x - transform.position.x + offsetX, targetPos.y - transform.position.y + offsetY)).normalized;
        transform.up = direction;
        body.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    public void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            Destroy(gameObject);

        if (isMagnetized)
        {
            targetPos = PlayerController.Instance.transform.position;
            Vector2 direction = new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y).normalized;
            body.velocity = new Vector2(direction.x, direction.y) * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("MagnetRadius"))
        {
            isMagnetized = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetRadius"))
        {
            isMagnetized = false;
        }
    }
}
