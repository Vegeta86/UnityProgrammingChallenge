using System.IO;
using SFB;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    private string jsonFile;
    private string filePath;
    public JSONObject jsonObject;

    public JSONObject LoadAssetFile(bool reload)
    {
        if (reload)
        {
            filePath = StandaloneFileBrowser.OpenFilePanel("Open File", Application.streamingAssetsPath, "json", false)[0].ToString();
        }
        else
        {
            filePath = Application.streamingAssetsPath + "/JsonChallenge.json";
        }

        try
        {
            jsonFile = File.ReadAllText(filePath);
            jsonObject = new JSONObject(jsonFile);
            Debug.Log("loading json file succesfull");
            return jsonObject;

        }
        catch (System.Exception ex)
        {
            Debug.Log("Error, Can't load file, check json format and try again: " + ex);
            return null;
        }
    }

}
