using UnityEngine;
using static RandomMultipleRange;

public class HealthDart : MonoBehaviour
{
    [SerializeField] private int heal;
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
            Vector2 lerpedDirection = Vector2.Lerp(body.velocity.normalized, directionToPlayer, Time.deltaTime * 5);
            body.velocity = lerpedDirection * speed;
            transform.up = lerpedDirection;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Heal(heal);
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
