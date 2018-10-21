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
        <p id="message">
            <!-- The following content will be replaced with the user name when you run the app - see App.js -->
            initializing...
        </p>
        <p id="message1"></p>
        <input type="button" id="press" value="DisplayData" />
        <input type="text" id="List" placeholder="EnterListName" />

         <input type="button" id="press1" value="CreateList" />

                    <p>Add Fields----------------------------------------------</p>
        <div>
            <input type="text" id="ListName"  placeholder="EnterListName" />
         <input type="text" id="Field"  placeholder="EnterFieldName" />
        <input type="text" id="FieldType" placeholder="EnterFieldKindType" />

         <input type="button" id="press4" value="AddField" />
        <br /></div>

        <br />
        <p>ADD LOOKUP FIELD</p>
          <input type="button" id="press5" value="AddField" />
           <input type="text" id="ListNameL"  placeholder="EnterListName" />
          <input type="text" id="FieldL"  placeholder="EnterFieldName" />



        <p>ADD ITEMS--------------------------------------------------------------</p>
        <div>
         <input type="text" id="ListNameI"  placeholder="EnterListName" />
         <input type="button" id="press2" value="AddItem" />
          <input type="text" id="FieldName" placeholder="FieldName" />
        <input type="text" id="Item"   placeholder="Item" />
       <%--   <input type="text" id="FieldName1" placeholder="FieldName1" />
        <input type="text" id="Item1" placeholder="Item1"  />--%>
            </div>
        <br />

        <input type="text" id="catid" placeholder="enter id"  /> 
          <input type="button" id="press3" value="DisplayItemBasedOnCategory" />
        <br/>
           <input type="button" id="press6" value="AddLookup" />
    </div>

</asp:Content>
