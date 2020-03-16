using GMap.NET.WindowsForms.Markers;

public class Category
{
    // Attributes

    private int _id;
    private string _name;
    private GMarkerGoogleType _image;

    // Properties...
    public GMarkerGoogleType GetMarkerType
    {
        get
        {
            return _image;
        }
    }

    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }

    // Constructors...
    public Category(int paramId, string paramName, GMarkerGoogleType paramImage)
    {
        _id = paramId;
        _name = paramName;
        _image = paramImage;
    }
} /* end class Category */
