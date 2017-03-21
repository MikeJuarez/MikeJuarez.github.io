using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ticketing;
/*
This page allows you to filter all the tickets in the system by either Category or User. You choose
which one you want to do. By default, the filter will will show “All”. If user selects a specific
category, then all the tickets related to the category will appear. If user selects a user, similarly, the
tickets designated to the selected user are shown.
*/



public partial class Lab2_TicketsView : System.Web.UI.Page
{

    private Boolean allSelected = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillCategories();
            fillUsersTable();
        }
    }

    protected void btnSubmitTicket_Click(object sender, EventArgs e)
    {
        if (drpCategory.Text.Equals("All"))
            allSelected = true;
        else
            allSelected = false;

        fillUsersTable();
    }

    private void fillCategories()
    {
        Category[] categories = CategoryUtility.Instance.GetCategories();

        drpCategory.Items.Add("All");

        for (int c = 0; c < categories.Length; c++)
        {
            drpCategory.Items.Add(categories[c].Name);
        }
    }

    private void fillUsersTable()
    {
        int listCount = 0;

        HtmlTableRow hRow = new HtmlTableRow();
        HtmlTableCell hCellTitle = new HtmlTableCell();
        HtmlTableCell hCellUser = new HtmlTableCell();
        HtmlTableCell hCellCategory = new HtmlTableCell();
        HtmlTableCell hCellDescription = new HtmlTableCell();

        //This code will add the headers to the Users display table2
        hCellTitle.InnerText = "Title";
        hCellUser.InnerText = "User";
        hCellCategory.InnerText = "Category";
        hCellDescription.InnerText = "Description";

        hRow.Cells.Add(hCellTitle);
        hRow.Cells.Add(hCellUser);
        hRow.Cells.Add(hCellCategory);
        hRow.Cells.Add(hCellDescription);

        table2.Rows.Add(hRow);

        String catSelection = drpCategory.Text;        
        Ticket[] tickets = TicketsUtility.Instance.GetTickets();

        //This code will display the filtered results
        for (int t = 0; t < tickets.Length; t++)
        {
            Ticket currentTicket = tickets[t];
            
            if (currentTicket.Cateogry.Equals(catSelection) || allSelected == true)
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cellTitle = new HtmlTableCell();
                HtmlTableCell cellUser = new HtmlTableCell();
                HtmlTableCell cellCategory = new HtmlTableCell();
                HtmlTableCell cellDescription = new HtmlTableCell();

                cellTitle.InnerText = currentTicket.Title;
                cellUser.InnerText = currentTicket.User.FirstName + " " + currentTicket.User.LastName;
                cellCategory.InnerText = currentTicket.Cateogry;
                cellDescription.InnerText = currentTicket.Description;

                row.Cells.Add(cellTitle);
                row.Cells.Add(cellUser);
                row.Cells.Add(cellCategory);
                row.Cells.Add(cellDescription);

                table2.Rows.Add(row);
                listCount++;
            }
        }

        lblCount.Text = listCount.ToString() + " ticket(s) counted for the " + catSelection + " category.";
    }
}