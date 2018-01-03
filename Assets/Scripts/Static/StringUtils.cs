using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class StringUtils {
	public static string Substring_until(string origin, char target) {
		int index = origin.IndexOf(target);
		if (index > 0) {
			return origin.Substring(0, index);
		}
		return origin;
	}

	public static string Fname_of_asset(ScriptableObject asset) {
		string path = AssetDatabase.GetAssetPath(asset);
		path = path.Substring(path.LastIndexOf('/')+1);
		return Substring_until(path, '.');
	}
}
