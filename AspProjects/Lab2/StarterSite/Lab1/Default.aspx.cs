using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (rdoDietary.Items.Count < 1)
        {
            rdoDietary.Items.Add("Gluten Free");
            rdoDietary.Items.Add("Vegetarian");
            rdoDietary.Items.Add("NA");
            rdoDietary.SelectedIndex = 2;
        }
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime dateSelected = Calendar1.SelectedDate;
        DayOfWeek daySelected = dateSelected.DayOfWeek;

        if (!checkDay())
        {
            lblCalendar.Text = "Must Select A Weekend";
        }
        else
        {
            lblCalendar.Text = String.Empty;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (lboRegistrations.SelectedIndex > -1)
        {
            String removeText = lboRegistrations.SelectedItem.Text;
            lboCancRegistrations.Items.Add(removeText);
            lboRegistrations.Items.RemoveAt(lboRegistrations.SelectedIndex);
        }

        btnCancelReg.Enabled = false;
    }

    protected void btnRegistration_Click(object sender, EventArgs e)
    {
        //Reset Specify Name Error Message
        lblName.Text = String.Empty;

        //Check if name textbox is empty
        //If empty then throw alert message    
        if (txtName.Text == String.Empty)
        {
            lblName.Text = "Must Specify Name";           
            return;
        }

        //Check if calendar is weekend
        //If weekday, throw exception
        DateTime dateSelected = Calendar1.SelectedDate;
        DayOfWeek daySelected = dateSelected.DayOfWeek;
        
        //Check if weekend or weekday.
        if (!checkDay())
        {
            lblCalendar.Text = "Must Select A Weekend";
            return;
        }

        String dietReq;

        switch (rdoDietary.SelectedIndex)
        {
            case 0:
                dietReq = "Gluten Free";
                break;
            case 1:
                dietReq = "Vegetarian";
                break;
            case 2:
                dietReq = "NA";
                break;
            default:
                dietReq = "NA";
                break;   
        }

        lboRegistrations.Items.Add(txtName.Text + ", " + Calendar1.SelectedDate.ToString("MM/dd/yyyy") + ", " + dietReq);
   
        //Reset Name and Calendar
        txtName.Text = String.Empty;
        Calendar1.SelectedDate = DateTime.Today;
    }
    protected void lboRegistrations_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (lboRegistrations.SelectedIndex > -1)
        {
            btnCancelReg.Enabled = true;
            lboRegistrations.Focus();
        }
        else
        {
            btnCancelReg.Enabled = false;
        }        
    }

    private void resetErrorFields()
    {
        lblCalendar.Text = String.Empty;
        lblName.Text = String.Empty;
    }

    private Boolean checkDay()
    {
        DateTime dateSelected = Calendar1.SelectedDate;
        DayOfWeek daySelected = dateSelected.DayOfWeek;

        if (!(daySelected.Equals(DayOfWeek.Saturday) || daySelected.Equals(DayOfWeek.Sunday)))
        {
            return false;
        }

        return true;
    }
}