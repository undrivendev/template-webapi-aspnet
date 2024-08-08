namespace WebApiTemplate.Core;

/// <summary>
/// This class should be used instead of void for return types.
/// Taken from: https://github.com/gregoryyoung/nothing/blob/master/Unit/Nothing.cs
/// </summary>
public class Nothing
{
    /// <summary>
    /// Singleton instance of the Nothing class.
    /// </summary>
    public static readonly Nothing Instance = new();

    private Nothing() { }

    /// <inheritdoc />
    public override string ToString() => "Nothing";
}
