using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed, range, x, y, z, rotationSpeed;
    public Quaternion rotation, eularAngles, currentRotation;
    public Vector3 currentEularAngles;
    public Transform target;

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void Update()
    {
        EnemyDetector();
    }
    public void EnemyDetector()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        if (dist <=range)
        {
            Debug.Log("EnemyDetected");
            LookRotation();
        }
    }

    void LookRotation()
    {
        Vector3 relativePos = transform.position - target.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
