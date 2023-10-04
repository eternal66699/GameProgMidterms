using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        LookRotation();
    }

    void EnemyMovement()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.player.position, step);
    }

    void LookRotation()
    {
        Vector3 relativePos = GameManager.Instance.player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
