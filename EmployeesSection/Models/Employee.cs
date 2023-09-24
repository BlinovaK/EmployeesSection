namespace EmployeesSection.Models
{
    public class Employee
    {
        public int ID { get; private set; }
        public string FullName { get; private set; }
        public string JobTitle { get; private set; }
        
        private Employee() { }

        public Employee( string fullName, string jobTitle)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentNullException(nameof(fullName));
            if (string.IsNullOrWhiteSpace(jobTitle)) 
                throw new ArgumentNullException(nameof(jobTitle));

            FullName = fullName;
            JobTitle = jobTitle;
        }

        public void UpdateEmployee(string fullName, string jobTitle)
        {
            FullName = fullName;
            JobTitle = jobTitle;
        }
    }
}
