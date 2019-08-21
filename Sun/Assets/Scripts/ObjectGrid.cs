using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ObjectGrid : MonoBehaviour
{
    [SerializeField]
    private ObjectGridSettings settings;

#if UNITY_EDITOR
    void LateUpdate()
    {
        if (!Application.isPlaying)
        {
            float x = Mathf.Round(transform.position.x / settings.Steps) * settings.Steps;
            float y = Mathf.Round(transform.position.y / settings.Steps) * settings.Steps;
            float z = Mathf.Round(transform.position.z / settings.Steps) * settings.Steps;

            transform.position = new Vector3(x, y, z);
        }
    }
#endif
}
