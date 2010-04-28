<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="nothinbutdotnetstore.hello.web._Default" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
</head>
<body>
    <form></form>
    <form action="DisplayTheName.ashx" method=post>
    <div>
      <table>
        <tr>
          <td><input type="text" name="person_name" /></td>
          <td><input type="submit" value="Save" /></td>
          <td></td>
        </tr>    
   
      </table> 
    </div>
    </form>
</body>
</html>
