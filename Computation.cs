using UnityEngine;
using System.Collections;

public class Computation
{

	public Vector3 computeVelocity(Vector3 colNormal, Vector3 colVelocity)
	{
		Vector3 colTan = new Vector3 ((colNormal.x * Mathf.Cos (1.5707f) - colNormal.y * (float)Mathf.Sin (1.5707f)), //x
										(colNormal.x * (float)Mathf.Sin (1.5707f) + colNormal.y * (float)Mathf.Cos (1.5707f)),//y
		                             																						0); //z

		float a = -Vector3.Dot (colVelocity, colNormal);
		float b = Vector3.Dot (colVelocity, colTan);
		Vector3 resultVel = a * colNormal + b * colTan;
		return resultVel;
	}
}
