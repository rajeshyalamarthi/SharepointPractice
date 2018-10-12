<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Weather.aspx.cs" Inherits="Weather.Weather" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 17px;
        }
    </style>
</head>
<body style="font-family:Arial, Helvetica, sans-serif">
<table>
    <tr>
        <td>city</td>
        <td><input type="text" id="txtcity"></td>
        </tr>
<tr>
    <td>Country</td>
    <td><input type="text" id="txtctry" class="auto-style1"></td>
</tr>
    
</table>

&nbsp;<div id="Resultdiv">

</div>
    <p>

<input type="button" id="btngetweather" value="GetWeatherData"></p>
</body>
</html>

