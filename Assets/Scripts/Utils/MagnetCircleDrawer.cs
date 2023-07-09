using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetFieldDrawer : MonoBehaviour
{
    [SerializeField] SpriteRenderer magnetField;
    [SerializeField] new CircleCollider2D collider;
    public void UpgradeMagnetField(float increaseRadius)
    {
        collider.enabled = true;
        collider.radius += increaseRadius;
        magnetField.enabled = true;
        magnetField.transform.localScale = new Vector3(collider.radius * 2, collider.radius * 2, collider.radius * 2);
    }
}
