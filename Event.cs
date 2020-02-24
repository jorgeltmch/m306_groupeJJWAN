// FILE: C:/m306_groupeJJWAN//Event.cs

// In this section you can add your own using directives
    // section 10-5-45-40--5b51da51:1700b5340f9:-8000:0000000000000867 begin
    // section 10-5-45-40--5b51da51:1700b5340f9:-8000:0000000000000867 end

/// <summary>
    ///  A class that represents ...
    /// 
    ///  @see OtherClasses
    ///  @author your_name_here
     /// </summary>
public class Event
{
    // Attributes

    public string name;

    public Category category;

    public string description;

    public DateTime date;

    public string adress;

    public double geoLocalisationLat;

    public double geoLocalisationLon;

    // Associations

    /// <summary> 
    /// </summary>
    public ArrayList  myCategory;

    /// <summary> 
    /// </summary>
    public ArrayList  myCategory;

    // Operations

    /// <summary>
    ///  An operation that does...
    /// 
    ///  @param firstParam a description of this parameter
    /// </summary>
    /// <param name="name">
    /// </param>
    /// <param name="category">
    /// </param>
    /// <param name="description">
    /// </param>
    /// <param name="date">
    /// </param>
    /// <param name="adress">
    /// </param>
    /// <returns>
    /// </returns>
    public Event( name,  category,  description,  date,  adress)
    {
    // section 10-5-45-40--5b51da51:1700b5340f9:-8000:0000000000000893 begin
    // section 10-5-45-40--5b51da51:1700b5340f9:-8000:0000000000000893 end

    }

    /// <summary>
    ///  An operation that does...
    /// 
    ///  @param firstParam a description of this parameter
    /// </summary>
    /// <param name="name">
    /// </param>
    /// <param name="category">
    /// </param>
    /// <param name="description">
    /// </param>
    /// <param name="date">
    /// </param>
    /// <param name="geoLocation">
    /// </param>
    /// <returns>
    /// </returns>
    public Event( name,  category,  description,  date,  geoLocation)
    {
    // section 10-5-45-40--5b51da51:1700b5340f9:-8000:000000000000089E begin
    // section 10-5-45-40--5b51da51:1700b5340f9:-8000:000000000000089E end

    }
} /* end class Event */
