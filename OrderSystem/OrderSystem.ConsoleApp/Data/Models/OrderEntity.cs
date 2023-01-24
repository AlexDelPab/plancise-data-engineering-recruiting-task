namespace OrderSystem.ConsoleApp.Data.Models;

public class OrderEntity
{
    public Guid Id { get; set; }
    
    public string Notes { get; set; }
    
    public string AssignedEmployee { get; set; }
    
    public Guid OrderedItem { get; set; }
    
    public DateTime Date { get; set; }
}