using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
*/

public partial class Lab2_Users : System.Web.UI.Page
{
    User[] users;

    protected void Page_Load(object sender, EventArgs e)
    {
        users = UserUtility.Instance.GetUsers();
    }

    private Boolean Validation()
    {
        //Declaring variables to be used for checking
        String potentialFName = txt.Text;
        Category currentCategory = null;

        //Checking for min & max length of characters
        if ((potentialCat.Length <= 1) || (potentialCat.Length > 20))
        {
            lblCatStatus.Text = "Error!  Please enter a category name that is between 2 to 20 characters long.";
            return false;
        }

        //Iterate through categories array to determine if there is a duplicate category already in array
        for (int c = 0; c < categories.Length; c++)
        {
            currentCategory = categories[c];
            if (potentialCat.Equals(currentCategory.Name))
            {
                lblCatStatus.Text = "Error! Category:" + potentialCat + " already exists in this list!";
                return false;
            }
        }

        return true;
    }
}