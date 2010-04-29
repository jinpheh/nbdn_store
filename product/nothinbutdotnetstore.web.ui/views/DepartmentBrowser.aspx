<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="nothinbutdotnetstore.model" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
		     <% foreach (var department in ((IEnumerable<Department>)Context.Items["main_departments"]))
{
 %> 
        	<tr class="ListItem">
               		 <td>                     
                      <a href="SubDepartment.store?dept=<%= department.name %>"><%= department.name %></a>
                	</td>
           	 </tr>        
           	 <%
} %>
	    </table>            
</asp:Content>
