using System;

public interface IFarter
{
    public void Fart();
    public void Reload();
    public event Action OnFart;
    public event Action OnReload;
    public void RaiseFartInputPressed();
    public void RaiseReloadInputPressed();
}