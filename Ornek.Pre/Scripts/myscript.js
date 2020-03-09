function ProductAdd() {

    // unit price '.' to ','
    var str = document.getElementById("unit_price").value;
    var res = str.replace(".", ",");
    document.getElementById("unit_price").value = res;
  
 
    if ($("#btn").text() === "Kaydet") {
        
        var test = $("#frm-product").serialize();
        console.log(test)

        if ($("#_IsActive").is(":checked")) {

            test += "&IsActive=true";
        } else {
            test += "&IsActive=false";
        }


        try {

            $.ajax({
                type: "POST",
                url: "/Home/AddProduct",
                content: "application/json;",
                dataType: "json",
                data: test,
                async: true,
                success: function (result) {
                    console.log(result);
                    
                    if (result === true) {
                        added();
                        $("#PartialListProduts").load('/Home/Display_P');
                    }
                    else {
                        invalid();

                    }

                   

                },
                error: function (ex) {
                    console.log(ex);
                    alert("İşlem Başarısız" + ex);
                }
            }
            );
        }
        catch (e) {

            console.log("Hata : " + e);
        }
    }
    else if ($("#btn").text() === "Update") {
        var test = $("#frm-product").serialize();


        if ($("#_IsActive").is(":checked")) {

            test += "&IsActive=true";
        } else {
            test += "&IsActive=false";
        }
        var id = $("#_ProductID").val()

        test += "&ProductID="+id;


        try {

            $.ajax({
                type: "POST",
                url: "/Home/UpdateProduct",
                content: "application/json;",
                dataType: "json",
                data: test,
                async: true,
                success: function (result) {
                    updated();

                    $("#PartialListProduts").load('/Home/Display_P');

                },
                error: function (ex) {
                    console.log(ex);
                    alert("İşlem Başarısız" + ex);
                }
            }
            );
        }
        catch (e) {

            console.log("Hata : " + e);
        }

    }
}

function added() {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Product has been saved',
        showConfirmButton: false,
        timer: 1500
    })
    cleardata();
}

function ProductDelete(a) {

    
   
    try {

        $.ajax({
            type: "POST",
            url: "/Home/DeleteProduct",
            content: "application/json;",
            dataType: "json",
            data: {id:a},
            async: true,
            success: function (result) {


                if (result === true) {
                    deleted();
                    $("#PartialListProduts").load('/Home/Display_P');
                }
                else {
                    invalid();

                }
               

               

            },
            error: function (ex) {
                console.log(ex);
                alert("İşlem Başarısız" + ex);
            }
        }
        );
    }
    catch (e) {

        console.log("Hata : " + e);
    }
}

function deleted() {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Product has been deleted',
        showConfirmButton: false,
        timer: 1500
    })
    cleardata();
}

function updated() {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Product has been updated',
        showConfirmButton: false,
        timer: 1500
    })
    cleardata();
}

function ProductUpdate(a) {



    try {

        $.ajax({
            type: "GET",
            url: "/Home/GetProduct",
            content: "application/json;",
            dataType: "json",
            data: { id: a },
            async: true,
            success: function (result) {
                replace(result);
               

            },
            error: function (ex) {
                console.log(ex);
                alert("İşlem Başarısız" + ex);
            }
        }
        );
    }
    catch (e) {

        console.log("Hata : " + e);
    }
}
function replace(result) {
    popup();
    $("#ProductName").val(result.ProductName)
    $("#Barcode").val(result.Barcode)
    $("#unit_price").val(result.UnitPrice)
    $("#Stock_Quantity").val(result.StockQuantity)
    $("#Description").val(result.Description)
    if (result.IsActive === true) {
        $("#_IsActive").prop('checked', true);

    }
    else {

        $("#_IsActive").prop('checked', false);
    }
    $("#Category").val(result.Category);
    if ($("#btn").text() === "Kaydet") {
       
        $("#btn").text("Update");
        $("#btn").removeClass("btn-success");
        $("#btn").addClass("btn-warning");
    }
    else {
        $("#btn").text("Kaydet");
    }
    $("#_ProductID").val(result.ProductID)



}

function popup() {
    let timerInterval
    Swal.fire({
        title: 'Wait up!',
       
        timer: 300,
        timerProgressBar: true,
        onBeforeOpen: () => {
            Swal.showLoading()
            timerInterval = setInterval(() =>   {
                const content = Swal.getContent()
                if (content) {
                   
                }
            }, 100)
        },
        onClose: () => {
            clearInterval(timerInterval)
        }
    }).then((result) => {
        /* Read more about handling dismissals below */
        
    })
}

function cleardata() {
    $("#frm-product").trigger('reset');
    $("#btn").text("Kaydet");
    $("#btn").addClass("btn-success");
    $("#btn").removeClass("btn-warning");
}

function invalid() {

    Swal.fire({
        position: 'top-end',
        icon: 'error',
        title: ' Fields should be in valid form.',
        showConfirmButton: false,
        timer: 1500
    })

}