<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="practicaldd.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 150px;
            height: 92px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" >
            <Columns>
                  <asp:TemplateField>
                        <ItemTemplate>
                             <asp:LinkButton Text="Select" ID="lnkSelect" runat="server" CommandName="Select" />
                         </ItemTemplate>
                  </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" Visible="false" />
                <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                <asp:BoundField DataField="EMPID" HeaderText="EMPID" SortExpression="EMPID"  Visible="false"/>
                <asp:BoundField DataField="MONTH" HeaderText="MONTH" SortExpression="MONTH" />
                <asp:BoundField DataField="SALARY" HeaderText="SALARY" SortExpression="SALARY" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:divyaConnectionString %>" SelectCommand="SELECT TBLEMPMST.ID, TBLEMPMST.NAME, TBLSALARY.EMPID, TBLSALARY.MONTH, TBLSALARY.SALARY FROM TBLEMPMST INNER JOIN TBLSALARY ON TBLEMPMST.ID = TBLSALARY.ID"></asp:SqlDataSource>
   
        <br />
        <br />
        
        <br />
        <asp:Button ID="btn1" runat="server" Text="NEW" OnClick="btn1_Click"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn2" runat="server" Text="SAVE" OnClick="btn2_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn3" runat="server" Text="CANCEL"  />
&nbsp;&nbsp;&nbsp;<br />
        <br />
        <asp:Button ID="btn4" runat="server" Text="CANCEL"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn5" runat="server" Text="DELETE" OnClick="btn5_Click"    />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn6" runat="server" Text="REPORT" />
        <br />
        <br />
    <table border="1" style="border-collapse: collapse">
            <tr>
               
                <td class="auto-style1">NAME
                    <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource3" DataTextField="NAME" DataValueField="NAME">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:divyaConnectionString %>" SelectCommand="SELECT DISTINCT [NAME] FROM [TBLEMPMST]"></asp:SqlDataSource>
                </td>
                <td class="auto-style1">MONTH
                     <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource2" DataTextField="MONTH" DataValueField="MONTH">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:divyaConnectionString %>" SelectCommand="SELECT DISTINCT [MONTH] FROM [TBLSALARY]"></asp:SqlDataSource>
                </td>
                 <td class="auto-style1">SALARY
                     <asp:TextBox ID="txt1" runat="server" Text="0"/>
                     <br />
                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                  </td>       
                  
                     
               
                
            </tr>
        </table>
   
    </div>
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" >
                         <asp:ListItem Value="">Please Select</asp:ListItem>  
                        <asp:ListItem Value="1">1</asp:ListItem>  
                       <asp:ListItem Value="2">2</asp:ListItem>  
                       <asp:ListItem Value="3">3</asp:ListItem>  
                         <asp:ListItem Value="4">4</asp:ListItem>  
                       
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="GridView3" runat="server"  >
        </asp:GridView>
   
    </form>
</body>
</html>
