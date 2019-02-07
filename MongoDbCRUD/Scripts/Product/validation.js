/*$(document).ready(function () {

    // $("#button-submit").click(function(){
    //   $("#para").hide();
    // });

    
    var productdescription = $('#Pdis').val();
    var button = $("#button-submit");

    

    console.log("working")

   


    $("#button-submit").click(function () {
       
     //   event.preventDefault(); // default event prevent krta hai 
        var productname = $('#Pname').val();
        if (productname.length < 1) {
            console.log("if case")  
            alert("There is no value in textbox");  

           
            $('#Pname').after('<span class="error">This field is required</span>');
        } else {
            console.log("else case")
            //  alert("value in textbox"); 
            $("#button-submit").submit(); 
        }

        
    }
     
    )

    $('#Pname').val('');

    $('#Pname').on('focus', () => {
        $('.error').remove();
    });
    $('#Pdis').on('focus', () => {
        $('.error').remove();
    });



});
*/


var Global = {};
console.log("welcome")
Global.FormHelper = function (formElement, options, onSucccess, onError) {
    var settings = {};
    settings = $.extend({}, settings, options);
    console.log("This is thanos")
    formElement.validate(settings.validateSettings);
    formElement.submit(function (e) {
        if (formElement.valid()) {
            $.ajax(formElement.attr("action"), {
                type: "POST",
                data: formElement.serializeArray(),
                success: function (result) {
                    if (onSucccess === null || onSucccess === undefined) {
                        if (result.isSuccess) {
                            window.location.href = result.redirectUrl;
                        } else {
                            if (settings.updateTargetId) {
                                $("#" + settings.updateTargetId).html(result.data);
                            }
                            console.log("This is not thanos")
                        }
                    } else {
                        onSucccess(result);
                    }
                },
                error: function (jqXHR, status, error) {
                    if (onError !== null && onError !== undefined) {
                        onError(jqXHR, status, error);
                        $("#" + settings.updateTargetId).html(error);
                    }
                },
                complete: function () {
                }
            });
        }
        e.preventDefault();
    });

    return formElement;
};

