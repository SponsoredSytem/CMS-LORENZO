//add data in contacts table row from popup
$('#CompanyContactsSave').on("click", function () {
    //validate fields
    if (!(validateEmail('#ccEmail') && ValidateFieldsByClass("mandatoryModal"))) {
        return false;
    }
    var Fname = $("#ccFirstName").val();
    var Lname = $("#ccLastName").val();
    var Position = $("#ccPosition").val();
    var Cell = $("#ccCell").val();
    var Email = $("#ccEmail").val();
    var Type = $("#ccContactType").val();
    //var index = $("#CompanyContactsTableBody").children("tr").length;
    var index = $("#ContactModalIndex").val();

    var contactType = Type == 1 ? "Primary" : Type == "" ? "" : "Secondary";

    if (index == "") {
        //add new row

        if ($("#CompanyContactsTableBody").children("tr").children("td").html() == "No data available in table") {
            index = index - 1;
            $("#CompanyContactsTableBody").children("tr").remove();
        }
        var indexCell = "<td style='display:none'>" +
            "<input name='CompanyContacts.Index' type='hidden' value='" + index + "' />" +
            "<input name='CompanyContacts[" + index + "].CompanyContactId' id='CompanyContacts_" + index + "__CompanyContactId' type='hidden' />" +
            "<input name='CompanyContacts[" + index + "].CompanyId' id='CompanyContacts_" + index + "__CompanyId' type='hidden' />" +
            "</td>";
        
        //CompanyContacts
        var html = ' <tr data-id=' + index + '>' +
            indexCell +
            '<td>' +
            '<input id="CompanyContacts_' + index + '__FirstName" name="CompanyContacts[' + index + '].FirstName" type="hidden" value="' + Fname + '"><span id="spanFirstName_' + index + '">' + Fname + '</span>' +
            '</td>' +
            '<td>' +
            '<input id="CompanyContacts_' + index + '__LastName" name="CompanyContacts[' + index + '].LastName" type="hidden" value="' + Lname + '"><span id="spanLastName_' + index + '">' + Lname + '</span>' +
            '</td>' +
            '<td>' +
            '<input id="CompanyContacts_' + index + '__Position" name="CompanyContacts[' + index + '].Position" type="hidden" value="' + Position + '"><span id="spanPosition_' + index + '">' + Position + '</span>' +
            '</td>' +
            '<td>' +
            '<input id="CompanyContacts_' + index + '__PhoneCell" name="CompanyContacts[' + index + '].PhoneCell" type="hidden" value="' + Cell + '"><span id="spanPhoneCell_' + index + '">' + Cell + '</span>' +
            '</td>' +
            '<td>' +
            '<input id="CompanyContacts_' + index + '__Email" name="CompanyContacts[' + index + '].Email" type="hidden" value="' + Email + '"><span id="spanEmail_' + index + '">' + Email + '</span>' +
            '</td>' +
            '<td>' +
            '<input id="CompanyContacts_' + index + '__ContactType" name="CompanyContacts[' + index + '].ContactType" type="hidden" value="' + Type + '"><span id="spanContactType_' + index + '">' + contactType + '</span>' +
            '</td>' +
            '<td><a href="javascript:;" class="editContact">Edit</a></td>' +
            '<td><a href="javascript:;" class="deleteRow" title="Delete">X</a></td>' +
            '</tr>';
        $('#CompanyContactsTableBody').append(html);
    } else {
        //change input text value
        $("#CompanyContacts_" + index + "__FirstName").val(Fname);
        $("#CompanyContacts_" + index + "__LastName").val(Lname);
        $("#CompanyContacts_" + index + "__Position").val(Position);
        $("#CompanyContacts_" + index + "__PhoneCell").val(Cell);
        $("#CompanyContacts_" + index + "__Email").val(Email);
        $("#CompanyContacts_" + index + "__ContactType").val(Type);
        //change rows values, that are being displayed
        $("#spanFirstName_" + index).text(Fname);
        $("#spanLastName_" + index).text(Lname);
        $("#spanPosition_" + index).text(Position);
        $("#spanPhoneCell_" + index).text(Cell);
        $("#spanEmail_" + index).text(Email);
        $("#spanContactType_" + index).text(contactType);
    }

    $("#ContactModal").modal('toggle');
    $('#ContactModalForm').trigger("reset");
    ////remove validation
    //$("form").removeData("validator").removeData("unobtrusiveValidation");

    ////Parse the form again to apply new validations
    //$.validator.unobtrusive.parse("form");
});

//Load popup for contacts table row's data
$('.editContact').live('click', function () {
    //get the id from tr that is selected for the item popup
    var index = $(event.target).closest('tr').data('id');
    //save index in model
    $("#ContactModalIndex").val(index);
    //get item's values
    var ccFirstName = $("#CompanyContacts_" + index + "__FirstName").val();
    var ccLastName = $("#CompanyContacts_" + index + "__LastName").val();
    var ccPosition = $("#CompanyContacts_" + index + "__Position").val();
    var ccCell = $("#CompanyContacts_" + index + "__PhoneCell").val();
    var ccEmail = $("#CompanyContacts_" + index + "__Email").val();
    var ccContactType = $("#CompanyContacts_" + index + "__ContactType").val();

    $("#ccFirstName").val(ccFirstName);
    $("#ccLastName").val(ccLastName);
    $("#ccPosition").val(ccPosition);
    $("#ccCell").val(ccCell);
    $("#ccEmail").val(ccEmail);
    $("#ccContactType").val(ccContactType);

    $("#ContactModal").modal('toggle');
});

//delete company contact table row
$('.deleteRow').live("click", function () {
    var count = $("#CompanyContactsTableBody").children("tr").length;
    if (count > 0) {
        var contact = $("#DeletedCompanyContacts").val();
        var contactToBeDeleted = $(this).parent().parent().children("input").first().attr("value");
        if (contactToBeDeleted != undefined) {
            if (contact == "") {
                contact = contactToBeDeleted;
            } else {
                contact = contact + "," + contactToBeDeleted;
            }

            $("#DeletedCompanyContacts").val(contact);
        }
        $(this).parent().parent().remove();
    }
});


//add data in company notes table row from modal
$('#CompanyNotesSave').on("click", function () {
    //validate fields
    if (!(ValidateFieldsByClass("mandatoryCnModal"))) {
        return false;
    }
    var reminderDate = $("#cnReminderDate").val();
    var actionDate = $("#cnActionDate").val();
    var noteType = $("#cnType").val();
    var noteTypeName = $("#cnType option:selected").text();
    var noteDescription = $("#cnDescription").val();

    var index = $("#NotesModalIndex").val();

    if (index == "") {
        //add new row

        if ($("#CompanyNotesTableBody").children("tr").children("td").html() == "No data available in table") {
            index = index - 1;
            $("#CompanyNotesTableBody").children("tr").remove();
        }
        var indexCell = "<td style='display:none'>" +
            "<input name='CompanyNotes.Index' type='hidden' value='" + index + "' />" +
            "<input name='CompanyNotes[" + index + "].Id' id='CompanyNotes_" + index + "__Id' type='hidden' />" +
            "<input name='CompanyNotes[" + index + "].CompanyId' id='CompanyNotes_" + index + "__CompanyId' type='hidden' />" +
            "</td>";

        //CompanyNotes
        var html = ' <tr data-id=' + index + '>' +
            indexCell +
            '<td>' +
            '<input id="CompanyNotes_' + index + '__NotesDate" name="CompanyNotes[' + index + '].NotesDate" type="hidden" value="' + actionDate + '"><span id="spanActionDate_' + index + '">' + actionDate + '</span>' +
            '</td>' +
            '<td>' +
            '<input id="CompanyNotes_' + index + '__ReminderDate" name="CompanyNotes[' + index + '].ReminderDate" type="hidden" value="' + reminderDate + '"><span id="spanReminderDate_' + index + '">' + reminderDate + '</span>' +
            '</td>' +
            '<td>' +
            '<input id="CompanyNotes_' + index + '__NotesCategoryId" name="CompanyNotes[' + index + '].NotesCategoryId" type="hidden" value="' + noteType + '"><span id="spanNoteTypeName_' + index + '">' + noteTypeName + '</span>' +
            '</td>' +
            '<td>' +
            '<input id="CompanyNotes_' + index + '__Description" name="CompanyNotes[' + index + '].Description" type="hidden" value="' + noteDescription + '"><span id="spanNoteDescription_' + index + '">' + noteDescription + '</span>' +
            '</td>' +
            
            '<td><a href="javascript:;" class="editNote">Edit</a></td>' +
            '<td><a href="javascript:;" class="deleteNote" title="Delete">X</a></td>' +
            '</tr>';
        $('#CompanyNotesTableBody').append(html);
    } else {
        //change input text value
        $("#CompanyNotes_" + index + "__NotesDate").val(actionDate);
        $("#CompanyNotes_" + index + "__ReminderDate").val(reminderDate);
        $("#CompanyNotes_" + index + "__NotesCategoryId").val(noteType);
        $("#CompanyNotes_" + index + "__Description").val(noteDescription);
        //change rows values, that are being displayed
        $("#spanActionDate_" + index).text(actionDate);
        $("#spanReminderDate_" + index).text(reminderDate);
        $("#spanNoteTypeName_" + index).text(noteTypeName);
        $("#spanNoteDescription_" + index).text(noteDescription);
    }

    $("#NotesModal").modal('toggle');
    $('#NotesModalForm').trigger("reset");
    
    ////remove validation
    //$("form").removeData("validator").removeData("unobtrusiveValidation");

    ////Parse the form again to apply new validations
    //$.validator.unobtrusive.parse("form");
});

//Load popup for notes table row's data
$('.editNote').live('click', function () {
    //get the id from tr that is selected for the item popup
    var index = $(event.target).closest('tr').data('id');
    //save index in model
    $("#NotesModalIndex").val(index);
    //get item's values

    $("#cnReminderDate").val($("#CompanyNotes_" + index + "__NotesDateString").val());
    $("#cnActionDate").val($("#CompanyNotes_" + index + "__ReminderDateString").val());
    $("#cnType").val($("#CompanyNotes_" + index + "__NotesCategoryId").val());
    $("#cnDescription").val($("#CompanyNotes_" + index + "__Description").val());
    $("#NotesModal").modal('toggle');
});

//delete company note table row
$('.deleteNote').live("click", function () {
    var count = $("#CompanyNotesTableBody").children("tr").length;
    if (count > 0) {
        var note = $("#DeletedCompanyNotes").val();
        var noteToBeDeleted = $(this).parent().parent().children("input").first().attr("value");
        if (noteToBeDeleted != undefined) {
            if (note == "") {
                note = noteToBeDeleted;
            } else {
                note = note + "," + noteToBeDeleted;
            }

            $("#DeletedCompanyNotes").val(note);
        }
        $(this).parent().parent().remove();
    }
});


$('#IsCompany').change(function () {
    DisplayRelatedFields($(this).is(':checked'));
});

$(".Telephone").mask("9999-999-99-99");

function ValidationPageFields() {
    var custom = ValidateFieldsByClass(window.classToBeValidate);
    var common = ValidateFields(event);
    if (custom && common) {
        return true;
    }
    return false;
}

function DisplayRelatedFields(value) {
    if (value) {
        $(".individual").hide();
        $(".CompanyRelatedInformation").show();
        window.classToBeValidate = "mandatoryCompany";
    } else {
        $(".individual").show();
        $(".CompanyRelatedInformation").hide();
        window.classToBeValidate = "mandatoryIndividual";
    }
}

function LoadMuniciaplByCity() {
    var code = $("#CityId").val();
    if (code == "") {
        $("#MunicipalId").empty();
        var newOption = "<option value='0'> Select Municipal </option>";
        $("#MunicipalId").append(newOption);
        return;
    }
    $.blockUI({ message: '<h3><img src="' + hostURL + '/Images/loading.gif" height=55px; width=55px; /> Fetching Municipals...</h2>' });

    if (code != "" && code != "0") {
        var selectedMunicipal = '@Model.Company.MunicipalId';
        $.ajax({
            url: hostURL + "/Api/Municipal",
            type: "GET",
            data: { id: code },
            dataType: "json",
            success: function (data) {
                $("#MunicipalId").empty();
                $.each(data, function (i, item) {
                    var selection = "";//(selectedMunicipal == item.MunicipalId) ? 'selected' : '';
                    var newOption = "<option value='" + item.MunicipalId + "' " + selection + ">" + item.MunicipalName + "</option>";
                    $("#MunicipalId").append(newOption);
                });
                $("#MunicipalId").val(selectedMunicipal).change();
                $.unblockUI();
            },
            error: function (textStatus, errorThrown) {
                $.unblockUI();
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);
            }
        });
    }
}