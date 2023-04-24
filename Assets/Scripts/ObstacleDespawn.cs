using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDespawn : MonoBehaviour
{

    Renderer myRenderer;

    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (!myRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
