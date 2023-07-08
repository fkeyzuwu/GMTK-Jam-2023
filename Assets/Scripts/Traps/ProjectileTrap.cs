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
        body.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        transform.up = direction;
        speed -= Time.deltaTime / 3;
    }

    public void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            Destroy(gameObject);

        if (isMagnetized)
        {
            targetPos = PlayerController.Instance.transform.position;
            Vector2 directionToPlayer = new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y).normalized;
            Vector2 directionNow = body.velocity.normalized;
            float angleToPlayer =  Mathf.Atan(directionToPlayer.y / directionToPlayer.x) % (2*Mathf.PI);
            float angleNow = Mathf.Atan(directionNow.y /directionNow.x) % (2 * Mathf.PI);
            float p = 0.04f;

            float angleTransition = angleNow + p * (angleToPlayer - angleNow);
            Vector2 directionTransition = new Vector2(Mathf.Cos(angleTransition), Mathf.Sin(angleTransition));

            if (transform.position.x <= targetPos.x)
            {
                body.velocity = directionTransition * speed;
                transform.up = directionTransition;
            }
            else
            {
                body.velocity = -directionTransition * speed;
                transform.up = -directionTransition;
            }
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
