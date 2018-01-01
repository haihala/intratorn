using System.Collections;
using System.Collections.Generic;

public static class StringUtils {
	public static string Substring_until(string origin, char target) {
		int index = origin.IndexOf(target);
		if (index > 0) {
			return origin.Substring(0, index);
		}
		return origin;
	}
}
