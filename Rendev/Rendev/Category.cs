// FILE: C:/m306_groupeJJWAN//Category.cs

// In this section you can add your own using directives
// section 10-5-45-40--5b51da51:1700b5340f9:-8000:0000000000000868 begin
// section 10-5-45-40--5b51da51:1700b5340f9:-8000:0000000000000868 end

using GMap.NET.WindowsForms.Markers;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
/// <summary>
///  A class that represents ...
/// 
///  @see OtherClasses
///  @author your_name_here
/// </summary>
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
