using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserObject : MonoBehaviour
{
    [SerializeField]
    protected Transform[] exitPoints;

    [SerializeField]
    protected Transform[] entryPoints;

    //protected List<Laser> lasers;
    //protected List<LineRenderer> laserRepresentations;
    //protected List<RaycastHit> hits;
    protected LineRenderer[] laserRepresentations;
    protected RaycastHit[] hits;

    protected void SetupLasers()
    {

    }
}
