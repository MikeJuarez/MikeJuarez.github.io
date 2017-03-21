using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticketing;

/*
Page 3 (TicketsAdd.aspx) – Ticket Management Page
Similar to the previous to pages, you will need to add the ability to create tickets. These tickets will
have the following fields along with their validations:
– title (string no more than 50 characters)
– category (selection from a list based on entries added from previous steps
– designated user (selection from a list based on entries added from previous steps)
– description (larger text area)
 */

public partial class Lab2_TicketsAdded : System.Web.UI.Page
{
    private Category[] categories;
    private User[] users;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillDropDowns();
    }

    protected void btnSubmitTicket_Click(object sender, EventArgs e)
    {
        users = UserUtility.Instance.GetUsers();
        categories = CategoryUtility.Instance.GetCategories();

        if (categories.Length < 1 || users.Length < 1)
        {
            lblStatusSubmit.ForeColor = System.Drawing.Color.Red;
            lblStatusSubmit.Text = "Sorry, cannot create ticket without both categories and users having at least one entry.";
            return;
        }
        
        if (validation())
        {
            TicketsUtility.Instance.SaveTicket(txtTitle.Text, categories[drpCategory.SelectedIndex].Name, users[drpUser.SelectedIndex], txtDescription.Text);
            lblStatusSubmit.ForeColor = System.Drawing.Color.Green;
            lblStatusSubmit.Text = "Your ticket was successfully submitted.";
     
        }
    }

    private Boolean validation()
    {
        String title = txtTitle.Text;        

        if (title.Length > 50)
        {
            lblStatusSubmit.ForeColor = System.Drawing.Color.Red;
            lblStatusSubmit.Text = "Error!  The title needs to be between 0 and 50 characters";
            return false;
        }

        return true;
    }

    private void fillDropDowns()
    {
        users = UserUtility.Instance.GetUsers();
        categories = CategoryUtility.Instance.GetCategories();

        //Add categories 
        for (int c = 0; c < categories.Length; c++)
        {
            Category currentCat = categories[c];
            drpCategory.Items.Add(currentCat.Name);
        }

        //Add users
        for (int u = 0; u < users.Length; u++)
        {
            User currentUser = users[u];
            drpUser.Items.Add(currentUser.FirstName + " " + currentUser.LastName);
        }
    }
}