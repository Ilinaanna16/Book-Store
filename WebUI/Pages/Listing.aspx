<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="WebUI.Pages.Listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>BookStore</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%
                foreach (Domain.Entities.Book book in GetBooks())
                {
                    Response.Write(String.Format(@"
                        <div class='item'>
                            <h3>{0} - {1}</h3>
                            {2}
                            <h4>{3:c}</h4>

                        </div>", 
                        book.Name, book.Author, book.Description, book.Price));
                }
            %> 
        </div>
    </form>
    <div>
        <%
            for (int i = 1; i <= MaxPage; i++)
            {
                Response.Write(
                    String.Format("<a href='/Pages/Listing.aspx?page={0}' {1}>{2}</a>",
                        i, i == CurrentPage ? "class='selected'" : "", i));
            }
        %>
    </div>
</body>
</html>
