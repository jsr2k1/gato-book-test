using UnityEngine;
using System.Collections;
using System.Text;

public class SetGUIText : MonoBehaviour
{
	public GUISkin m_skin;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Start()
	{
		string texto = "Allá en el horizonte\n" +
			"hay un barquito con un polizonte\n" +
			"el hombre mira desde lejos\n" +
			"usando todos sus catalejos\n" +
			"y divisa la cola... ¡de un bisonte!";
		
		string textoUTF = ConvertToUTF(texto);

		guiText.text = textoUTF;
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////
	/*
	void OnGUI()
	{
		GUI.skin = m_skin;
		
		string texto = "Allá en el horizonte\n" +
			"hay un barquito con un polizonte\n" +
			"el hombre mira desde lejos\n" +
			"usando todos sus catalejos\n" +
			"y divisa la cola... ¡de un bisonte!";
		
		string textoUTF = ConvertToUTF(texto);
		
		GUI.Label(new Rect(360,65,300,180), textoUTF, "textos");
	}
	*/
	//////////////////////////////////////////////////////////////////////////////////////////////////
	
	string ConvertToUTF(string texto)
	{
		Encoding iso = Encoding.GetEncoding("ISO-8859-1");
		Encoding utf8 = Encoding.UTF8;
		string textoUTF = utf8.GetString(iso.GetBytes(texto));
		
		return textoUTF;
	}
}



