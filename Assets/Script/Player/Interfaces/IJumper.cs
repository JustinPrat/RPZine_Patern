using System;


public interface IJumper: IJumpRequester, IJumpExecuter, IGravityConcerned
{
    
}

public interface IJumpRequester
{
    public event Action OnJumpInputPressed ;
    public void RaiseJumpInputPressedInputPressed();    
}

public interface IJumpExecuter: IVelocityReader
{
    public void Jump(float jumpForce);
}