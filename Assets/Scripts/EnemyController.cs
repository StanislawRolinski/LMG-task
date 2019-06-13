using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float moveSpeed;
    private PlayerController player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
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
