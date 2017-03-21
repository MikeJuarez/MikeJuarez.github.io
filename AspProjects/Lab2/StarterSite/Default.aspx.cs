using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ticketing;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //to use the libary you have to include the Ticketing namespace as shown above.
        //Right now it's showing with a red underline because it's not added to the project as a reference.
        //View the provided video in the forum on how to use a library.

        //to add add a category, you can call
        //CategoryUtility.Instance.AddCategory("Category1");

        //get all the categories into an array.
        //Category[] categories = CategoryUtility.Instance.GetCategories();

        //get a user by email address
        //User aUser = UserUtility.Instance.GetUser("johndoe@email.com");

        //get all the users into an array
        //User[] users = UserUtility.Instance.GetUsers();
    }
}
