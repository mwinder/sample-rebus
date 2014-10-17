
namespace Messages
{
    public class CustomerSubscribed
    {
        public string Name { get; set; }

        public CustomerSubscribed(string name)
        {
            Name = name;
        }
    }
}
