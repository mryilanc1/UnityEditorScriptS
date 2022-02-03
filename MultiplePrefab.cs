

// This script creates multiple prefab by Multiple Prefab Creator  .
// Use it to create Prefab or prefabs  from the selected GameObject(s).
// It will be placed in you want which folder.... you have to write it's name to "Folder name" at Multiple Prefab Creator Window
// if you didn't write name of folder , Multiple Prefab Creator creates your prefabs in Main Assets Folder.
// if you did write an uncreated folder name , Multiple Prefab Creator won't create prefabs
// if you want create prefabs at "child folder of a folder" , you have to write this  "/"  between two folder  
// example Editor/Prefab/Buildings
//**
//if you selected gameobjects and you  want to shortcut for create to prefabs
// you can use Ctrl+Shift+Alt+P .... This shortcut  direct create prefabs
// you can open Multiple Prefab Creator window , you have to click Multiple Prefab after click Multiple Prefab Creator Window at Menu
// if you can want to  shortcut for open Multiple Prefab Creator window  , you can use Ctrl+Shift+Alt+O... 

using UnityEngine;
using UnityEditor;




public class MultiplePrefab :EditorWindow
    {

        static string location = "";
        static string localPath;
        private static string guide = "Select GameObjects";
        
        // Creates a new menu item 'Multiple Prefab/Multiple Prefab Creator  Window' in the main menu and create a shortcut.
        [MenuItem("Multiple Prefab/Multiple Prefab Creator  Window _%#&o")]
        static void Init()
        {   
            
            // Get existing open window or if none, make a new one:
            MultiplePrefab window = (MultiplePrefab) EditorWindow.GetWindow(typeof(MultiplePrefab),true,"Multiple Prefab Creator Window");
          
            window.Show();
            
        }
        
        void OnGUI()
        {
            
            
            EditorGUILayout.LabelField("Location to save", EditorStyles.boldLabel);
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
                    CreatePrefab();
                   
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
        
        
        
        [MenuItem("Multiple Prefab/Create Prefabs _%#&p")]
         static void CreatePrefab()
        {
            // Keep track of the currently selected GameObject(s)
            GameObject[] objectArray = Selection.gameObjects;

            // Loop through every GameObject in the array above
            foreach (GameObject gameObject in objectArray)
            {
                // Set the path as within the Assets folder,
                // and name it as the GameObject's name with the .Prefab format
                 localPath = "Assets/" +location +"/" + gameObject.name + ".prefab";

                // Make sure the file name is unique, in case an existing Prefab has the same name.

                if (localPath == AssetDatabase.GenerateUniqueAssetPath(localPath) || location == "")
                {
                   
                    localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
                    // Create the new Prefab.
                    PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, localPath, InteractionMode.UserAction);
                    Debug.Log("Prefabs created ....  Location of prefabs :"+localPath);
                    guide = "Prefabs created ....  Location of prefabs :\n"+localPath;
                }
                else
                {
                    Debug.Log(("The folder's name is wrong... There is no such folder"));
                    guide = "The folder's name is wrong... There is no such folder";
                    break;
                    
                }

                

              
                
                
            }
        }
         

        // Disable the menu item if no selection is in place.
        [MenuItem("Multiple Prefab/Create Prefabs _%#&p" , true)]
        static bool ValidateCreatePrefab()
        {
            return Selection.activeGameObject != null && !EditorUtility.IsPersistent(Selection.activeGameObject);
        }
        
     
    }
