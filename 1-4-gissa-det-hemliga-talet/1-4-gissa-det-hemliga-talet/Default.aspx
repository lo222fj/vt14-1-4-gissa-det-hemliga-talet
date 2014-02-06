<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1_4_gissa_det_hemliga_talet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link href="Content/style.css" rel="stylesheet" />
    <script src="Content/script.js"></script>
</head>
<body>
    <form id="form1" runat="server" >
        <div id="main">
            <h1>Gissa det hemliga talet</h1>
            <div id="ValidationDiv">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    CssClass="ErrorMessages" />
            </div>

            <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1 och 100: "></asp:Label>
            <%--Inputfält--%>
            <asp:TextBox ID="GuessTextBox" runat="server" TextMode="SingleLine"></asp:TextBox>
            <%--Validering--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="Ett tal måste anges." Text="*" Display="Dynamic"
                ControlToValidate="GuessTextBox"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server"
                ControlToValidate="GuessTextBox" Display="Dynamic"
                ErrorMessage="Fyll i ett tal mellan 1 och 100." Text="*"
                MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>

            <%--SkickaKnapp--%>
            <p>
                <asp:Button ID="SendGuessButton" runat="server" Text="Skicka gissning"
                    OnClick="SendGuessButton_Click" />
            </p>
            <%--Presentation av resultat--%>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <asp:Label ID="FormerGuessesLabel" runat="server" Text="50, 25, 37" />
                <asp:Label ID="ResultLabel" runat="server" Text="Du vann" />
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
