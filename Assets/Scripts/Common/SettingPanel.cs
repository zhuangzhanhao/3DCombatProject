using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SettingPanelCtrlState
{
    viewState = 0,
    soundState = 1,
    frameState = 2
}
public class SettingPanel : MonoBehaviour
{
    private SettingPanelCtrlState curCtrlState; // 当前状态控制器的值
    [Header("控制器 ctrlState")]
    public List<GameObject> viewStateList;
    public List<GameObject> soundStateList;
    public List<GameObject> frameStateList;
    [Header("按钮")]
    public Button btnView;
    public Button btnSound;
    public Button btnFrame;

    #region 生命周期
    public void Start()
    {
        curCtrlState = SettingPanelCtrlState.viewState;
        AllBtnBindEvents();
        RefreshUIState();
    }
    
    #endregion

    #region 逻辑部分
    private void SwitchState(SettingPanelCtrlState targetState)
    {
        curCtrlState = targetState;
        RefreshUIState();
    }
    private void RefreshUIState()
    {
        // 先把所有状态的物体都隐藏
        SetListActive(viewStateList, false);
        SetListActive(soundStateList, false);
        SetListActive(frameStateList, false);

        // 然后单独激活对应状态的物体
        switch (curCtrlState)
        {
            case SettingPanelCtrlState.viewState:
                SetListActive(viewStateList, true);
                break;
            case SettingPanelCtrlState.soundState:
                SetListActive(soundStateList, true);
                break;
            case SettingPanelCtrlState.frameState:
                SetListActive(frameStateList, true);
                break;
        }
    }
    private void SetListActive(List<GameObject> list, bool active)
    {
        foreach(var obj in list)
        {
            obj.SetActive(active);
        }
        
    }
    #endregion

    #region 事件监听

    #endregion

    #region 事件绑定
    private void AllBtnBindEvents()
    {
        btnView.onClick.AddListener(OnSwitchStateToViewState);
        btnSound.onClick.AddListener(OnSwitchStateToSoundState);
        btnFrame.onClick.AddListener(OnSwitchStateToFrameState);
    }
    private void OnSwitchStateToViewState()
    {
        SwitchState(SettingPanelCtrlState.viewState);
    }
    private void OnSwitchStateToSoundState()
    {
        SwitchState(SettingPanelCtrlState.soundState);
    }
    private void OnSwitchStateToFrameState()
    {
        SwitchState(SettingPanelCtrlState.frameState);
    }
    #endregion
}
