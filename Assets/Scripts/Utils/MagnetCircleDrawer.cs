using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetFieldDrawer : MonoBehaviour
{
    [SerializeField] SpriteRenderer magnetField;
    [SerializeField] new CircleCollider2D collider;
    public void UpgradeMagnetField()
    {
        collider.enabled = true;
        collider.radius += 1;
        magnetField.enabled = true;
        magnetField.transform.localScale = new Vector3(collider.radius * 2, collider.radius * 2, collider.radius * 2);
    }
}
