using System.Collections.Generic;
using UnityEngine;

public class Functions
{

	public static Vector3 RoundVector3ToDiscrete(Vector3 v) {
		v.x = Mathf.Round(v.x);
		v.y = Mathf.Round(v.y);
		v.z = Mathf.Round(v.z);
		return v;
	}

	public static Quaternion RoundQuaternionToDiscrete(Quaternion q) {
		Vector3 v = q.eulerAngles;
		v.x = Mathf.Round(v.x / 90) * 90;
		v.y = Mathf.Round(v.y / 90) * 90;
		v.z = Mathf.Round(v.z / 90) * 90;
		q.eulerAngles = v;
		return q;
	}

	public static Vector3 ApplyBoundsToVector3(Vector3 v, int min, int max) {
		v.x = Mathf.Round(Mathf.Clamp(v.x, min, max));
		v.y = Mathf.Round(Mathf.Clamp(v.y, min, max));
		v.z = Mathf.Round(Mathf.Clamp(v.z, min, max));
		return v;
	}

	public static void SetRendererColorAlpha(Renderer renderer, float colorAlpha) {
		Color c = renderer.material.color;
		c.a = colorAlpha;
		renderer.material.color = c;
	}

	public static string GetFormattedCoordinates(Vector3 position) {
		return position.ToString();
	}
	
	public static List<int> ShuffleIntList(List<int> intList) {
		for (int i = 0; i < intList.Count; i++) {
			int temp = intList[i];
			int randomIndex = Random.Range(i, intList.Count);
			intList[i] = intList[randomIndex];
			intList[randomIndex] = temp;
		}
		return intList;  
	}

    public static List<string> ShuffleStringList(List<string> strList) {
		for (int i = 0; i < strList.Count; i++) {
			string temp = strList[i];
			int randomIndex = Random.Range(i, strList.Count);
			strList[i] = strList[randomIndex];
			strList[randomIndex] = temp;
		}
		return strList;  
	}

	public static string StringFormatBinaryList(List<int> binList) {
		var strBinList = new List<string>();
		foreach (int bin in binList) {
			strBinList.Add(bin.ToString());
		}
		return "(" + string.Join(",", strBinList.ToArray()) + ")";
	}
	

}
