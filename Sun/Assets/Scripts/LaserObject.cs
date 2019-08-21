using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class LaserObject : MonoBehaviour
{
    [SerializeField]
    public Laser[] lasers;

    [SerializeField]
    protected int powerRequirement;

    [SerializeField]
    protected bool requireRed, requireGreen, requireBlue;

    protected int power = 0;

    protected List<LineRenderer> laserRepresentations = new List<LineRenderer>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            if (child.CompareTag("ExitPoint"))
            {
                var lr = child.GetComponent<LineRenderer>();
                lr.SetPosition(0, child.position);

                lr.material.color = lasers[i].Color;

                laserRepresentations.Add(lr);
            }
        }
    }

    abstract protected void SetLineRenderers();
}
