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
        Vector3 h�jre = Camera.main.transform.right;
        fremad.y = 0;
        h�jre.y = 0;
        fremad = fremad.normalized;
        h�jre = h�jre.normalized;

        //Lav Vector Input der er Retnings-relative
        Vector3 fremadRelativtVeticaltInput = playerVerticalInput * fremad;
        Vector3 h�jreRelativtHorisontaltInput = playerHorizontalInput * h�jre;

        //Lav en resulterende bev�gelsesvector der er Kamera relativ
        Vector3 kamereRelativBev�gelse = fremadRelativtVeticaltInput + h�jreRelativtHorisontaltInput+ _velocity;

        //Bev�gelse
        Control.Move(kamereRelativBev�gelse * _speed * Time.deltaTime);
        //transform.Translate(kamereRelativBev�gelse * speed * Time.deltaTime, Space.World);
        //rb.MovePosition(kamereRelativBev�gelse * speed * Time.deltaTime);
    }
}
