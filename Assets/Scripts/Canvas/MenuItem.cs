using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public abstract class MenuItem : MonoBehaviour
{
    public abstract MenuType AssignedMenuType { get; protected set; }
    public Action OnOpen { get; set; }
    public Action OnClose { get; set; }

    public void Open()
    {
        OnOpen?.Invoke();
        OpenInstruction();
    }
    public void Close()
    {
        OnClose?.Invoke();
        CloseInstruction();
    }

    protected abstract void OpenInstruction();
    protected abstract void CloseInstruction();

}
