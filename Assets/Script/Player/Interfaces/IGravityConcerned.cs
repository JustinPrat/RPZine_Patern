public interface IGravityConcerned: IGravityReader, IGravityWritter
{
    
}

public interface IGravityReader
{
    public float GravityScale { get; }
}

public interface IGravityWritter
{
    public float GravityScale { get; set; }
}