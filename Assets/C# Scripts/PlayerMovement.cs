using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float _speed;
    public CharacterController Control;

    public float _gravity;
    [SerializeField] private float _gravityMultiplier = 3.0f;
    private Vector3 _velocity;

    private void Update()
    {
        MovePlayerRelativeToKamera();
        Gravity();
    }

    void Gravity()
    {
        _velocity.y = _gravity * _gravityMultiplier * Time.deltaTime * -1;
    }
    void MovePlayerRelativeToKamera()
    {
        //Player Input
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        //Hent Kamera Normaliserede Retningsbestemt Vectorer
        Vector3 fremad = Camera.main.transform.forward;
        Vector3 højre = Camera.main.transform.right;
        fremad.y = 0;
        højre.y = 0;
        fremad = fremad.normalized;
        højre = højre.normalized;

        //Lav Vector Input der er Retnings-relative
        Vector3 fremadRelativtVeticaltInput = playerVerticalInput * fremad;
        Vector3 højreRelativtHorisontaltInput = playerHorizontalInput * højre;

        //Lav en resulterende bevægelsesvector der er Kamera relativ
        Vector3 kamereRelativBevægelse = fremadRelativtVeticaltInput + højreRelativtHorisontaltInput+ _velocity;

        //Bevægelse
        Control.Move(kamereRelativBevægelse * _speed * Time.deltaTime);
        //transform.Translate(kamereRelativBevægelse * speed * Time.deltaTime, Space.World);
        //rb.MovePosition(kamereRelativBevægelse * speed * Time.deltaTime);
    }
}
