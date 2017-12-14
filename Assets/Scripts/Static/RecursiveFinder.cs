using UnityEngine;

public static class RecursiveFinder {
    public static T FromParent<T>(GameObject Target) {
        Transform par = Target.transform.parent;
        if (par == null) {
            T Comp = Target.GetComponent<T>();
            if (Comp != null) {
                return Comp;
            } else {
                return default(T);
            }
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