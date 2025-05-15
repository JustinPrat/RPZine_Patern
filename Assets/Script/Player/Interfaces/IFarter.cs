using System;

public interface IFarter
{
    public void Fart();
    public event Action OnFartInputPressed;
    public void RaiseFartInputPressed();
}