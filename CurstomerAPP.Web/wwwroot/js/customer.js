function initCustomer() {
    loadCustomersList();
    let myform = $("#create-customer-form");
    myform.submit(createCustomer);


}

function loadCustomersList() {
    let url = '/customers/List';
    $.ajax({
        //cache: false,
        async: true,
        type: "GET",
        url: url,
        success: function (response) {
            //limpia la el <div id ="resultado"> </div> y coloca el resultado
            $('#div-list-customer').html('');
            //Coloca la respuesta osea la vista
            $('#div-list-customer').html(response);
            $(".add-customerphone-js").click(loadCustomerPhoneCreate);
            $(".get-customerphone-js").click(loadCustomerPhoneDetails);
            $(".delete-customer-js").click(deleteCustomer);
            $(".edit-customer-js").click(loadCustomerEdit);
        }
    });
}

function loadCustomerEdit(e) {
    let button = $(e.currentTarget);
    let cId = button.data('cid');
    let url = `/customers/Edit/${cId}`;
    $.ajax({
        //cache: false,
        async: true,
        type: "GET",
        url: url,
        success: function (response) {
            $('#div-customerphone-modal').html('');
            //Coloca la respuesta osea la vista
            $('#div-customerphone-modal').html(response);
            let myform = $("#save-customer-form");
            myform.submit(editCustomer);
            $("#exampleModal").modal('show');
        }
    });
}

function loadCustomerPhoneCreate(e) {

    let button = $(e.currentTarget);
    let cId = button.data('cid');
    let url = `/customersPhones/create?cId=${cId}`;
    $.ajax({
        //cache: false,
        async: true,
        type: "GET",
        url: url,
        success: function (response) {
            //limpia la el <div id ="resultado"> </div> y coloca el resultado
            $('#div-customerphone-modal').html('');
            //Coloca la respuesta osea la vista
            $('#div-customerphone-modal').html(response);
            let cPhoneform = $("#save-customerphone-form");
            cPhoneform.submit(createCustomerPhone);
            $("#exampleModal").modal('show');

        }
    });
}

function loadCustomerPhoneDetails(e) {

    let button = $(e.currentTarget);
    //let cId = button.data('cid');
    let cId = button.data('cid');
    let url = `/customersPhones/details?cId=${cId}`;
    $.ajax({
        //cache: false,
        async: true,
        type: "GET",
        url: url,
        success: function (response) {
            //limpia la el <div id ="resultado"> </div> y coloca el resultado
            $('#div-customerphone-modal').html('');
            //Coloca la respuesta osea la vista
            $('#div-customerphone-modal').html(response);

            $("#exampleModal").modal('show');
        }
    });
}

function createCustomer(e) {
    if (e != undefined) {
        e.preventDefault();
    }
    var myform = $("#create-customer-form").serialize();
    var url = '/customers/create';
    $.ajax({
        cache: false,
        async: true,
        type: "POST",
        data: myform,
        url: url,
        success: function (response) {

            if (response.isSuccess === undefined) {
                //limpia la el <div id ="resultado"> </div> y coloca el resultado
                $('#div-customer-create').html('');
                //Coloca la respuesta osea la vista
                $('#div-customer-create').html(response);
                let myform = $("#create-customer-form");
                myform.submit(createCustomer);
                return;
            }
            if (response.isSuccess) {
                if (response.isSuccess) {
                    toastr.success(response.message);
                    loadCustomersList();
                    $(':input', '#create-customer-form')
                        .not(':button, :submit, :reset, :hidden')
                        .val('')
                        .prop('checked', false)
                        .prop('selected', false);
                } else {
                    toastr.error(response.message);
                }

            }
            $("#exampleModal").modal('hide');
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function editCustomer(e) {
    if (e != undefined) {
        e.preventDefault();
    }
    var myform = $("#save-customer-form").serialize();
    var url = `/customers/edit`;
    $.ajax({
        cache: false,
        async: true,
        type: "POST",
        data: myform,
        url: url,
        success: function (response) {

            if (response.isSuccess === undefined) {
                //limpia la el <div id ="resultado"> </div> y coloca el resultado
                $('#div-customerphone-modal').html('');
                //Coloca la respuesta osea la vista
                $('#div-customerphone-modal').html(response);
                let myform = $("#save-customer-form");
                myform.submit(editCustomer);
                return;
            }
            if (response.isSuccess) {
                if (response.isSuccess) {
                    toastr.success(response.message);
                    loadCustomersList();
                } else {
                    toastr.error(response.message);
                }

            }
            $("#exampleModal").modal('hide');
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function createCustomerPhone(e) {
    if (e != undefined) {
        e.preventDefault();
    }
    var myform = $("#save-customerphone-form").serialize();
    var url = '/customersphones/create';
    $.ajax({
        cache: false,
        async: true,
        type: "POST",
        data: myform,
        url: url,
        success: function (response) {

            if (response.isSuccess === undefined) {
                //limpia la el <div id ="resultado"> </div> y coloca el resultado
                $('#div-customerphone-modal').html('');
                //Coloca la respuesta osea la vista
                $('#div-customerphone-modal').html(response);
                let cPhoneform = $("#save-customerphone-form");
                cPhoneform.submit(createCustomerPhone);
                $("#exampleModal").modal('show');
                return;
            }
            if (response.isSuccess) {
                toastr.success(response.message);
            } else {
                toastr.error(response.message);
            }
            $("#exampleModal").modal('hide');
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function deleteCustomer(e) {

    let button = $(e.currentTarget);
    //let cId = button.data('cid');

    Swal.fire({
        title: '¿Desea eliminar este registro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar',
        cancelButtonText:'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {

            let cId = button.data('cid');
            var url = `/customers/delete/${cId}`;
            $.ajax({
                cache: false,
                async: true,
                type: "POST",
                url: url,
                success: function (response) {

                    if (response.isSuccess) {
                        toastr.success(response.message);
                        loadCustomersList();
                        Swal.fire(
                            'Deleted!',
                            'Your file has been deleted.',
                            'success'
                        );

                    } else {
                        toastr.error(response.message);
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
    })

}
