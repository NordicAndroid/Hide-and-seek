using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DørAnimaion : MonoBehaviour
{
    public Transform centerPoint;
    public LayerMask playerLayer;
    public Vector3 detectRange;
    public string animationName;
    public Transform Box;
    private BoxCollider colider;
    private bool Doorisopen = false;
    private float cooldown;

    private Animator pivotAni;

    // Start is called before the first frame update
    void Start()
    {
        pivotAni = GetComponent<Animator>();
        colider = Box.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        DoorAnimation();
    }

    void DoorAnimation()
    {
        int PlayersInRange = Physics.OverlapBox(centerPoint.position, detectRange, Quaternion.identity, playerLayer).Length;
        if (PlayersInRange > 0 && !Doorisopen && Input.GetKeyDown(KeyCode.E) && Time.time - cooldown > 0.5f)
        {
            colider.enabled = false;
            Debug.Log("not enabel");
            pivotAni.Play("DoorOpen",0,0.0f);
            Doorisopen = true;
            cooldown = Time.time;
        }
        else if (PlayersInRange == 0 && Doorisopen)
        {
            pivotAni.Play("DoorClose",0, 0.0f);
            Invoke("ReEnabel",1f);
            Doorisopen = false;
        }
    }

    void ReEnabel()
    {
        colider.enabled = true;
    }
    void OnDrawGizmosSelected()
    {
        //Siden overlappet er en cirkel bruger jeg en sphere.
        Gizmos.DrawWireCube(centerPoint.position, detectRange);
    }
}
