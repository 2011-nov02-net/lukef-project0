namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Location
    {

        public int LocationId { get; set; }
        public string Name { get; set; }

        public Location()
        {

        }

        public Location(int locationId, string name)
        {
            LocationId = locationId;
            Name = name;
        }





    }
}
