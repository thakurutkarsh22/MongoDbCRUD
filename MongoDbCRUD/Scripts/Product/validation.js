$(document).ready(function () {

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

// testing 

});

