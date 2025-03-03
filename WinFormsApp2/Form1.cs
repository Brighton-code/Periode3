using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using (CustomerContext context = new CustomerContext())
            {
                context.Database.EnsureCreated();
                CustomerContext.SeedData(context);
                customerGridView.DataSource = context.Customers.ToList();
            }

        }

        private void Search(string search)
        {
            string searchTerm = search.Trim().ToLower();
            using (var context = new CustomerContext())
            {
                var filteredCustomeres = context.Customers
                    .Where(c => c.Name.ToLower().Contains(searchTerm))
                    .ToList();
                customerGridView.DataSource = filteredCustomeres;
            }
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Search(searchTextBox.Text);
        }
    }

    public class Customer
    {
        public int Id { get; private set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }

    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CustomerDB;Trusted_Connection=True;");

        public static void SeedData(CustomerContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer { Name = "John Doe", Email = "john@example.com" },
                    new Customer { Name = "Jane Smith", Email = "jane@example.com" },
                    new Customer { Name = "Alice Johnson", Email = "alice@example.com" }
                );

                context.SaveChanges();
            }
        }
    }
}
