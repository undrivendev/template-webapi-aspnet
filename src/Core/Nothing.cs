namespace WebApiTemplate.Core;

/// <summary>
/// This class should be used instead of void for return types.
/// Taken from: https://github.com/gregoryyoung/nothing/blob/master/Unit/Nothing.cs
/// </summary>
public class Nothing
{
    public static readonly Nothing Instance = new();

    private Nothing() { }

    public override string ToString() => "Nothing";
}
