using UnityEngine;

public class RecursiveFinder {
    public static T FromParent<T>(GameObject Target) {
        Transform par = Target.transform.parent;
        if (par == null) {
            return default(T);
        }

        T Trial = Target.transform.parent.GetComponent<T>();

        if (Trial != null) {
            return Trial;
        }

        if (Target.transform.parent != null) {
            return FromParent<T>(Target.transform.parent.gameObject);
        }

        return default(T);
    }
}
