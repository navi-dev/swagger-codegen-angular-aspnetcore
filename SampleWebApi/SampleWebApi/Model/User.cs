namespace SampleWebApi.Model
{
    public class User
    {
        public User()
        {

        }

        public User(int id, string firstName, string lastName, string emailId, string designation)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailId = emailId;
            Designation = designation;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Designation { get; set; }
    }
}
