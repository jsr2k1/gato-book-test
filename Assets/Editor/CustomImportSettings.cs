using UnityEngine;
using UnityEditor;
using System;

//Sets our settings for all new Models and Textures upon first import
public class CustomImportSettings : AssetPostprocessor 
{
	//public const float globalScaleModifier = 0.0028f;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void OnPreprocessModel() 
	{
		ModelImporter importer = assetImporter as ModelImporter;

		//importer.globalScale  = globalScaleModifier;
		//importer.globalScale  = 1.0f;
		importer.swapUVChannels = false;
		//importer.addCollider = true;
		//importer.generateSecondaryUV=false;
    }
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void OnPreprocessTexture()
	{
		TextureImporter textureImporter = assetImporter as TextureImporter;

		if(textureImporter.assetPath.Contains("GUITexturesAndSkins"))
		{
			textureImporter.textureType = TextureImporterType.GUI;
			textureImporter.npotScale = TextureImporterNPOTScale.None;
			textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;
		}
		
		else if(textureImporter.assetPath.Contains("_Paginas"))
		{
			textureImporter.textureType = TextureImporterType.Image;
			//textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;
			textureImporter.wrapMode = TextureWrapMode.Clamp;
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void OnPreprocessAudio()
	{
		AudioImporter audioImporter = assetImporter as AudioImporter;
		
		audioImporter.format = AudioImporterFormat.Compressed;
		audioImporter.threeD = false;
    }
}






