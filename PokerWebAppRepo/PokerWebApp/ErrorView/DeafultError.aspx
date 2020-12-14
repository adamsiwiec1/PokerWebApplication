<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeafultError.aspx.cs"%>

<!DOCTYPE html>
<script runat="server">

    protected void btn_ErrorHomeRedirect_Click(object sender, EventArgs e)
    {
         Response.Redirect("~/Account/Login.aspx");
    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />

            <p>
                Default error: schlong time has timed out 0101
            </p>

            <br />

            <p>
                Please press the button to redirect to the login page.
            </p>

            <asp:Button ID="btn_ErrorHomeRedirect" runat="server" Text="Go" OnClick="btn_ErrorHomeRedirect_Click"/>



        </div>
    </form>
</body>
</html>
