using UnityEditor;
using UnityEngine;

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
            int exitPoints = 0;
            foreach (Transform child in laserStarter.gameObject.transform)
            {
                if (child.gameObject.CompareTag("ExitPoint"))
                {
                    exitPoints++;
                }
            }

            laserStarter.lasers = new Laser[exitPoints];

            for (int i = 0; i < exitPoints && i < prevLasers.Length; i++)
            {
                laserStarter.lasers[i] = new Laser(prevLasers[i]);
            }
        }

        prevLasers = (Laser[])laserStarter.lasers.Clone();

        SerializedProperty lasers = serializedObject.FindProperty("lasers");
        EditorGUILayout.PropertyField(lasers, true);

        //SerializedProperty power = serializedObject.FindProperty("powerRequirement");
        //EditorGUILayout.PropertyField(power);

        //SerializedProperty red = serializedObject.FindProperty("requireRed");
        //EditorGUILayout.PropertyField(red);

        //SerializedProperty green = serializedObject.FindProperty("requireGreen");
        //EditorGUILayout.PropertyField(green);

        //SerializedProperty blue = serializedObject.FindProperty("requireBlue");
        //EditorGUILayout.PropertyField(blue);

        serializedObject.ApplyModifiedProperties();
    }
}
