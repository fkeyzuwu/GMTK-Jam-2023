using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Healthpack : Pickable
{
    public int healAmount = 100;

    [SerializeField] private float spawnExpandDuration = 0.75f;
    [SerializeField] private float rotationDegrees = 20f;
    [SerializeField] private float scaleSpeed = 30f;

    private bool finisheScaling = false;
    private void Start()
    {
        transform.localScale = Vector2.zero;
        LeanTween.scale(gameObject, Vector2.one, spawnExpandDuration)
            .setEaseInOutQuart()
            .setOnComplete(() => finisheScaling = true);

    }

    private void Update()
    {
        float rotateSine = Mathf.Sin(Time.time * 1.1f);
        float rotation = (rotateSine * Time.deltaTime * rotationDegrees);
        transform.Rotate(0, 0, rotation);
        if (finisheScaling)
        {
            float sineValue = (Mathf.Sin(Time.time * scaleSpeed) + 1) * 0.25f + 0.5f;
            transform.localScale = new Vector2(sineValue, sineValue);
        }
    }
    public override void OnPickUpEffect()
    {
        PlayerController.Instance.health.Heal(healAmount);
    }
}
