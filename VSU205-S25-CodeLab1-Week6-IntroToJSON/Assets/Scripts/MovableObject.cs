using System;
using System.IO;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    string dir = "/Data/";
    string fileName;

    #region Unity Event Functions
    
    void Awake()
    {
        fileName = name + ".json";
        
        transform.position = Util.GetVector3FromFile(dir, name + ".json");
        
        // string dataPath = Application.dataPath + "/Data/";
        //
        // if (!Directory.Exists(dataPath))
        // {
        //     Directory.CreateDirectory(dataPath);
        // }
        //
        // fileName = dataPath + name + ".json";
        //
        // if (File.Exists(fileName))
        // {
        //     string fileContent = File.ReadAllText(fileName);
        //     
        //     transform.position = JsonUtility.FromJson<Vector3>(fileContent);
        //     
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        
        Debug.Log(mousePosition);
        
        transform.position = mousePosition;
    }

    Vector3 GetMouseWorldPosition()
    {
        //Get the X and Y of the mouse on the screen
        Vector3 mousePosition = Input.mousePosition;

        //considering where this gameObject is in worldspace
        //get the x position in screen space
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        
        Debug.Log("Z in Screen Pixels:" + mousePosition.z);
        
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        Debug.Log("X in Screen Pixels:" + mousePosition.x);
        
        return mousePosition;
    }

    void OnApplicationQuit()
    {
        //string jsonPos = JsonUtility.ToJson(transform.position, true);
        //File.WriteAllText(filePath, jsonPos); 
        
        Util.SaveVect3ToFileAsJson(dir, fileName, transform.position);
    }
    
    #endregion
}
