using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ticketing;


/*
Similar to Category management, you will need to be able to add users to the system. This will allow
you to associate a ticket to the user similar to how it's associated to the category.
User will have the following fields with specified validations
– FirstName (1 to 20 characters)
– LastName (1 to 20 characters)
– Email (must not be blank)
If any of the validations fail, a simple message should show prior to adding the the user.

//get a user by email address
//User aUser = UserUtility.Instance.GetUser("johndoe@email.com");

//get all the users into an array
//User[] users = UserUtility.Instance.GetUsers();
*/

public partial class Lab2_Default2 : System.Web.UI.Page
{
    User[] users;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillUsersTable();
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        //If User information to be added is valid, then use Ticket library to add the User
        if (Validation())
        {
            String fName = txtFName.Text;
            String lName = txtLName.Text;
            String email = txtEmail.Text;

            UserUtility.Instance.SaveUser(fName,lName,email);
            lblStatusAddUser.ForeColor = System.Drawing.Color.Green;
            lblStatusAddUser.Text = "The user was sucessfully added.";
            
            //Reload Table with new user
            fillUsersTable();
        }
    }

    private Boolean Validation()
    {
        //Declaring variables to be used for checking
        String potentialFName = txtFName.Text;
        String potentialLName = txtLName.Text;
        String potentialEmail = txtEmail.Text;

        //Checking for min & max length of characters
        if ((potentialFName.Length < 1) || (potentialFName.Length > 20))
        {
            lblStatusAddUser.ForeColor = System.Drawing.Color.Red;
            lblStatusAddUser.Text = "Error!  Please enter a first name that is between 1 to 20 characters long.";
            fillUsersTable();
            return false;
        }

        if ((potentialLName.Length < 1) || (potentialLName.Length > 20))
        {
            lblStatusAddUser.ForeColor = System.Drawing.Color.Red;
            lblStatusAddUser.Text = "Error!  Please enter a last name that is between 1 to 20 characters long.";
            fillUsersTable();
            return false;
        }

        if ((potentialFName.Length < 1))
        {
            lblStatusAddUser.ForeColor = System.Drawing.Color.Red;
            lblStatusAddUser.Text = "Error!  Please enter an email address that is at least 1 character long.";
            fillUsersTable();
            return false;
        }

        //Check if email is duplicate
        User aUser = UserUtility.Instance.GetUser(potentialEmail);

        if (aUser != null)
        {
            lblStatusAddUser.ForeColor = System.Drawing.Color.Red;
            lblStatusAddUser.Text = "Error!  This email already exists.";
            fillUsersTable();
            return false;
        }

        return true;        
    }

    private void fillUsersTable()
    {
        users = UserUtility.Instance.GetUsers();

        HtmlTableRow hRow = new HtmlTableRow();
        HtmlTableCell hCellFName = new HtmlTableCell();
        HtmlTableCell hCellLName = new HtmlTableCell();
        HtmlTableCell hCellEmail = new HtmlTableCell();

        User currentUser;
        //This code will add the headers to the Users display table2
        hCellFName.InnerText = "First Name";
        hCellLName.InnerText = "Last Name";
        hCellEmail.InnerText = "Email";

        hRow.Cells.Add(hCellFName);
        hRow.Cells.Add(hCellLName);
        hRow.Cells.Add(hCellEmail);

        table2.Rows.Add(hRow);

        //This code will go throught he users array and add them to table2 for display
        for (int u = 0; u < users.Length; u++)
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cellFName = new HtmlTableCell();
            HtmlTableCell cellLName = new HtmlTableCell();
            HtmlTableCell cellEmail = new HtmlTableCell();

            currentUser = users[u];

            cellFName.InnerText = currentUser.FirstName;
            cellLName.InnerText = currentUser.LastName;
            cellEmail.InnerText = currentUser.Email;

            row.Cells.Add(cellFName);
            row.Cells.Add(cellLName);
            row.Cells.Add(cellEmail);

            table2.Rows.Add(row);
        }
    }
}