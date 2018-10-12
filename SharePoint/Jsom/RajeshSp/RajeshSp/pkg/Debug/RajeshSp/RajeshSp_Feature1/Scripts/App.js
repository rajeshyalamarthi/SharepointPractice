'use strict';

ExecuteOrDelayUntilScriptLoaded(initializePage, "sp.js");

function initializePage() {
    var context = SP.ClientContext.get_current();
    var user = context.get_web().get_currentUser();

    // This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model
    $(document).ready(function () {
        getUserName();
        //createlistitems();
        $("#press").click(Data);
        $("#press2").click(createlistitems);
        $("#press3").click(createlist);
        $("#press4").click(DisplayListsOnly);
        $("#press5").click(displaylistitems);
     
        //retrievelistitems();
    });

    // This function prepares, loads, and then executes a SharePoint query to get the current users information
    function getUserName() {
        context.load(user);
        context.executeQueryAsync(onGetUserNameSuccess, onGetUserNameFail);
    }

    // This function is executed if the above call is successful
    // It replaces the contents of the 'message' element with the user name
    function onGetUserNameSuccess() {
        $('#message').text('Hello ' + user.get_title());
    }

    // This function is executed if the above call fails
    function onGetUserNameFail(sender, args) {
        alert('Failed to get user name. Error:' + args.get_message());
    }


    // displaying lists and fields

    function Data() {
        var context = SP.ClientContext.get_current();
        var web = context.get_web();
        var lists = web.get_lists();
        //var list = context.get_web().get_lists().getByTitle('RajeshPracticeList');
        //var camlquery = new SP.CamlQuery();
        //camlquery.set_viewXml('<View><RowLimit>100</RowLimit></View>');

        //this.collListItem = list.getItems(camlquery);

        context.load(web, "Title", "Description");
        context.load(lists, "Include(Title,Fields.Include(Title))");
        //context.load(collListItem, 'Include(Id,DisplayName)');
        context.executeQueryAsync(success, fail);

        function success() {
            var info = jQuery("#message1");
            info.append(web.get_title());

            var listEnumerator = lists.getEnumerator();
            while (listEnumerator.moveNext()) {
                var listinfo = listEnumerator.get_current();
                info.append("<br />");
                info.append(listinfo.get_title());

                //var listFields = lists.get_fields();
                //clientContext.load(listFields);

                var listfiledinfo = listinfo.get_fields().getEnumerator();

                while (listfiledinfo.moveNext()) {
                    var field = listfiledinfo.get_current();
                    info.append("<br />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp");
                    info.append(field.get_title());


                }
            }
        }
        function fail(sender, args) {
            alert("Error Occured" + args.get_message());

        }


    }

    //Creating list items

    function createlistitems() {


        var context = SP.ClientContext.get_current();
        var web = context.get_web();
        try {
            var list = web.get_lists();
            var listname = list.getByTitle("DisplayInfoList");

            var itemcreateinfo = new SP.ListItemCreationInformation();
            var listitem = listname.addItem(itemcreateinfo);

            listitem.set_item("Title", "T-20");

            //listitem.set_item("LeagueName","IPL");
            listitem.set_item("TeamName", "Mumbai");
            listitem.set_item("Captain", "Sachin");


            listitem.update();
            context.executeQueryAsync(success, fail);
            //success();
            //fail();

            function success() {

                var message = jQuery("#message1");
                message.text("ItemAdded");

            }

            function fail(sender, args) {
                alert("call failed, Error: " + args.get_message());

            }



        }
        catch (ex) {
            alert(ex.message);
        }


    }





    //Creating lists using jsom

    function createlist() {

        var context = SP.ClientContext.get_current();
        var web = context.get_web();

        try {

            var Listcreation = new SP.ListCreationInformation();
            Listcreation.set_title("ProKabaddi");
            Listcreation.set_templateType(SP.ListTemplateType.contacts);

            var list = web.get_lists().add(Listcreation);

            //context.load(list);
            context.executeQueryAsync(success, fail);

        }
        

        catch (ex) {
            alert(ex.message);
        }


        function success() {

            var result = list.get_title() + "Created.";
            alert(result);

        }

        function fail(sender, args) {

            alert("error file not created:" + args.get_message());
        }

    }


    function DisplayListsOnly() {
        var context = SP.ClientContext.get_current();
        var web = context.get_web();

        try {

            var listdata = web.get_lists();
            context.load(listdata);
            context.executeQueryAsync(success, fail);
        }
        catch (ex) {

            alert("Lists not loaded:" +ex.message);
        }


        function success() {

            var displaylist = jQuery("#message2");
            var listcollection = listdata.getEnumerator();

            while (listcollection.moveNext()) {
                var a = listcollection.get_current();

                displaylist.append(a.get_title()+"<br/>");
            }
        }

        function fail(sender,args) {

            alert("error :" + args.get_message());
        }




    }



    // displaying listitems
    function displaylistitems() {

        var context = SP.ClientContext.get_current();
        var web = context.get_web();
        var listdata;

        try {

            listdata = web.get_lists();

            //var camlquery = new SP.CamlQuery();
            //camlquery.set_viewXml('<View><RowLimit>100</RowLimit></View>');

            //this.listitems = listdata.get_Items(camlquery);
            context.load(listdata);
            //context.load(listitem);
            context.executeQueryAsync(success, fail);



        }
        catch (ex) {
            alert(ex.message);
        }

        function success() {
            var info = jQuery("#message1");
            //var listiteminfo = '';
            var listEnum = listdata.getEnumerator();
            while (listEnum.moveNext()) {



                var currentlist = listEnum.get_current();

                info.append(currentlist.get_title());
                alert(" listenterd");

            var camlquery = new SP.CamlQuery();
            camlquery.set_viewXml('<View><RowLimit>100</RowLimit></View>');

                var listitems = currentlist.get_Items(camlquery);

                context.load(listitems);



                var listitemenum = listitems.getEnumerator();
                while (listitemenum.moveNext()) {

                    var currentlistitem = listitemenum.get_current();
                    info.append("<br/>");
                    info.append(currentlistitem.get_title());
                    alert(" item enterd");
                }


            }
        }

        function fail(sender, args) {
            alert("Cannot displayed:" + args.get_message());
        }




        }

    }


    


