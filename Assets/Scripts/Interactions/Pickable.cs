using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [Range(0.1f, 1f)]
    [SerializeField] private float tweenDuration = 0.2f;

    public void PickUp()
    {
        LeanTween.scale(gameObject, Vector3.zero, tweenDuration);
        LeanTween.move(gameObject, PlayerController.Instance.transform, tweenDuration).setOnComplete(() => {
            OnPickUpEffect();
            Destroy(gameObject);
        });
    }
    
    public virtual void OnPickUpEffect()
    {
        Debug.Log("Picked up " + gameObject.tag);
    }
}
