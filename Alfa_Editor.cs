
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class Alfa_Editor : EditorWindow
{




    /// <summary>
    [Range(0.1f,1f)]
   static float sizeMultiplier;


    /// </summary>

    string guide;
    static GameObject ImageObject = null;
    static string hata = "Bildirici";


    [MenuItem("Alpha/AlphaEditor _%#&I")]
    static void ramo()
    {

        Alfa_Editor window = (Alfa_Editor)EditorWindow.GetWindow(typeof(Alfa_Editor), true, "Alpha Editor Window");

        window.Show();

    }

    void OnGUI()
    {

        sizeMultiplier = EditorGUILayout.Slider(sizeMultiplier, 0.1f, 1.0f);


        ImageObject = (GameObject)EditorGUI.ObjectField(new Rect(3, 35, position.width - 6, 20), "Find Dependency", ImageObject, typeof(GameObject));
       
        if (ImageObject !=null)
            if (GUI.Button(new Rect(3, 60, position.width - 6, 20), "Check Dependencies"))



                Selection.objects = EditorUtility.CollectDependencies(new GameObject[] { ImageObject });
        if (GUI.Button(new Rect(3, 105, position.width  -6, 20), "Alpha 0"))
        {
            Alpha_0();

        }

        if (GUI.Button(new Rect(3, 135, position.width -6, 20), "Alpha Slider"))
        {
            Alpha_100();

        }

        if (GUI.Button(new Rect(3, 165, position.width -6, 20), "Alpha 255"))
        {
            Alpha_255();

        }

        else if (ImageObject == null)
                EditorGUI.LabelField(new Rect(0, 65, position.width - 6, 20), "Missing:"+  "  Select an object first");

        
        EditorGUI.LabelField(new Rect(3, 200, position.width - 6, 20), hata, EditorStyles.boldLabel);

        EditorGUI.LabelField(new Rect(3, 265, position.width - 6, 40), "Kodun Çalışması için \nInpector açık olmalı", EditorStyles.boldLabel);

       
    }



    [MenuItem("Alpha/Alpha_0 _&v")]
    static void Alpha_0()

    {
        if (ImageObject != null && ImageObject.GetComponent<Image>() != null)
        {
            Debug.Log("alpha bir foreach");

            var a_color_0 = ImageObject.GetComponent<Image>().color;

            a_color_0.a = 0;
            ImageObject.GetComponent<Image>().color = a_color_0;

            hata = "Alpha = 0";

            Debug.Log("alpha bir color");
        }
        else
        { 
        Debug.Log("İmage seç Lapara "); 
        hata = "İmage seç, Lapara!!!";
        }
            

    }
   

    [MenuItem("Alpha/Alpha_100 _&b")]
    static void Alpha_100()
    {
        if ( ImageObject != null && ImageObject.GetComponent<Image>() != null)
    
        {

            var a_color_100 = ImageObject.GetComponent<Image>().color;
            a_color_100.a = sizeMultiplier;
            ImageObject.GetComponent<Image>().color = a_color_100;
            hata = "Yeni Alpha Değeri : " + sizeMultiplier; 
        }

        else
        { Debug.Log("İmage seç, Lapara ");
            hata = "İmage seç, Lapara";
        }


    }


    
    

    [MenuItem("Alpha/Alpha_255 _&n")]
    static void Alpha_255()
    {
        if (ImageObject != null && ImageObject.GetComponent<Image>() != null)
        {
            var a_color_255 = ImageObject.GetComponent<Image>().color;
            a_color_255.a = 1f;
            ImageObject.GetComponent<Image>().color = a_color_255;
            hata = "Alpha = 255";
        }
        else
        { Debug.Log("İmage seç Lapara ");
            hata = "Laa, İmage seç, Lapara";
        }

    }



}
