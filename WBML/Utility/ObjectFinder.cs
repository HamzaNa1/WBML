using UnityEngine;

namespace WBML.Utility;

public static class ObjectFinder
{
    public static GameObject Find(string name)
    {
        GameObject[] objects = Object.FindObjectsOfType<GameObject>(true);
        
        foreach (GameObject gameObject in objects)
        {
            if (gameObject.name == name)
            {
                return gameObject;
            }
        }

        return null;
    }
}