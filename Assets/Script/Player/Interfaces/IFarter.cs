using System;

public interface IFarter
{
    public void Fart();
    public void Reload();
    
    public int CurrentFartAmount { get; }
    public int FartAmount { get; }
    public event Action OnFart;
    public event Action OnReload;
    public event Action OnReloadComplete;
    public void RaiseFartInputPressed();
    public void RaiseReloadInputPressed();
    public void RaiseReloadComplete();
}