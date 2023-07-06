//// This Code Checks if Pivot is at geometric center
/// mr.yilanci



using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeshPivotChecker : EditorWindow
{
    public List<GameObject> PivotProblemList = new List<GameObject>();
    private Vector2 scrollPosition;
    [MenuItem("Araclar/Mesh Pivot Checker")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MeshPivotChecker));
    }
    private float threshold = 8000f;

    private void OnGUI()
    {
        GUILayout.Label("Mesh Pivot Checker", EditorStyles.boldLabel);
        threshold = EditorGUILayout.FloatField("Threshold", threshold);
        if (GUILayout.Button("Check Pivot for All Objects"))
        {
            PivotProblemList.Clear();
            GameObject[] objects = FindObjectsOfType<GameObject>();
            foreach (GameObject obj in objects)
            {
                MeshFilter meshFilter = obj.GetComponent<MeshFilter>();
                
                Bounds bounds = obj.GetComponent<MeshRenderer>().bounds;
                Vector3 geometricCenter = bounds.center;
                Vector3 size = bounds.size;
                
                if (meshFilter != null && meshFilter.sharedMesh != null ) 
                {
                    Vector3 pivot = obj.transform.position;

                    float distanceX = Mathf.Abs(pivot.x - geometricCenter.x);
                    float distanceY = Mathf.Abs(pivot.y - geometricCenter.y);
                    float distanceZ = Mathf.Abs(pivot.z - geometricCenter.z);

                    if (distanceX > threshold || distanceY > threshold || distanceZ > threshold)
                    { 
                        Debug.Log(  $"Parent::{obj.transform.parent.name } --- sorunlu:  {obj.name}  Mesh pivot is not at the geometric center.");
                       PivotProblemList.Add(obj);
                        
                    }
                }
            }
        }
        
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        ScriptableObject scriptableObj = this;
        SerializedObject serialObj = new SerializedObject (scriptableObj);
        SerializedProperty serialProp = serialObj.FindProperty ("PivotProblemList");
        EditorGUILayout.PropertyField (serialProp, true);
        serialObj.ApplyModifiedProperties ();
        
        EditorGUILayout.EndScrollView();
        
    }

   
}
