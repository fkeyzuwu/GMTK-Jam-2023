using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{

    public void PickUp()
    {
        // TODO: LeanTween the game object
        OnPickUpEffect();
        Destroy(gameObject);
    }
    
    public virtual void OnPickUpEffect()
    {
        Debug.Log("Picked up " + gameObject.tag);
    }
}
