<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="practicaldd.WebForm2" %>

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
    <form id="form2" runat="server">

    <div>
        
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" >
            <Columns>
                <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton Text="Select" ID="lnkSelect" runat="server" CommandName="Select" />
            </ItemTemplate>
        </asp:TemplateField>
                  <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID"  Visible="true" ReadOnly="true"/>
                  <asp:BoundField DataField="EMPID" HeaderText="EMPID" SortExpression="EMPID" Visible="true" ReadOnly="true"/>
                <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                <asp:BoundField DataField="MONTH" HeaderText="MONTH" SortExpression="MONTH" />
                <asp:BoundField DataField="SALARY" HeaderText="SALARY" SortExpression="SALARY" />
                
            </Columns>
        </asp:GridView>
        
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:divyaConnectionString %>" SelectCommand="SELECT TBLEMPMST.ID, TBLEMPMST.NAME, TBLSALARY.EMPID, TBLSALARY.MONTH, TBLSALARY.SALARY FROM TBLEMPMST INNER JOIN TBLSALARY ON TBLEMPMST.ID = TBLSALARY.ID">
        </asp:SqlDataSource>
        
        <br />
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TBLSALARYMST]"></asp:SqlDataSource>
        
        <br />
        <asp:Button ID="btn1" runat="server" Text="NEW" OnClick="btn1_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn2" runat="server" Text="SAVE" OnClick="btn2_Click1"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn3" runat="server" Text="CANCEL" OnClick="btn3_Click" />
&nbsp;&nbsp;&nbsp;<br />
        <br />
        <asp:Button ID="btn4" runat="server" Text="CANCEL"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn5" runat="server" Text="DELETE" OnClick="btn5_Click"   />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn6" runat="server" Text="REPORT" />
    <table border="1" style="border-collapse: collapse">
            <tr>
               
                <td class="auto-style1">EMP NAME
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="EMPNAME" DataValueField="EMPNAME" Enabled="true">
                     
                      <asp:ListItem Value="id">Select</asp:ListItem>  
                      
                       <asp:ListItem>1</asp:ListItem>  
                         <asp:ListItem>2</asp:ListItem>  
                         <asp:ListItem>3</asp:ListItem>  
                             <asp:ListItem>4</asp:ListItem>  
                          <asp:ListItem>5</asp:ListItem> 
                          <asp:ListItem>6</asp:ListItem> 
                          <asp:ListItem>7</asp:ListItem> 
                          <asp:ListItem>8</asp:ListItem> 
                         
                      </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT ID, EMPID, MONTH, SALARY, EMPNAME FROM TBLSALARYMST WHERE EXISTS (SELECT ID, NAME, AGE FROM TBLEMPMST)"></asp:SqlDataSource>
                </td>
                <td class="auto-style1">MONTH
                     <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="MONTH" DataValueField="MONTH" Enabled="true">
                     
                      <asp:ListItem Value="">Select</asp:ListItem>  
                       <asp:ListItem Value="JAN">JAN</asp:ListItem>  
                       <asp:ListItem Value="FEB">FEB</asp:ListItem>  
                         <asp:ListItem Value="MAR">MAR</asp:ListItem>  
                         <asp:ListItem Value="APR">APR</asp:ListItem>  
                             <asp:ListItem Value="MAY">MAY</asp:ListItem>  
                        
                      </asp:DropDownList>
                </td>
                 <td class="auto-style1">SALARY
                     <asp:TextBox ID="txt1" runat="server" Text="0"/>
                        
                  
                     
                </td>
                
            </tr>
        </table>
   
        <br />
       
   
      
        <asp:Button ID="Button1" runat="server"  Text="QUERY" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" >
                         <asp:ListItem Value="">Please Select</asp:ListItem>  
                        <asp:ListItem Value="1">1</asp:ListItem>  
                       <asp:ListItem Value="2">2</asp:ListItem>  
                       <asp:ListItem Value="3">3</asp:ListItem>  
                         <asp:ListItem Value="4">4</asp:ListItem>  
                       
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="GridView3" runat="server" >
        </asp:GridView>
   
    </div>
    </form>
    
</body>
</html>
