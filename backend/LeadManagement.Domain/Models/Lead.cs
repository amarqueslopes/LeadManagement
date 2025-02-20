using LeadManagement.Domain.Events;

namespace LeadManagement.Domain.Models
{
    public class Lead
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Suburb { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string Status { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        public Lead(int id, string firstName, string lastName, DateTime dateCreated, string status, string suburb, string category, string description, decimal price, string phoneNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateCreated = dateCreated;
            Status = status;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        private void Apply10PercentDiscountOnPriceOver500 ()
        {
            if (Price > 500)
            {
                Price *= 0.9m;
            }
        }

        public void Accept()
        {
            Status = "Accepted";
            Apply10PercentDiscountOnPriceOver500();
        }

        public void Decline()
        {
            Status = "Declined";
        }
    }
}
