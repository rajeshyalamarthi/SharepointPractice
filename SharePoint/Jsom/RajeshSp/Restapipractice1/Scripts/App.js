'use strict';

ExecuteOrDelayUntilScriptLoaded(initializePage, "sp.js");

function initializePage() {
    var context = SP.ClientContext.get_current();
    var user = context.get_web().get_currentUser();

    // This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model
    $(document).ready(function () {
        getUserName();
        
        $("#press").click(title);
        $("#press1").click(CreateList);
        $('#press2').click(createlistitems);
        $('#press3').click(Productsbasedoncategory);
        $('#press4').click(AddField);
        $('#press6').click(AddLookupField);


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

    function title() {
        var titlecall = jQuery.ajax({
            url: _spPageContextInfo.webAbsoluteUrl + "/_api/Web/?$select=Title",
            type: "GET",
            dataType: "json",
            headers: {
                Accept: "application/json;odata=verbose"
            }

        });
        var call2 = jQuery.ajax({
            url: _spPageContextInfo.webAbsoluteUrl + "/_api/Web/Lists?$select=Title,id",
            type: "GET",
            dataType: "json",
            headers: {
                Accept: "application/json;odata=verbose"
            }
        });

        //var call3 = jQuery.ajax({
        //    url: _spPageContextInfo.webAbsoluteUrl + "/_api/Web/lists/GetByTitle('Scores')/items/?$select=Title&$filter=ID gt" + lastMessageID,
        //    type: "GET",
        //    dataType="json",
        //    headers: {
        //        Accept: "application/json;odata=verbose"
        //    }
        //});

        var calls = jQuery.when(titlecall, call2);
        calls.done(function (callback1, callback2) {

            var message = jQuery("#message1");
            message.text("Lists in " + callback1[0].d.Title);
            message.append("<br/>");
            jQuery.each(callback2[0].d.results, function (index, value) {
                message.append(String.format("List Name = {0},id= {1}",
                    value.Title, value.Id));

                message.append("<br/>");

                //jQuery.each(callback3[0].d.results, function (index, value) {
                //    message.append(String.format("Field Name = {0}",
                //        value.title));

                //});
            });
        });

        calls.fail(function (jqXHR, textStatus, errorThrown) {
            var response = JSON.parse(jqXHR.responseText);
            var message = response ? response.error.message.value : textStatus;
            alert("call failed.Error:" + message);
        });
    }


    function CreateList() {
        var name = $('#List').val();
        var call = jQuery.ajax({
            url: _spPageContextInfo.webAbsoluteUrl + "/_api/Web/Lists",
            type: "POST",
            data: JSON.stringify({
                "__metadata": { type: "SP.List" },
                BaseTemplate: SP.ListTemplateType.tasks,
                Title: name
            }),

            headers: {
                Accept: "application/json;odata=verbose",
                "Content-Type": "application/json;odata=verbose",
                "X-RequestDigest": jQuery("#__REQUESTDIGEST").val()
            }
        });
        var message = jQuery("#message1");
        call.done(function (data, textStatus, jqXHR) {
            message.text("List added");
        });
        call.fail(function (jqXHR, textStatus, errorThrown) {
            var response = JSON.parse(jqXHR.responseText);
            var message = response ? response.error.message.value : textStatus;
            alert("Call failed. Error: " + message);
        });
    }



    //--------------------------------------------------------------------------------------

    function AddField() {
        var FieldL = $('#FieldL').val();
        //var Ktype = $('#FieldType').val();
        var ListNameL = $('#ListNameL').val();


        var call = jQuery.ajax({
            url: _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/getByTitle( '" + ListNameL + "')/Fields",
            type: "POST",
            data: JSON.stringify({

                "__metadata": { type: "SP.Field" },
                Title: lname,
                FieldTypeKind: Ktype,
                Required: "true",
                StaticName: lname


            }),

            headers: {
                Accept: "application/json;odata=verbose",
                "Content-Type": "application/json;odata=verbose",
                "X-RequestDigest": jQuery("#__REQUESTDIGEST").val()
            }

        });

        var message = jQuery("#message1");
        call.done(function (data, textStatus, jqXHR) {
            message.text("Filed added");
        });
        call.fail(function (jqXHR, textStatus, errorThrown) {
            var response = JSON.parse(jqXHR.responseText);
            var message = response ? response.error.message.value : textStatus;
            alert("Call failed. Error: " + message);
        });
    }




    function AddLookupField() {
        alert("AddLookupField");
        var lname = $('#Field').val();
        var Ktype = $('#FieldType').val();
        var ListName = $('#ListName').val();


        var call = jQuery.ajax({
            url: _spPageContextInfo.webAbsoluteUrl + "_api/web/lists/getByTitle(ProductInfo)/fields/addfield",
            type: "POST",
            //data: "{ 'parameters': { '__metadata': { 'type': 'SP.FieldCreationInformation' },'FieldTypeKind': 7, 'Title': 'CategorySelect', 'LookupListId': '9dcd157f-4c28-40d1-aaf9-2845426fccc1','LookupFieldName': 'Title'}} "
            //,
            data: JSON.stringify({
                __metadata: {
                    type: "SP.FieldCreationInformation"
                },
                FieldTypeKind: 7,
                Title: "CategorySelect",
               LookupListId: "9dcd157f-4c28-40d1-aaf9-2845426fccc1",
                LookupFieldName: "Title"
            }),

        
            headers: {
                "X-RequestDigest": jQuery("#__REQUESTDIGEST").val(),
                accept: "application/json;odata=verbose",
                "content-type": "application/json;odata=verbose",
                "content-length": 1024

            }
        });
        var message = jQuery("#message1");
        call.done(function (data, textStatus, jqXHR) {
            alert("lookup created");
            message.text("Filed added");
        });
        call.fail(function (jqXHR, textStatus, errorThrown) {
            alert("lookup error");
            var response = JSON.parse(jqXHR.responseText);
            var message = response ? response.error.message.value : textStatus;
            alert("Call failed. Error: " + message);
        });
    }







    //---------------------------------------------------------------------

    //function createlistitems() {

    //    var call = jQuery.ajax({
    //        url: _spPageContextInfo.webAbsoluteUrl + "/_api/Web/Lists/getByTitle('ProductList')/Items",
    //        type: "POST",

    //        data: JSON.stringify({
    //            " __metadata": { type: 'SP.Data.customlistListItem' },
    //            ProductsId: 1,
    //            ProductsName: 'Apple',

    //        }),
    //        headers: {
    //            "accept": "application/json;odata=verbose",
    //            "X-RequestDigest": $("#__REQUESTDIGEST").val(),
    //            "content-Type": "application/json;odata=verbose"
    //        },
    //    });
    //    var message = jQuery("#message1");
    //    call.done(function (data, textStatus, jqXHR) {
    //        message.text("Filed added");
    //    });
    //    call.fail(function (jqXHR, textStatus, errorThrown) {
    //        var response = JSON.parse(jqXHR.responseText);
    //        var message = response ? response.error.message.value : textStatus;
    //        alert("Call failed. Error: " + message);
    //    });
    //}

    //    success: function (data) {
    //        //console.log(data);
    //        alert('added');



    //    },
    //    error: function (error) {
    //        //alert(JSON.stringify(error));
    //        alert('Some error occured. Please try again later.');
    //    }
    //});


    //    var call = jQuery.ajax({
    //        url: _spPageContextInfo.webAbsoluteUrl + "/_api/Web/Lists/getByTitle('ProductList')/Fields/getByTitle('ID')",
    //        type: "POST",
    //        data: JSON.stringify({
    //            "__metadata": { type: "SP.Data.TasksListItem" },
    //            Title: 1,
    //            //AssignedToId: userId,
    //            //DueDate: due
    //        }),
    //        headers: {
    //            Accept: "application/json;odata=verbose",
    //            "Content-Type": "application/json;odata=verbose",
    //            "X-RequestDigest": jQuery("#__REQUESTDIGEST").val()
    //        }
    //    });
    //    call.done(function (data, textStatus, jqXHR) {
    //        var div = jQuery("#message");
    //        div.text("Item added");
    //    });
    //    call.fail(function (jqXHR, textStatus, errorThrown) {
    //        failHandler(jqXHR, textStatus, errorThrown);
    //    });

    //}




    //    var context = SP.ClientContext.get_current();
    //    var web = context.get_web();
    //    try {
    //        var list = web.get_lists();
    //        var listname = list.getByTitle("ProductList");

    //        var itemcreateinfo = new SP.ListItemCreationInformation();
    //        var listitem = listname.addItem(itemcreateinfo);


    //        listitem.set_item("ID", "1");

    //        //listitem.set_item("LeagueName","IPL");
    //        listitem.set_item("ProductsName", "Mango");



    //        listitem.update();
    //        context.executeQueryAsync(success, fail);
    //        //success();
    //        //fail();

    //        function success() {

    //            var message = jQuery("#message1");
    //            message.text("ItemAdded");

    //        }

    //        function fail(sender, args) {
    //            alert("call failed, Error: " + args.get_message());

    //        }



    //    }
    //    catch (ex) {
    //        alert(ex.message);
    //    }


    //}





    function createlistitems() {
        var Fieldname = $('#FieldName').val();
        var Item = $('#Item').val();
        var Fieldname1 = $('#FieldName1').val();
        var Item1 = $('#Item1').val();
        var ListNameI = $('#ListNameI').val();


        var context = SP.ClientContext.get_current();
        var web = context.get_web();
        try {
            var list = web.get_lists();
            var listname = list.getByTitle(ListNameI);

            var itemcreateinfo = new SP.ListItemCreationInformation();
            var listitem = listname.addItem(itemcreateinfo);

            listitem.set_item(Fieldname, Item);

            //listitem.set_item("LeagueName","IPL");
            //listitem.set_item(Fieldname1, Item1);
            //listitem.set_item("Captain", "Sachin");


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



















    //-------------------------------------------------------binding
    function Productsbasedoncategory() {
        //var categoryId = $('#catid').val();
        var id = $('#catid').val();
        alert("id given :" + id);
        var call = jQuery.ajax({


            url: _spPageContextInfo.webAbsoluteUrl + "/_api/Web/Lists/getByTitle('ProductList1')/Items/?$select=ProductName,ProductId/ProductName&$filter=(ProductId eq '" + id + "')",     // &$expand=ProductsName/ProductsId

            type: "GET",
            dataType: "json",
            headers: {
                Accept: "application/json;odata=verbose"
            }
        });

        call.done(function (data) {
            var message = jQuery("#message1");
            //message.append("<br/>");
            jQuery.each(data.d.results, function (index, value) {
                message.append(String.format("Products Name = {0} " + "<br/> ",
                    value.ProductName));


            });
        });


        call.fail(function (jqXHR, textStatus, errorThrown) {
            var response = JSON.parse(jqXHR.responseText);
            var message = response ? response.error.message.value : textStatus;
            alert("Call failed. Error: " + message);
        });
    }
}






