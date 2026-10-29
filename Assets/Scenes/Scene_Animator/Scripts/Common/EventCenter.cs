using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

// 用于里氏替换原则，装载子类的父类
public abstract class EventInfoBase { }
// 包裹函数委托的类
public class EventInfo<T> : EventInfoBase
{
    // 真正的观察者信息
    public UnityAction<T> actions;
    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}
// 无参无返回值的委托
public class EventInfo : EventInfoBase
{
    public UnityAction actions;
    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}


public class EventCenter : SingleInstance<EventCenter>
{
    private Dictionary<string, EventInfoBase> eventDic = new Dictionary<string, EventInfoBase>();

    public EventCenter() { }

    // 触发
    public void EventTrigger<T>(string eventName, T info)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T>).actions?.Invoke(info);
        }
    }
    // 触发重载，无参数
    public void EventTrigger(string eventName)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo).actions?.Invoke();
        }
    }
    // 添加事件监听者
    public void AddEventListener<T>(string eventName, UnityAction<T> func)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T>).actions += func;
        }
        else
        {
            eventDic.Add(eventName, new EventInfo<T>(func));
        }
    }
    // 添加事件监听者重载
    public void AddEventListener(string eventName, UnityAction func)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo).actions += func;
        }
        else
        {
            eventDic.Add(eventName, new EventInfo(func));
        }
    }

    // 移除观察者和监听事件
    public void RemoveEventListener<T>(string eventName, UnityAction<T> func)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T>).actions -= func;
        }
    }
    // 移除观察者和监听事件重载
    public void RemoveEventListener(string eventName, UnityAction func)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo).actions -= func;
        }
    }
    // 清除所有事件
    public void Clear()
    {
        eventDic.Clear();
    }
    // 清除指定某一个事件的所有监听
    public void Clear(string eventName)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic.Remove(eventName);
        }
    }
}
