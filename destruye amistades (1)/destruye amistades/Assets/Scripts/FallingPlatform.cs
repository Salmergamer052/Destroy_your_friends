using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 1.5f;
    private float destroyDelay = 3f;

    [SerializeField] private Rigidbody2D rb;

// Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
    StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
