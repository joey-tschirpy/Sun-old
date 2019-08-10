using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectGridSettings", menuName = "Object Grid Settings")]
public class ObjectGridSettings : ScriptableObject
{
    [SerializeField]
    private float steps = 1;

    public float Steps => steps;
}
