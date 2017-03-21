using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticketing;

//to add add a category, you can call
//CategoryUtility.Instance.AddCategory("Category1");

//get all the categories into an array.
//Category[] categories = CategoryUtility.Instance.GetCategories();

public partial class Lab2_Default : System.Web.UI.Page
{
    private Category[] categories;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        categories = CategoryUtility.Instance.GetCategories();       

        //Fill the listbox if the page just loaded or reloaded.
        if (!IsPostBack)
        {
            Category currentCategory = null;
                        
            for (int c = 0; c < categories.Length; c++)
            {
                currentCategory = categories[c];
                lboCategories.Items.Add(currentCategory.Name);
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {        
        String potentialCat = txtAddCat.Text;

        //If category to be added is valid, then use Ticket library to add the category
        if (Validation())
        {
            CategoryUtility.Instance.AddCategory(potentialCat);
            lboCategories.Items.Add(potentialCat);
            lblCatStatus.ForeColor = System.Drawing.Color.Green;
            lblCatStatus.Text = "The category was sucessfully added.";
        }
    }

    //Note:
    //  • Basic validation should not allow categories with minimum of 1 character up to 20 characters.
    //  • You should also not allow duplicate categories.
    private Boolean Validation()
    {
        //Declaring variables to be used for checking
        String potentialCat = txtAddCat.Text;
        Category currentCategory = null;

        //Checking for min & max length of characters
        if ((potentialCat.Length < 1) || (potentialCat.Length > 20))
        {
            lblCatStatus.ForeColor = System.Drawing.Color.Red;
            lblCatStatus.Text = "Error!  Please enter a category name that is between 1 to 20 characters long.";
            return false;
        }
        
        //Iterate through categories array to determine if there is a duplicate category already in array
        for (int c = 0; c < categories.Length; c++)
        {
            currentCategory = categories[c];
            if (potentialCat.Equals(currentCategory.Name))
            {
                lblCatStatus.ForeColor = System.Drawing.Color.Red;
                lblCatStatus.Text = "Error! Category:" + potentialCat + " already exists in this list!";
                return false;
            }
        }

        return true;
    }
}