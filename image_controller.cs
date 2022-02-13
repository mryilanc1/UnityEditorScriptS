

using UnityEngine;
using UnityEditor;
using UnityEngine.UI;




public class image_controller : EditorWindow
    {

        static string location = "";
        static string localPath;
        private static string guide = "Select GameObjects";
        public static GameObject[] objectArray;
    private static Vector2 _windowsMinSize = Vector2.one * 500f;
    private static Rect _helpRect = new Rect(0f, 0f, 400f, 100f);
    private static Rect _listRect = new Rect(Vector2.zero, _windowsMinSize);

    // Creates a new menu item 'Multiple Prefab/Multiple Prefab Creator  Window' in the main menu and create a shortcut.
    [MenuItem("image_controller/image_controller Window")]
        static void Init()
        {

        // Get existing open window or if none, make a new one:
        image_controller window = (image_controller) EditorWindow.GetWindow(typeof(image_controller),true, "Image Controller");
          
            window.Show();
            
        }
        
        void OnGUI()
        {

      

        location = EditorGUILayout.TextField("Folder name:", location);
            if (Selection.activeGameObject != null)
            {
                GUI.backgroundColor= Color.green;
                
            }
            else
            {
                GUI.backgroundColor= Color.red;
                
            }
            if (GUI.Button(new Rect(50, 120, 200, 50), "Create Prefabs"))
            {
                if (Selection.activeGameObject != null)
                {
                ControlImages();
                   
                }
                else
                {
                    
                    Debug.Log(("No selection in hierarchy !!!"));
                    guide = "No selection in hierarchy !!!";
                }
                
            }
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Guide", EditorStyles.boldLabel);
           
            EditorGUILayout.LabelField(guide,GUILayout.Height(30));
        }
        
        
        
        [MenuItem("image_controller/ControlImages")]
         static void ControlImages()
        {
            // Keep track of the currently selected GameObject(s)
            objectArray = Selection.gameObjects;

            // Loop through every GameObject in the array above
            foreach (GameObject Tileobject in objectArray)
         {
            

            foreach (var item in objectArray)
            {
                if (item.name == Tileobject.name)
                    continue;


                if (item.transform.GetChild(0).GetComponent<Image>().sprite.name == Tileobject.transform.GetChild(0).GetComponent<Image>().sprite.name)
                {


                   // Debug.Log(item.GetComponentInChildren<Image>().sprite.name);
                    Debug.Log("obj ismi: "+ item.name +"  /*/  "+  item.transform.GetChild(0).GetComponent<Image>().sprite.name + " === obje ismi:" + Tileobject.name + "  /*/  " + Tileobject.transform.GetChild(0).GetComponent<Image>().sprite.name);
                }
            }
               
         }


        }
         

      
     
    }
