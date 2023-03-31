using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDespawn : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
