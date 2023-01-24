namespace EmployeeSystem;

public record Person
{
    public int id { get; set; }
    public string name { get; set; }
}

public record Employee
{
    public string _id { get; set; }
    public int index { get; set; }
    public Guid guid { get; set; }
    public bool isActive { get; set; }
    public string balance { get; set; }
    public string picture { get; set; }
    public int age { get; set; }
    public string eyeColor { get; set; }
    public string name { get; set; }
    public string firstName { get; set; }
    public string surName { get; set; }
    public string gender { get; set; }
    public string company { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string address { get; set; }
    public string about { get; set; }
    public DateTime registered { get; set; }
    public float latitude { get; set; }
    public float longtitude { get; set; }
    public string[] tags { get; set; }
    public Person[] friends { get; set; }
}