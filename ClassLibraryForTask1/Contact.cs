/// <summary>
/// 
/// </summary>
namespace Task1
{
    public class Contact
    {
        public Contact(string name_)
        {
            this.Name = name_;
        }

        public Contact()
        {
            this.Name = string.Empty;
        }

        public string Name { get; set; }
    }
}