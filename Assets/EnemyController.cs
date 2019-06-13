using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float moveSpeed;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;
        transform.LookAt(player.transform.position);
    }
    private void FixedUpdate()
    {
        if (!player) return;
        rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
    }
}
