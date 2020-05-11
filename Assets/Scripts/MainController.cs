using UnityEngine;
using UnityEngine.UI;


public class MainController : MonoBehaviour
{
    public JsonLoader jsonLoader;
    public JSONObject jsonObject;
    public UIGenerator uiGenerator;
    public string title;
    public int headersCount;
    public int membersCount;
    public bool importJson;
    public Button importJsonFilebutton;

    private void Start()
    {
        importJsonFilebutton.onClick.AddListener(ReloadFileDialog);
        jsonObject = jsonLoader.LoadAssetFile(false);
        GetJsonUIInfo();
        UIDeploy();   
    }

    public void ReloadFileDialog()
    {
        jsonObject = jsonLoader.LoadAssetFile(true);
        uiGenerator.UIRefresh();
        GetJsonUIInfo();
        UIDeploy();
    }

    public JSONObject GetJsonUIInfo()
    {
        try
        {
            title = jsonObject.GetField("Title").ToString().Replace('"', ' ').Trim();
            headersCount = jsonObject.GetField("ColumnHeaders").Count;
            membersCount = jsonObject.GetField("Data").Count;
            return jsonObject;
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex + "Tile, ColumnHeaders and Data properties was expected on json file ");
        }
        return null;
    }

    public void UIDeploy()
    {
        uiGenerator.CreateUITitle(title);
        uiGenerator.CreateUIColumns(headersCount);
        uiGenerator.CreateUIRows(membersCount);
    }




}
