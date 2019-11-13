<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSellsReport.aspx.cs" Inherits="Easy_Shopping.ViewSellsReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            font-family: 'Muli', sans-serif;
        }
        .box {
      width: 250px;
      height: 620px;
      border: 1px solid #ccc;
      padding: 5px;
      margin: 5px;
      float: left;
      }
      .main{
      width: 900px;
      margin: 0 auto;
      }
      a {
          font-size:10pt;
          text-decoration:none;
          background-image: url("images/shopping-cart.svg");
          background-size: 14px 14px;
          background-repeat:no-repeat;
          background-position-x: right;
          padding-right: 20px;
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Xml ID="Xml1" runat="server"></asp:Xml>
            
        </div>
    </form>
