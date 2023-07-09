using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickable : Pickable
{
    [SerializeField] private int minimumExpAmount = 50;
    [SerializeField] private int maximumExpAmount = 200;

    public ParticleSystem particles;

    private int expAmount;

    private void Start()
    {
        expAmount = Random.Range(minimumExpAmount, maximumExpAmount);
        var emission = particles.emission;
        emission.rateOverTime = expAmount / 50;
    }

    public override void OnPickUpEffect()
    {
        base.OnPickUpEffect();
        if (PlayerController.Instance.GetComponent<LevelController>())
        {
            PlayerController.Instance.GetComponent<LevelController>().GainExperience(expAmount);
        }
    }
}
