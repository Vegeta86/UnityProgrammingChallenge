using UnityEngine;
using UnityEngine.UI;

public class UIGenerator : MonoBehaviour
{
    public MainController mainController;
    public Text titleText;
    public Text headersTextCell;
    public Text membersTextCell;
    public HorizontalLayoutGroup HeadersGridLayout;
    public GridLayoutGroup MembersGridLayout;
    public string[] propertyList;



    public void CreateUITitle(string title)
    {
        titleText.text = title;
    }

    public void CreateUIColumns(int columnsCount)
    {
        propertyList = new string[mainController.headersCount];
        for (int i = 0; i < columnsCount; i++)
        {
            headersTextCell = Instantiate(headersTextCell);
            try
            {
                propertyList[i] = mainController.GetJsonUIInfo().GetField("ColumnHeaders")[i].ToString().Replace('"', ' ').Trim();
                headersTextCell.text = mainController.GetJsonUIInfo().GetField("ColumnHeaders")[i].ToString().Replace('"', ' ').Trim();
            }
            catch (System.Exception ex)
            {
                headersTextCell.text = "Missing Header";
                Debug.Log(ex + "property is missing into ColumnHeaders property");
            }

            headersTextCell.transform.SetParent(HeadersGridLayout.transform, false);
            headersTextCell.enabled = true;
        }
    }

    public void CreateUIRows(int rowsCount)
    {
        MembersGridLayout.constraintCount = mainController.headersCount;
        for (int i = 0; i < rowsCount; i++)
        {
            for (int x = 0; x < mainController.headersCount; x++)
            {
                membersTextCell = Instantiate(membersTextCell);
                try
                {
                    membersTextCell.text = mainController.GetJsonUIInfo().GetField("Data")[i].GetField(propertyList[x]).ToString().Replace('"', ' ').Trim();
                }
                catch (System.Exception ex)
                {
                    membersTextCell.text = "No Info";
                    Debug.Log(ex + "property is missing into DATA object");
                }
                membersTextCell.transform.SetParent(MembersGridLayout.transform, false);
                membersTextCell.enabled = true;
            }
        }
    }

    public void UIRefresh()
    {
        GameObject[] UIText = GameObject.FindGameObjectsWithTag("UIText");
        foreach (GameObject text in UIText)
        {
            Destroy(text);
        }
    }
}
