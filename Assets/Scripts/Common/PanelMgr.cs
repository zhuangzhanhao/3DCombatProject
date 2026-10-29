using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMgr : BaseSingleInstance<PanelMgr>
{
    public void OpenPanel<T>()
    {
        string panelName = typeof(T).ToString();
        GameObject testPanel = GameObject.Instantiate(Resources.Load<GameObject>(panelName));
        testPanel.transform.SetParent(GameObject.Find("Canvas").transform, false);
    }
    public void ClosePanel<T>()
    {
        
    }
}
