using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 40.0f;
    private float horizontalInput;
    private bool isDead = false;
    private Rigidbody rb;

    [SerializeField] private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ResetPlayer()
    {
        Debug.Log("Resetando estado do jogador");
        isDead = false;
        
        if (rb != null)
        {
            // Para todas as forças físicas
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.Sleep(); // Força o Rigidbody a parar completamente
            
            // Reseta a rotação
            transform.rotation = Quaternion.identity;
            
            // Opcional: congela a posição por um momento para garantir
            rb.isKinematic = true;
            StartCoroutine(ReenablePhysics());
        }
    }

    private IEnumerator ReenablePhysics()
    {
        yield return new WaitForSeconds(0.1f);
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.WakeUp();
        }
    }

    private void OnEnable()
    {
        ResetPlayer();
    }

    void Update()
    {
        if (isDead) return;

        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.x > -5.5 && horizontalInput < 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime);
        } else if (transform.position.x < 5.5 && horizontalInput > 0) {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Numero") || 
            collision.gameObject.CompareTag("Obstacle") || 
            collision.gameObject.CompareTag("WrongAnswer"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        if (gameManager != null)
        {
            gameManager.GameOver();
            Debug.Log("Game Over chamado");
            
            // Opcional: Pare o movimento do carro imediatamente
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        else
        {
            Debug.LogError("GameManager não encontrado no PlayerController!");
        }
    }
}
