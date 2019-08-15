using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserStarter : MonoBehaviour
{
    [SerializeField]
    private Transform exitPoint;

    private Laser laser;
    private LineRenderer laserRepresentation;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        laserRepresentation = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(exitPoint.position, exitPoint.forward, Color.blue);

        laserRepresentation.SetPosition(0, exitPoint.localPosition);

        if (Physics.Raycast(exitPoint.position, exitPoint.forward, out hit))
        {
            laserRepresentation.SetPosition(1, hit.point - exitPoint.position);
        }
        else
        {
            laserRepresentation.SetPosition(1, exitPoint.forward * 10);
        }
    }
}
