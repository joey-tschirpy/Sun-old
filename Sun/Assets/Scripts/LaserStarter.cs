using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LaserStarter : LaserObject
{
    public Laser[] lasers;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    laserRepresentation = GetComponent<LineRenderer>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    laserRepresentation.SetPosition(0, exitPoint.localPosition);

    //    if (Physics.Raycast(exitPoint.position, exitPoint.forward, out hit))
    //    {
    //        laserRepresentation.SetPosition(1, hit.point - exitPoint.position);
    //    }
    //    else
    //    {
    //        laserRepresentation.SetPosition(1, exitPoint.forward * 10);
    //    }
    //}
}

[CustomEditor(typeof(LaserStarter))]
[CanEditMultipleObjects]
public class LaserStartInspector : Editor
{
    private Laser[] prevLasers;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        LaserStarter laserStarter = (LaserStarter)target;

        if (prevLasers != null)
        {
            int exitPoints = laserStarter.gameObject.transform.childCount;
            laserStarter.lasers = new Laser[exitPoints];

            for (int i = 0; i < exitPoints && i < prevLasers.Length; i++)
            {
                laserStarter.lasers[i] = new Laser(prevLasers[i]);
            }
        }

        prevLasers = (Laser[])laserStarter.lasers.Clone();

        SerializedProperty lasers = serializedObject.FindProperty("lasers");
        EditorGUILayout.PropertyField(lasers, true);

        serializedObject.ApplyModifiedProperties();
        //EditorUtility.SetDirty(laserStarter);
    }
}
