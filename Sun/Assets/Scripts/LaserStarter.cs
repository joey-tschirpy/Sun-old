using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LaserStarter : LaserObject
{
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
            Material mat = go.GetComponent<Renderer>().material;
            RaycastHit hit;

            float maxDistance = 500f;
            if (Physics.SphereCast(go.transform.position, lr.startWidth, go.transform.forward, out hit, maxDistance))
            {
                maxDistance = hit.distance;
            }

            lr.SetPosition(0, go.transform.position);
            lr.SetPosition(1, go.transform.position + go.transform.forward * maxDistance);
        }
    }
}
