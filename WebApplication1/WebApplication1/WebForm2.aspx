<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="YourNamespace.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
</head>
<body>
    <form id="registrationForm" runat="server">
        <div>
            <label>Name:</label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." />

            <br />

            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="Invalid email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />

            <br />

            <label>Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." />

            <br />

            <label>Confirm Password:</label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtConfirmPassword"
                ControlToCompare="txtPassword" ErrorMessage="Passwords do not match." />
            
            <br />

            <label>Age:</label>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge"
                ErrorMessage="Age must be between 18 and 99." MinimumValue="18" MaximumValue="99" Type="Integer" />

            <br />

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>

 <!--- RegularExpressionValidator: As shown in the previous example, this control allows you to validate user input against a specific regular expression pattern. It is useful for validating complex data formats like email addresses, phone numbers, zip codes, etc.
aspx
 
<asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
<asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
    ErrorMessage="Invalid phone number format." ValidationExpression="^\d{10}$" />
CustomValidator: This control enables you to define your custom validation logic on both the client-side and server-side. You need to specify the client-side validation function and server-side validation event handler.
aspx
 
<asp:TextBox ID="txtCustomField" runat="server"></asp:TextBox>
<asp:CustomValidator ID="cvCustomField" runat="server" ControlToValidate="txtCustomField"
    ErrorMessage="Invalid value for custom field." ClientValidationFunction="validateCustomField" OnServerValidate="cvCustomField_ServerValidate" />
In JavaScript (for client-side validation):

javascript
 
function validateCustomField(sender, args) {
    var value = args.Value;
    // Perform custom client-side validation logic.
    args.IsValid = /* true or false based on validation logic */;
}
In code-behind (for server-side validation):

csharp
 
protected void cvCustomField_ServerValidate(object source, ServerValidateEventArgs args)
{
    string value = args.Value;
    // Perform custom server-side validation logic.
    args.IsValid = /* true or false based on validation logic */;
}
RangeValidator (for dates): You can use the RangeValidator control to validate dates within a specific range.
aspx
 
<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
<asp:RangeValidator ID="rvDate" runat="server" ControlToValidate="txtDate"
    ErrorMessage="Date must be between 2020 and 2023." MinimumValue="01/01/2020" MaximumValue="12/31/2023" Type="Date" />
Custom Validation Using ValidationSummary: You can use the ValidationSummary control to display a summary of all validation errors on the form.
aspx
 
<asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false" />
By setting ShowMessageBox="true", you can display a JavaScript alert for each validation error on the client-side.

These are just a few examples of the many validation controls ASP.NET offers. Depending on your specific requirements, you can mix and match these controls to create robust validation mechanisms for your web applications.-->