namespace UserCRUD;

public class RouteAttribute: Attribute
{
    public string Path { get; set; }
    public string Method { get; set; }
}