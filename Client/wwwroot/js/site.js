// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*var judul = document.getElementById("judul");*/

var data = document.getElementById("title");
var data2 = document.getElementsByClassName("list");
var data3 = document.querySelector("li.list2");
var data4 = document.getElementById("list3");

chartGender();
chartUniversity();
chartSalary();  


//const animals = [
//  { name: 'bimo', species: 'cat', kelas: { name: 'mamalia' } },
//  { name: 'budi', species: 'cat', kelas: { name: "mamalia" } },
//  { name: 'nemo', species: 'snail', kelas: { name: "invertebrata" } },
//  { name: 'dori', species: 'cat', kelas: { name: "mamalia" } },
//  { name: 'simba', species: 'snail', kelas: { name: "invertebrata" } }
//]
//let OnlyCat = [];

//for (var i = 0; i < animals.length; i++) {
//   if (animals[i].species == 'cat') {
//        OnlyCat.push(animals[i]);
//    }
//    else {
//        animals[i].kelas.name = 'non-animalia';
//    }
//}

//console.log(OnlyCat);
//console.log(animals);

//dari DONY
//let animals = [
//    { name: "bimo", species: "cat", class: { name: "mamalia" } },
//    { name: "budi", species: "cat", class: { name: "mamalia" } },
//    { name: "nemo", species: "snail", class: { name: "invertebrata" } },
//    { name: "dori", species: "cat", class: { name: "mamalia" } },
//    { name: "simba", species: "snail", class: { name: "invertebrata" } }
//]

//let OnlyCat = [];
//for (let i = 0; i < animals.length; i++) {
//    if (animals[i].species == "cat") {
//        OnlyCat.push(animals[i]);
//    }
//}

//for (let i = 0; i < animals.length; i++) {
//    if (animals[i].class.name == "invertebrata") {
//        animals[i].class.name = "Non-Mamalia";
//    }
//}

//punya JAKI

//const animals = [
//    { name: 'bimo', species: 'cat', kelas: { name: "mamalia" } },
//    { name: 'budi', species: 'cat', kelas: { name: "mamalia" } },
//    { name: 'nemo', species: 'snail', kelas: { name: "invertebrata" } },
//    { name: 'dori', species: 'cat', kelas: { name: "mamalia" } },
//    { name: 'simba', species: 'snail', kelas: { name: "invertebrata" } }
//]
//let onlyCat = [];
//for (var i = 0; i < animals.length; i++) {
//    if (animals[i].species == "cat") {
//        onlyCat.push(animals[i]);
//    }
//    else {
//        animals[i].kelas.name = 'non-mamalia';
//    }
//}
//console.log("Only Cat");
//for (let i = 0; i < onlyCat.length; i++) {
//    console.log(onlyCat[i]);
//}
//console.log("New Animals");
//for (let i = 0; i < animals.length; i++) {
//    console.log(animals[i]);
//}

//MENGUBAH WARNA 

//var el_up = document.getElementById('GFG_UP');
//var rgbValue = [255, 0, 0];
//el_up.innerHTML =
//    "Click on the button to select effective pattern.";

//function setColor() {
//    rgbValue[0] = Math.round(Math.random() * 255);
//    rgbValue[1] = Math.round(Math.random() * 255);
//    rgbValue[2] = Math.round(Math.random() * 255);
//    var color = Math.round(((parseInt(rgbValue[0]) * 299) +
//        (parseInt(rgbValue[1]) * 587) +
//        (parseInt(rgbValue[2]) * 114)) / 1000);
//    var textColor = (color > 125) ? 'black' : 'white';
//    var backColor =
//        'rgb(' + rgbValue[0] + ', ' + rgbValue[1] + ', '
//        + rgbValue[2] + ')';

//    $('.row .col #row').css('color', textColor);
//    $('.row .col #row').css('background-color', backColor);
//}

//function GFG_Fun() {
//    setColor();
//}


/*MATERI AJAX*/
//$.ajax({
//    url: "https://pokeapi.co/api/v2/pokemon/"
//}).done((result) => {
//    console.log(result.results);
//    var text = "";
//    $.each(result.results, function (key, val) {
//        text += `<tr>    
//                <td> ${key + 1}</td>     
//                <td>${val.name}</td>   
//                <td><button type="button" value= "${val.url}" onclick="getData2(this.value)" class="btn btn-primary" data-toggle="modal" data-target="#getPoke">Detail</button></td>
                
//        </tr > `;

//    });
//    console.log(text);
//    $(".tabelPoke").html(text);
//     $(".pokeModal").html(url);

//}).fail((error) => {
//    console.log(error);
//});








/*======================================LOGIN==========================================*/
//function loginUser() {
//    var obj = new Object();
//    obj.Email = $("#InputEmail").val();
//    obj.Password = $("#InputPassword").val();
//    $.ajax({
//        url: 'Account/Login',
//        type: 'post',
//        data: obj,
//    }).done(result => {
//        console.log(result)
//        if (result.message == "Login Success") {
//            window.location.href = "https://localhost:44332/Employees"
//        } else {
//            Swal.fire({
//                icon: 'error',
//                title: result.message,
//            });
//        }
//    }).fail(error => {
//        Swal.fire({
//            icon: 'error',
//            title: 'Registrasi Gagal',
//            text: error.message,
//        });
//    });
//}

/*================================Show Data Table================================*/

//$(document).ready(function () {
//    $('#TableEmployee').DataTable({
//        dom: 'Bfrtip',
//        buttons: [
//            'copy', 'csv', 'excel', 'pdf', 'print'
//        ]
//    });
//});
/*var table = "";*/

$(document).ready(function () {
    table = $('#TableEmployee').DataTable({
        responsive: true,
        "dom": 'Bfrtip',
        "buttons": [
            {
                extend: 'copyHtml5',
                text: '<i class="fa fa-files-o"> <b>COPY</b> </i>',
                titleAttr: 'Copy'
            },
            {
                extend: 'excelHtml5',
                text: '<i class="fa fa-file-excel-o"> <b>EXCEL</b> </i>',
                titleAttr: 'Excel',
                exportOptions: {
                    columns: [0,1,2,3,4,5,6]
                }
            },
            {
                extend: 'csvHtml5',
                text: '<i class="fa fa-file-csv"> <b>CSV</b> </i>',
                titleAttr: 'CSV',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                }
            },
            {
                extend: 'pdfHtml5',
                text: '<i class="fa fa-file-pdf-o"> <b>PDF</b> </i>',
                titleAttr: 'PDF',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                }
            }
        ],
        'ajax': {
          
            'url': "Employees/GetRegisteredData",
            'dataType': 'json',
            'dataSrc': ''
           
        },
        'columns': [
            {
                'data': null,
                'render': function (data, type, row, meta) {
                    return (meta.row + meta.settings._iDisplayStart + 1);
                }
            },
            {
                'data': 'nik'
            },
            {
                'data': 'fullName'
            },
            {
                'data': 'phone',
                'bSortable': false,
                'ordering': false
            },
            {
                'data': 'salary ',
                'render': function (data, type, row, meta) {
                    return formatRupiah('' + row['salary'], '');
                }
            },
            {
                'data': 'email'
            },

            {
                'data': 'birthdate',
                'render': (data, type, row) => {
                    var dataGet = new Date(row['birthdate']);
                    return dataGet.toLocaleDateString();
                }
            },
            {
                'data': 'gender',
                'render': (data, type, row) => {
                    if (row['gender'] == 0) {
                        return "Male";
                    } else {
                        return "Female";
                    }
                }
            },
            {
                'data': 'degree'
            },
            {
                'data': 'gpa'
            },
            {
                'data': 'name'
            },
            {
               
                'data': 'nik',
                'bSortable': false,
                'ordering': false,
                'render': function (data, type, row, meta) {
                    return '<button class="fa fa-edit"  value="' + row['nik'] + '" data-toggle="modal" data-target="#editModal"></button>' +
                        '<button value= "' + row['nik'] +'" class="fa fa-trash" onclick="Delete(this.value)"  data-toggle="modal" data-target=""></button>';
                },
            },
             
        ],
      
        
    });
});



function formatRupiah(angka, prefix) {
    var number_string = angka.replace(/[^,\d]/g, '').toString(),
        split = number_string.split(','),
        sisa = split[0].length % 3,
        rupiah = split[0].substr(0, sisa),
        ribuan = split[0].substr(sisa).match(/\d{3}/gi);

    if (ribuan) {
        separator = sisa ? '.' : '';
        rupiah += separator + ribuan.join('.');
    }

    rupiah = split[1] != undefined ? rupiah + ',' + split[1] : rupiah;
    return prefix == undefined ? rupiah : (rupiah ? 'Rp. ' + rupiah : '');
}


/*================================Add Univ Option================================*/
$.ajax({
    'url': "https://localhost:44332/api/Universities",
    
}).done((result) => {
    console.log(result);
    text = "<option selected disabled value=\"\">Choose...</option>";
    $.each(result, function (key, val) {
        text += `<option value="${val.universityId}">${val.name}</option>`;
    });
    $("#univ").html(text);
}).fail((error) => {
    console.log(error);
});

/*================================Add Education Option================================*/
$('#univ').change(function () {
    let univ = $(this).val();
    $.ajax({
        'url': 'https://localhost:44332/api/Educations',
    }).done((result) => {
        text = "<option selected disabled value=\"\">Choose...</option>";
        $.each(result, function (key, val) {
            if (univ == val.universityId) {
                text += `<option value="${val.degree}">${val.degree}</option>`;
            }
        });
        $("#degree").html(text);
    }).fail((error) => {
        console.log(error);
    });
});




$('#TableEmployee').on('click', '.fa-edit', function () {
    let rowData = $('#TableEmployee').DataTable().row($(this).closest('tr')).data();
    console.log(rowData);
    Show(rowData);
});


/*================================SHOW DATA===========================================*/
function Show(data) {
    let gender;
    if (data.gender == "Male") {
        gender = 0;
    }
    else {
        gender = 1;
    }
    const name = data.fullName;
    const [firstname, lastname] = name.split(' ');
    $("#nikedit").val(data.nik);
    $("#firstnameedit").val(firstname);
    $("#lastnameedit").val(lastname);
    $("#emailedit").val(data.email);
    $("#salaryedit").val(data.salary);
     if (gender == 1) {
        $("#genderedit1").val(gender).prop('checked', true);
    } else {
        $("#genderedit").val(gender).prop('checked', true);
    }
    $("#birthDateedit").val(new Date(data.birthdate + "Z").toISOString().substring(0, 10));
    $("#phoneNumberedit").val(data.phone);
}

/*================================EDIT===========================================*/
function Edit() {
    var nik = $("#nikedit").val();
    var obj = new Object();
    /*obj.NIK = $("#nikedit").val();*/
    obj.Firstname = $("#firstnameedit").val();
    obj.Lastname = $("#lastnameedit").val();  
    obj.Gender = $("input[name=genderedit]:checked").val();
    obj.Birthdate = $("#birthDateedit").val();
    obj.Phone = $("#phoneNumberedit").val();
    obj.Email = $("#emailedit").val();
    obj.Salary = parseInt($("#salaryedit").val());
    $.ajax({
        url: "Employees/Put/"+nik,
        type: "PUT",
        //dataType: "json",
        //contentType: "application/json",
        data: obj
    }).done((result) => {
        console.log(obj);
        Swal.fire({
            icon: 'success',
            title: result.message,
        });
        table.ajax.reload(null, false);
        $('body').removeClass('modal-open');
        $('#editmodal').modal('hide');
        $('.modal-backdrop').remove();
    }).fail((error) => {
        console.log(obj);
        Swal.fire({
            icon: 'error',
            title: 'edit gagal',
            text: error.responseJSON.message,
        });
    });
}


/*================================DELETE===========================================*/
function Delete(key) {
    Swal.fire({
        title: 'Yakin ingin dihapus',
        text: "Data akan dihapus dari database",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yakin',
        cancelButtonColor: 'Batal',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "Employees/Delete/"+key,
                type: "delete",
                crossDomain: true,
            }).done((result) => {
                Swal.fire(
                    'Berhasil',
                    result.messageResult,
                    'success'
                )
                table.ajax.reload();
            }).fail((error) => {
                Swal.fire(
                    'Gagal',
                    'error'
                )
            })
        }
    })
}

/*================================REGISTER===========================================*/
function Insert() {
    var obj = new Object();

   // obj.NIK = $("#nik").val();
    obj.Firstname = $("#firstname").val();
    obj.Lastname = $("#lastname").val();
    obj.Gender = parseInt($("input[name=gender]:checked").val());
    obj.Birthdate = $("#birthdate").val();
    obj.Phone = $("#phone").val();
    obj.Email = $("#email").val();
    obj.Password = $("#password").val();
    obj.Salary = parseInt($("#salary").val());
    obj.GPA = parseFloat($("#gpa").val());
    obj.UniversityId = parseInt($("#univ").val());
    obj.Degree = $("#degree").val();
    
/*obj.RoleID = parseInt($("#roleid").val());*/
   
    /*console.log(obj);*/

    $.ajax({
        url: "Employees/Register",
        type: "POST",
        //dataType: "json",
        //contentType : 'application/json',      
        data: obj
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: result.message,
        });
        table.ajax.reload(null, false);
        $('body').removeClass('modal-open');
        chartGender();
        chartUniversity();
        chartSalary();
        $('#regisModal').modal('hide');
        $('.modal-backdrop').remove();
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Registrasi Gagal',
            text: error.responseJSON.message,
        });
});
}


/*================================Validation Register================================*/
window.addEventListener('load', () => {
    var forms = document.getElementsByClassName('needs-validation');
    for (let form of forms) {
        form.addEventListener('submit', (evt) => {
            if (!form.checkValidity()) {
                evt.preventDefault();
                evt.stopPropagation();
            } else {
                evt.preventDefault();
                Insert();
            }
            form.classList.add('was-validated');
        });
    }
});

/*================================Validation Edit================================*/
window.addEventListener('load', () => {
    var forms = document.getElementsByClassName('needs-valid');
    for (let form of forms) {
        form.addEventListener('submit', (evt) => {
            if (!form.checkValidity()) {
                evt.preventDefault();
                evt.stopPropagation();
            } else {
                evt.preventDefault();
                Edit();
            }
            form.classList.add('was-validated');
        });
    }
});




/*==============================================PIE/DONUT CHART==================================*/

function chartUniversity() {
    let universityA = null;
    let universityB = null;
    let universityC = null;
    let universityD = null;
    let universityE = null;
    jQuery.ajax({
        url: 'Employees/GetRegisteredData',
        success: function (result) {
            $.each(result, function (key, val) {
                if (val.name == "Telkom University") {
                    universityA++;
                } else if (val.name == "Universitas Indonesia") {
                    universityB++;
                } else if (val.name == "Universitas Padjajaran") {
                    universityC++;
                } else if (val.name == "Universitas Negeri Padang") {
                    universityD++;
                } else {
                    universityE++;
                }
            });
            var options = {
                chart: {
                    type: 'bar',
                    size: '50%',

                },
                series: [{
                    name: 'employee',
                    data: [universityA, universityB, universityC, universityD, universityE]
                }],
                title: {
                    text: 'Jumlah Individu per Universitas',
                    align: 'left',
                    margin: 10,
                    offsetX: 0,
                    offsetY: 0,
                    floating: false,
                    style: {
                        fontSize: '14px',
                        fontWeight: 'bold',
                        fontFamily: undefined,
                        color: '#263238'
                    },
                },
                dataLabels: {
                    enabled: true
                },
                xaxis: {
                    categories: ["Telkom University", "Universitas Indonesia", "Universitas Padjajaran","Universitas Negeri Padang", "UNISBA"]
                }
            }
            var barChart = new ApexCharts(document.querySelector("#chartUniversity"), options);
            barChart.render();
        },
        async: false
    });
}

/*================================Chart Donut================================*/
function chartSalary() {
    upper = 0;
    mid = 0;
    jQuery.ajax({
        url: 'Employees/GetRegisteredData',
        success: function (result) {
            $.each(result, function (key, val) {
                if (val.salary > 8000000) {
                    upper++;
                }
                else {
                    mid++;
                }
            });
            var options = {
                chart: {
                    type: 'donut',
                    size: '50%',
                    toolbar: {
                        show: true,
                        offsetX: 0,
                        offsetY: 0,
                        tools: {
                            download: true,
                            selection: true,
                            zoom: true,
                            zoomin: true,
                            zoomout: true,
                            pan: true,
                            reset: true | '<img src="/static/icons/reset.png" width="20">',
                            customIcons: []
                        },
                        export: {
                            csv: {
                                filename: undefined,
                                columnDelimiter: ',',
                                headerCategory: 'category',
                                headerValue: 'value',
                                dateFormatter(timestamp) {
                                    return new Date(timestamp).toDateString()
                                }
                            },
                            svg: {
                                filename: undefined,
                            },
                            png: {
                                filename: undefined,
                            }
                        },
                        autoSelected: 'zoom'
                    },
                },
                dataLabels: {
                    enabled: true
                },
                title: {
                    text: 'Salary Rate',
                    align: 'left',
                    margin: 10,
                    offsetX: 0,
                    offsetY: 0,
                    floating: false,
                    style: {
                        fontSize: '14px',
                        fontWeight: 'bold',
                        fontFamily: undefined,
                        color: '#263238'
                    },
                },
                series: [upper, mid],
                labels: ['Gaji Di Atas 8jt', 'Gaji Di Bawah 8jt'],
                noData: {
                    text: 'Loading...'
                }
            }
            var chart = new ApexCharts(document.querySelector("#chartSalary"), options);
            chart.render();
        },
        async: false
    })
}

/*================================Chart Donut================================*/
function chartGender() {
    male = 0;
    female = 0;
    jQuery.ajax({
        url: 'Employees/GetRegisteredData',
        success: function (result) {
            $.each(result, function (key, val) {
                if (val.gender == 1) {
                    female++;
                }
                else {
                    male++;
                }
            });
            var options = {
                chart: {
                    type: 'donut',
                    size: '50%',
                    toolbar: {
                        show: true,
                        offsetX: 0,
                        offsetY: 0,
                        tools: {
                            download: true,
                            selection: true,
                            zoom: true,
                            zoomin: true,
                            zoomout: true,
                            pan: true,
                            reset: true | '<img src="/static/icons/reset.png" width="20">',
                            customIcons: []
                        },
                        export: {
                            csv: {
                                filename: undefined,
                                columnDelimiter: ',',
                                headerCategory: 'category',
                                headerValue: 'value',
                                dateFormatter(timestamp) {
                                    return new Date(timestamp).toDateString()
                                }
                            },
                            svg: {
                                filename: undefined,
                            },
                            png: {
                                filename: undefined,
                            }
                        },
                        autoSelected: 'zoom'
                    },
                },
                dataLabels: {
                    enabled: true
                },
                title: {
                    text: 'Perbandingan Gender',
                    align: 'left',
                    margin: 10,
                    offsetX: 0,
                    offsetY: 0,
                    floating: false,
                    style: {
                        fontSize: '14px',
                        fontWeight: 'bold',
                        fontFamily: undefined,
                        color: '#263238'
                    },
                },
                series: [male, female],
                labels: ['Male', 'Female'],
                noData: {
                    text: 'Loading...'
                }
            }
            var chart = new ApexCharts(document.querySelector("#chartGender"), options);
            chart.render();
        },
        async: false
    })
}

/*//==========================POKEMON============================*/
$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon?offset=20&limit=20"
}).done((result) => {
    console.log(result);
    console.log(result.results);
    var text = "";
    $.each(result.results, function (key, val) {
        text += `<tr>
                <td>${val.name}</td>
                <td class="text-capitalize">${val.url}</td>
                <td><button type="button" value= "${val.url}"
                        onclick="getData(this.value)" class="btn btn-primary" data-toggle="modal" data-target="#getPoke">Detail</td>
                </tr>`;
    });
    $(".tablePoke").html(text);
}).fail((error) => {
    console.log(error);
});



function getData(link) {
    $.ajax({
        url: link
    }).done((result) => {
        console.log(result);
        var ability = "";
        $.each(result.abilities, function (key, val) {
            ability += /*`${val.ability.name}&nbsp|&nbsp`*/ `<span class="ability badge-pill badge-light text-capitalize" style="text-align">${val.ability.name}</span> &nbsp`;
        });
        var typePoke = "";
        $.each(result.types, function (key, val) {
            typePoke += typePokeColor(val.type.name) + "&nbsp";
        });

        function typePokeColor(val) {
            if (val == "grass") {
                var color = `<span class="badge badge-success text-capitalize" style="text-align: center;">${val}</span>`;
                return color;
            }
            else if (val == "water") {
                var color = `<span class="badge badge-primary text-capitalize" style="text-align: center;">${val}</span>`;
                return color;
            }
            else if (val == "poison") {
                var color = `<span class="badge badge-dark text-capitalize" style="text-align: center;">${val}</span>`;
                return color;
            }
            else if (val == "normal") {
                var color = `<span class="badge badge-light text-capitalize" style="text-align: center;">${val}</span>`;
                return color;
            }
            else if (val == "fire") {
                var color = `<span class="badge badge-danger text-capitalize" style="text-align: center;">${val}</span>`;
                return color;
            }
            else if (val == "electric") {
                var color = `<span class="badge badge-warning text-capitalize" style="text-align: center;">${val}</span>`;
                return color;
            }
            else {
                var color = `<span class="badge badge-secondary text-capitalize" style="text-align: center;">${val}</span>`;
                return color;
            }
        }
        var statPoke = "";
        $.each(result.stats, function (key, val) {
            statPoke += `<div class="row">
                         <div class="text-capitalize" id="base" ><b>${val.stat.name}</b></div>
                         </div>
                            <div class="row progress">
                          <div class="progress-bar" role="progressbar" style="width: ${val.base_stat + "%"};" aria-valuenow="${val.base_stat}" aria-valuemin="0" aria-valuemax="1000">${val.base_stat}</div>
                           </div>`;
        });
        var img = ""
        img += `
            <img src="${result.sprites.other.dream_world.front_default}" alt="" width="250" height="250" style="background-color:gainsboro;" class="rounded-circle shadow p-0 mb-5 rounded"/></div>`;

        $(".detailName").html(result.name);
        $(".ability").html(":" + ability);
        $(".height").html(": " + result.height);
        $(".weight").html(": " + result.weight);
        $("#stat").html(statPoke);
        $(".badge").html(typePoke);


        $("#detailImage").html(img);

    }).fail((error) => {
        console.log(error);
    });
}

//function getDetails(link) {
//    $.ajax({
//        url: link
//    }).done((result) => {
//        console.log(result);
//        console.log(result.abilities);
//        var ability = "";

//        $each(result.abilities, function (key, val) {
//            ability += `${val.ability.name}/`
//        });
//        var type = "";
//        $each(result.types, function (key, val) {
//            type += `${val.type.name}/`


//        });
//        var detailAbilities = "";
//        if (result.abilities.length > 1) {
//            $.each(result.abilities, function (key, val) {
//                detailAbilities += `${val.ability.name}/`;
//            });
//        } else {
//            $.each(result.abilites, function (key, val) {
//                detailAbilities += `${val.ability.name}`;
//            });
//        }

//        var img = ""
//        img += ` <img src="${result.sprites.other.dream_world.front_default}" alt="" width="250" height="250" style="background-color:gainsboro;" class="rounded-circle shadow p-0 mb-5 rounded"/></div>`;
//        $("#detailImage").html(img);

//        /*var img=""*/


//        $(".detailName").html(result.name);
//        $(".detailAbilities").html(detailAbilities);
//        $(".detailHeight").html(result.height);
//        $(".detailWeight").html(result.weight);
//        $(".detailWeight").html(result.weight);
//        /*  var url = "";*/
//    }).fail((error) => {
//        console.log(error);
//    });
//}




  


    

