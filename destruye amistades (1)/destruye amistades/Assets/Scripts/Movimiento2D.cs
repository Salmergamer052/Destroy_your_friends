using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2D : MonoBehaviour
{
    public CONTROLS controles;

    public Vector2 direccion;

    public Rigidbody2D rb2d;
    public float velocidadMovimiento;
    public bool mirandoDerecha = true;
    public float fuerzaSalto;
    public LayerMask queesSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    public bool enSuelo;

    private void Awake()
    {
        controles = new();
    }

    private void OnEnable()
    {
        controles.Enable();
        controles.Movimiento.Saltar.started += _ => Saltar();
    }

    private void OnDisable()
    {
        controles.Disable();
    }

    private void Update()
    {
        direccion = controles.Movimiento.Mover.ReadValue<Vector2>();

        AjustarRotacion(direccion.x);
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queesSuelo);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(direccion.x * velocidadMovimiento, rb2d.velocity.y);
    }

    private void AjustarRotacion(float direccionx)
    {
        if (direccionx > 0 && !mirandoDerecha)
        {
            Girar();
        }else if (direccionx < 0 && mirandoDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void Saltar()
    {
        if (enSuelo)
        {
            rb2d.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }
        
        Debug.Log("saltando");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
