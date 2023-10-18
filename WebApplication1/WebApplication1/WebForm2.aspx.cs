using System;

namespace YourNamespace
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // All validation checks passed, continue with registration logic here.
                // For example, you could save the data to a database.
                string name = txtName.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                int age = Convert.ToInt32(txtAge.Text);

                // Perform registration logic here...
            }
        }
    }
}
