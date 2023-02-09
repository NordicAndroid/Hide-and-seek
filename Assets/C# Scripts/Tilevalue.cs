using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilevalue : MonoBehaviour
{
    [SerializeField] private float v�rdi;
    
    bool harGS = false;
    public Transform centerPoint;
    public LayerMask gsLayer;
    public Vector3 selvdetectRange;
    //public Vector3 andredetectRange;

    // Start is called before the first frame update
    void Start()
    {
        float gemmestederOver = Physics.OverlapBox(centerPoint.position, selvdetectRange, Quaternion.identity, gsLayer).Length;
        if (gemmestederOver >= 0)
        {
            //Debug.Log("has more " + gemmestederOver);
            v�rdi = gemmestederOver;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float gemmestederOver = Physics.OverlapBox(centerPoint.position, selvdetectRange, Quaternion.identity, gsLayer).Length;
        if (gemmestederOver >= 0)
        {
            //Debug.Log("has more " + gemmestederOver);
            v�rdi = gemmestederOver;
        }
    }

    void OnDrawGizmosSelected()
    {
        //Siden overlappet er en Box bruger jeg en Cube.
        Gizmos.DrawWireCube(centerPoint.position, selvdetectRange * 2.5f);
        
    }
}
