<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="practicaldd.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="EMPID" HeaderText="EMPID" SortExpression="EMPID" />
                <asp:BoundField DataField="MONTH" HeaderText="MONTH" SortExpression="MONTH" />
                <asp:BoundField DataField="SALARY" HeaderText="SALARY" SortExpression="SALARY" />
                <asp:BoundField DataField="EMPNAME" HeaderText="EMPNAME" SortExpression="EMPNAME" />
            </Columns>
        </asp:GridView>
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TBLEMPMST]"></asp:SqlDataSource>
        
        <br />
        <asp:Button ID="btn1" runat="server" Text="NEW" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn2" runat="server" Text="SAVE" OnClick="btn2_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn3" runat="server" Text="CLEAR" />
&nbsp;&nbsp;&nbsp;<br />
        <br />
        <asp:Button ID="btn4" runat="server" Text="CANCEL" OnClick="btn4_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn5" runat="server" Text="DELETE" OnClick="btn5_Click"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn6" runat="server" Text="REPORT" />
    <table border="1" style="border-collapse: collapse">
            <tr>
               
                <td style="width: 150px">EMP NAME
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="EMPNAME" DataValueField="EMPNAME" >
                     
                      <asp:ListItem Value="id">Please Select</asp:ListItem>  
                      
                       <asp:ListItem>abc</asp:ListItem>  
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
                <td style="width: 150px">MONTH
                     <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="MONTH" DataValueField="MONTH">
                     
                      <asp:ListItem Value="">Please Select</asp:ListItem>  
                       <asp:ListItem Value="JAN">JAN</asp:ListItem>  
                       <asp:ListItem Value="FEB">FEB</asp:ListItem>  
                         <asp:ListItem Value="MAR">MAR</asp:ListItem>  
                         <asp:ListItem Value="APR">APR</asp:ListItem>  
                             <asp:ListItem Value="MAY">MAY</asp:ListItem>  
                        
                      </asp:DropDownList>
                </td>
                 <td style="width: 150px">SALARY
                     <asp:TextBox ID="txt1" runat="server" />
                        
                     
                </td>
                
            </tr>
        </table>
   
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
   
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="QUERY" />
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList3" runat="server">
             <asp:ListItem Value="1">1</asp:ListItem>  
                       <asp:ListItem Value="2">2</asp:ListItem>  
                       <asp:ListItem Value="3">3</asp:ListItem>  
                         <asp:ListItem Value="4">4</asp:ListItem>  
                       
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>
   
    </div>
    </form>
</body>
</html>
