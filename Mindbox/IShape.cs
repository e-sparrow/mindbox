namespace Mindbox
{
    public interface IShape<out TArea>
    {
        TArea CalculateArea();
    }
}