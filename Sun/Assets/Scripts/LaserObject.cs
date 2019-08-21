using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class LaserObject : MonoBehaviour
{
    [SerializeField]
    protected int powerRequirement;

    [SerializeField]
    protected bool requireRed, requireGreen, requireBlue;

    protected int power = 0;

    protected List<LineRenderer> laserRepresentations = new List<LineRenderer>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("ExitPoint"))
            {
                var lr = child.GetComponent<LineRenderer>();
                lr.SetPosition(0, child.position);

                laserRepresentations.Add(lr);
            }
        }
    }

    abstract protected void SetLineRenderers();
}
