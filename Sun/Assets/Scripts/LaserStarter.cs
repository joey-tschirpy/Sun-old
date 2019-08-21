using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LaserStarter : LaserObject
{
    public Laser[] lasers;

    private void Update()
    {
        SetLineRenderers();
    }

    protected override void SetLineRenderers()
    {

        for (int i = 0; i < laserRepresentations.Count; i++)
        {
            LineRenderer lr = laserRepresentations[i];
            GameObject go = lr.gameObject;
            RaycastHit hit;

            float maxDistance = 500f;

            if (Physics.Raycast(go.transform.position, go.transform.forward, out hit, maxDistance))
            {
                maxDistance = hit.distance;
            }

            lr.SetPosition(0, go.transform.position);
            lr.SetPosition(1, go.transform.position + go.transform.forward * maxDistance);
        }
    }
}
