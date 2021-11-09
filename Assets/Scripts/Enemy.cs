using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float moveTime = 3f;
    [SerializeField] float maxDistance = 9f;

    public int moveDir;
    public bool moving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            moveDir = Random.Range(0, 2);
            moving = true;
            StartCoroutine(MoveTimer());
            
        }
        else if (moveDir == 0)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            if (transform.position.x >= maxDistance)
            {
                StopAllCoroutines();
                moving = false;
            }
        }
        else if (moveDir == 1)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            if (transform.position.x <= -maxDistance)
            {
                StopAllCoroutines();
                moving = false;
            }
        }

    }

    IEnumerator MoveTimer()
    {
        yield return new WaitForSeconds(moveTime);
        moving = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Game>().IncreaseScore();
        Destroy(gameObject);
    }
}
