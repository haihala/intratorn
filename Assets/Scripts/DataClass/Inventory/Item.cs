using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Item : ScriptableObject {
    public string Name;
    public float Weight;

    public string Inspect() {
        // Maybe think about localization at some point.
        string ret = "";
        foreach (FieldInfo field in this.GetType().GetFields()) {
            System.Type type = field.GetValue(this).GetType();
            if (
                type != typeof(GameObject) &&
                !type.IsGenericType
                ) 
             {  // Object is a model, models don't need no inspection.
                ret += field.Name.Replace("_", " ")
                 + ": " 
                 + StringUtils.Substring_until(field.GetValue(this).ToString(), '(') 
                 + "\n";
            }
        }
        return ret;
    }
}
