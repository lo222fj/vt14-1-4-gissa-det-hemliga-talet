<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1_4_gissa_det_hemliga_talet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link href="Content/style.css" rel="stylesheet" />
    <script src="Content/script.js"></script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="SendGuessButton" defaultfocus="GuessTextBox">
        <div id="main">
            <h1>Gissa det hemliga talet</h1>
            <div id="ValidationDiv">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    CssClass="ErrorMessages" />
            </div>
            <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1 och 100: "></asp:Label>
            <%--Inputfält--%>
            <asp:TextBox ID="GuessTextBox" runat="server" TextMode="SingleLine" Enabled="True"></asp:TextBox>
            <%--Validering--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="Ett tal måste anges." Text="*" Display="Dynamic"
                ControlToValidate="GuessTextBox"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server"
                ControlToValidate="GuessTextBox" Display="Dynamic"
                ErrorMessage="Fyll i ett tal mellan 1 och 100." Text="*"
                MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>

            <%--SkickaKnapp--%>
            <asp:Button ID="SendGuessButton" CssClass="button" runat="server" Text="Skicka gissning"
                OnClick="SendGuessButton_Click" Enabled="True" />

            <%--Presentation av resultat--%>
           <div id="DisplayResult">
                <asp:Label ID="FormerGuessesLabel" runat="server" Text="" />
                <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
            </div>
            <p>
                <asp:Button ID="NewSecretNrButton" CssClass="button" runat="server" 
                    Text="Slumpa nytt hemligt tal" Visible="False" OnClick="NewSecretNrButton_Click" CausesValidation="False" />
            </p>
        </div>
    </form>
</body>
</html>
