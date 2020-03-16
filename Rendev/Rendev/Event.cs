// FILE: C:/m306_groupeJJWAN//Event.cs

using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using Rendev;
using System;
using System.Collections.Generic;
/// <summary>
///  A class that represents ...
/// 
///  @see OtherClasses
///  @author your_name_here
/// </summary>
public class Event : GMarkerGoogle
{
    // Fields...

    private int _id;
    private string _name;
    private Category _category;
    private string _description;
    private DateTime _date;
    private Position _eventPosition;
    // Properties...
    public DateTime Date { get => _date; set => _date = value; }
    public string Description { get => _description; set => _description = value; }
    public Category Category { get => _category; set => _category = value; }
    internal Position EventPosition { 
        get => _eventPosition;
        set
        {
            _eventPosition = value;
        }
    }
    public int Id { get => _id; set => _id = value; }
    public string Adress {
        get
        {
            return Map.GetAddressFromLatLon(EventPosition.PointLatLng);
        }
    }
    public string Name { get => _name; set => _name = value; }

    // Constructor...

    public Event(int paramId, string paramName, Category paramCategory, string paramDescription, DateTime paramDate, Position paramPosition) :base(paramPosition.PointLatLng, paramCategory.GetMarkerType)
    {
        _id = paramId;
        _name = paramName;
        _category = paramCategory;
        _description = paramDescription;
        _date = paramDate;
        _eventPosition = paramPosition;
    }
    
} /* end class Event */
