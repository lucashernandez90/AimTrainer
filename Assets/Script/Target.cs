using UnityEngine;

public class Target : MonoBehaviour
{
    private bool isHit = false;
    private Rigidbody rb;
    private float force = 5f; // For�a para empurrar o alvo para cima

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchTarget();
    }

    private void LaunchTarget()
    {
        rb.linearVelocity = Vector3.zero; // Reseta velocidade
        rb.AddForce(Vector3.up * force, ForceMode.Impulse); // Empurra para cima
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            LaunchTarget(); // Relan�a o alvo ao tocar o ch�o
        }
    }

    public void Hit()
    {
        if (isHit) return;
        isHit = true;

        Debug.Log("Alvo atingido!");
        ScoreManager.Instance.AddScore(10);

        transform.position = TargetBounds.Instance.GetRandomPosition();
        LaunchTarget(); // Relan�a o alvo para o ar
        isHit = false;
    }
}
