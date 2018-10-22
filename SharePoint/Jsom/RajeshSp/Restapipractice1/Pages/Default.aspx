<%-- The following 4 lines are ASP.NET directives needed when using SharePoint components --%>

<%@ Page Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" MasterPageFile="~masterurl/default.master" Language="C#" %>

<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%-- The markup and script in the following Content element will be placed in the <head> of the page --%>
<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
    <SharePoint:ScriptLink name="sp.js" runat="server" OnDemand="true" LoadAfterUI="true" Localizable="false" />
    <meta name="WebPartPageExpansion" content="full" />

    <!-- Add your CSS styles to the following file -->
    <link rel="Stylesheet" type="text/css" href="../Content/App.css" />

    <!-- Add your JavaScript to the following file -->
    <script type="text/javascript" src="../Scripts/App.js"></script>
</asp:Content>

<%-- The markup in the following Content element will be placed in the TitleArea of the page --%>
<asp:Content ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Page Title
</asp:Content>

<%-- The markup and script in the following Content element will be placed in the <body> of the page --%>
<asp:Content ContentPlaceHolderID="PlaceHolderMain" runat="server">
  
    <div>
        <ul>
            <li> <a href="../Lists/ProductList1">LIST</a></li>

        </ul>
    </div>



    <div>
        <p id="message" style="color:forestgreen">
            <!-- The following content will be replaced with the user name when you run the app - see App.js -->
            initializing...
        </p>
     <%--   <p id="message1"></p>--%>
        <br />
        <input type="button" id="press" value="DisplayData" style="color:cornflowerblue" /> <br />
        <label id="Info1" style="font-size:larger;color:crimson"></label>
        <br />
        <p>Create List------------------------------------------------------------------------</p>
        <input type="text" id="List" placeholder="EnterListName" style="color:cornflowerblue" />

         <input type="button" id="press1" value="CreateList" style="color:cornflowerblue"/> <br />
        <label id="Info2" style="font-size:larger;color:crimson"></label>
        <br />

        <p>Add Fields--------------------------------------------------------------------------</p>
        <div>
        <input type="text" id="ListName"  placeholder="EnterListName" style="color:cornflowerblue"/>
        <input type="text" id="Field"     placeholder="EnterFieldName" style="color:cornflowerblue"/>
        <input type="text" id="FieldType" placeholder="EnterFieldKindType" style="color:cornflowerblue"/>

         <input type="button" id="press4" value="AddField" style="color:cornflowerblue"/> <br />
            <label id="Info3" style="font-size:larger;color:crimson"></label>
        <br />

        </div>

    <%--    <br />
        <p>ADD LOOKUP FIELD---------------------------------------------------------------------</p>
          <input type="button" id="press5" value="AddField" style="color:cornflowerblue"/>
           <input type="text" id="ListNameL"  placeholder="EnterListName" style="color:cornflowerblue" />
          <input type="text" id="FieldL"  placeholder="EnterFieldName" style="color:cornflowerblue"/>

        <br />--%>
        <br />

        <p>ADD ITEMS----------------------------------------------------------------------------</p>
        <div>
         <input type="text" id="ListNameI"  placeholder="EnterListName" style="color:cornflowerblue" />
          <input type="text" id="FieldName" placeholder="FieldName" style="color:cornflowerblue"/>
        <input type="text" id="Item"   placeholder="Item" style="color:cornflowerblue"/>
               <input type="button" id="press2" value="AddItem" style="color:cornflowerblue" /> <br />
                        <label id="Info4" style="font-size:larger;color:crimson"></label>

       <%--   <input type="text" id="FieldName1" placeholder="FieldName1" />
        <input type="text" id="Item1" placeholder="Item1"  />--%>
            </div>
        <br />

        <p>Filter Based On Id-------------------------------------------------------------------</p>
        <input type="text" id="catid" placeholder="enter id" style="color:cornflowerblue" /> 
          <input type="button" id="press3" value="DisplayItemBasedOnCategory"style="color:cornflowerblue" /> <br />
                    <label id="Info5" style="font-size:larger;color:crimson"></label>

        <br/>
        <p>Add Lookup Field---------------------------------------------------------------------</p>
         <input type="text" id="ListNamee" placeholder="enter ListName" style="color:cornflowerblue" /> 
         <input type="text" id="FiledName" placeholder="enter FieldName" style="color:cornflowerblue" /> 
        <input type="text" id="LookupListId" placeholder="enter LookupListId"style="color:cornflowerblue"  /> 
         <input type="text" id="LookupFieldName" placeholder=" enter LookupFieldName"style="color:cornflowerblue"  /> 
           <input type="button" id="press6" value="AddLookup" style="color:cornflowerblue"/> <br />
                    <label id="Info6" style="font-size:larger;color:crimson"></label>


    </div>
    <br />
    <p>FilterLookup-------------------------------------------------------------------------------</p>

     <%-- <input type="text" id="LookUpFilter" placeholder="enter CategoryName"  /> --%>
    <select id="DropDown" placeholder="Select CategoryName"style="color:cornflowerblue">
      <%--  <option id="1" value="Clothing">Clothing</option>
        <option id="2" value="FootWear">FootWear</option>
        <option id="3"  value="Beverages">Beverages</option>--%>
    </select>
        <input type="button" id="press7" value="FilterBycategoryName" style="color:cornflowerblue"/>
    <br />
    <label id="Info" style="font-size:larger;color:crimson"></label>
<%--    <p id="Info" style="color:salmon;font-size:larger"></p>--%>


</asp:Content>
