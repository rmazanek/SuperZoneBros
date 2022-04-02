using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        gameObject.transform.localScale = new Vector2(1f, 1f);
    }

    public void SetHealth(float pct) 
    {
        gameObject.transform.localScale = new Vector2(pct, 1f);
    }
}
