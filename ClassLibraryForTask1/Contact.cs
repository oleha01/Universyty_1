namespace Task1
{
    public class Contact
    {
        public string name { get; set; }
        public Contact(string name_)
        {
            name = name_;
        }
        public Contact()
        {
            name = string.Empty;
        }
    }
}