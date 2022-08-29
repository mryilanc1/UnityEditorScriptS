
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;




public class Rename_Editor : EditorWindow
{

    static string location = "";
    static string localPath;
    private static string guide = "Select GameObjects";
    public  Transform[] objectArray;
    private static Vector2 _windowsMinSize = Vector2.one * 500f;
    private static Rect _helpRect = new Rect(0f, 0f, 400f, 100f);
    private static Rect _listRect = new Rect(Vector2.zero, _windowsMinSize);


    // Creates a new menu item 'Multiple Prefab/Multiple Prefab Creator  Window' in the main menu and create a shortcut.
    [MenuItem("Rename/Rename_Editor Window")]
    static void Init()
    {

        // Get existing open window or if none, make a new one:
        Rename_Editor window = (Rename_Editor)EditorWindow.GetWindow(typeof(Rename_Editor), true, "Rename_Editor");
    
        window.Show();

    }

    void OnGUI()
    {
        
     
        location = EditorGUILayout.TextField("Name:", location);
        if (Selection.activeGameObject != null)
        {
            GUI.backgroundColor = Color.green;

        }
        else
        {
            GUI.backgroundColor = Color.red;

        }
        if (GUI.Button(new Rect(50, 120, 200, 50), "Rename Button"))
        {
            if (Selection.activeGameObject != null)
            {
                Rename();
            }
            else
            {
                Debug.Log(("No selection in hierarchy !!!"));
                guide = "No selection in hierarchy !!!";
            }

        }
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Guide", EditorStyles.boldLabel);

        EditorGUILayout.LabelField(guide, GUILayout.Height(30));
    }



    [MenuItem("Rename/Rename Fast")]
     void Rename()
    {
        // Keep track of the currently selected GameObject(s)
        objectArray = Selection.transforms;
        objectArray =  objectArray.OrderBy(go => go.transform.GetSiblingIndex()).ToArray();

        int n = 0;
        // Loop through every GameObject in the array above
        foreach (Transform GameObject in objectArray)
        {


            GameObject.transform.name = location + n;
            n++;
            
            Debug.Log(GameObject.name);



        }


    }




}
