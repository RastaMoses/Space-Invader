using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float lifeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
