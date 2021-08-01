$(document).ready(function () {
    formMode = null;
    var employeeId = '';
    loadData();
});
/**
 * Hàm load dữ liệu
 * Creator:NDD-19/7/2021
 */

function loadData(){
    // Clean dữ liệu cũ
    $('table tbody').empty();
    var tableEmployee = $('tbody');
    /**
     * Lấy dữ liệu về table
     * Creator:NDDAT-19/7/2021
     */
    try {
        $.ajax({
            url: "http://cukcuk.manhnv.net/v1/Employees",
            method: 'GET',

        }).done(function (res) {

            var tableEmployeeData = res;
            // console.log(res)
            $.each(tableEmployeeData, function (index, item) {
                var dateOfBirth = item.DateOfBirth;
                var money = item.Salary;
                birthDay = formatDate(dateOfBirth);
                money = formatMoney(money);
                
                item.EmployeeCode = item.EmployeeCode == null ? " " : item.EmployeeCode;
                item.FullName = item.FullName == null ? " " : item.FullName;
                item.GenderName = item.GenderName == null ? " " : item.GenderName;
                item.PhoneNumber = item.PhoneNumber == null ? " " : item.PhoneNumber;
                item.Email = item.Email == null ? " " : item.Email;
                item.PositionName = item.PositionName == null ? " " : item.PositionName;
                item.DepartmentName = item.DepartmentName == null ? " " : item.DepartmentName;
                item.WorkStatus = item.WorkStatus == null ? " " : item.WorkStatus;
                var tr = $(`<tr employeeid = '${item.EmployeeId}' >
            <td class = "td-checked"> <input class="checked" type="checkbox" value = "${item.EmployeeId}"> </td>
            <td>`+ item.EmployeeCode + `</td>
            <td>`+ item.FullName + `</td>
            <td class="text-align-center" >`+ item.GenderName + `</td>
            <td class="text-align-center">`+ birthDay + `</td>
            <td class="text-align-center">`+ item.PhoneNumber + `</td>
            <td>`+ item.Email + `</td>
            <td>`+ item.PositionName + `</td>
            <td>`+ item.DepartmentName + `</td>
            <td class="text-align-right">`+ money + `</td>
            <td>`+ item.WorkStatus + `</td>
        </tr>` );
                
                $('table tbody').append(tr);
            })
        }).fail(function () {
            console.log('Có lỗi xảy ra, vui lòng liên hệ MISA');
        });
    } catch (e) {
        console.log(e);
    }

}

/**
 * Định dạng ngày sinh
 * Creator:NDDAT-19/7/2021
 */

function formatDate(date) {
    var date = new Date(date);
    if (Number.isNaN(date.getTime())) {
        return " ";
    } else {
        var day = date.getDate();
        var month = date.getMonth() + 1;
        var year = date.getFullYear();

        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : month;

        return day + '/' + month + '/' + year;
    }
}
/**
 * Định dạng tiền lương
 * Creator:NDDAT-19/7/2021
 */

function formatMoney(money) {
    if (money === null) {
        return " ";
    } else {
        var num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
        return num;
    }
}
// Khởi tạo sự kiện cho các button
/**
 * Hiển thị form thêm nhân viên
 * Creator: NDDAT-20/7/2021
 */
// Hiển thị Form
$('#btn-add').click(function () {
    formMode = 1;
    // Hiển thị form thêm mới
    $('.profile-wrapper').show();
    // Reset form
    $('.profile-wrapper input').val(null);
    // Lấy mã nhân viên tự động
    $.ajax({
        url:'http://cukcuk.manhnv.net/v1/Employees/NewEmployeeCode',
        method:'GET'
    }).done(res =>{
        $('#code').val(res);
        $('#code').focus();
    }).fail(function(){
        alert("Không lấy được mã nhân viên, vui lòng kiểm tra lại kết nối");
    })
})
// Ẩn Form
$('.button-cancel').click(function () {
    $('.profile-wrapper').hide();
})
$('.paging-cancel').click(function () {
    $('.profile-wrapper').hide();
})

/**
 * Thêm nhân viên
 * Creator:NDDAT-20/7/2021
 */
// Kiểm tra các thông tin bắt buộc
$('.require').blur(function () {
    // Kiểm tra dữ liệu đã nhập chưa
    var value = $(this).val();
    console.log(value);
    if (value == "") {
        $(this).addClass('red-border');
        $(this).attr('title', 'Thông tin này bắt buộc nhập');
    } else {
        $(this).removeClass('red-border');
        $(this).removeAttr('title');
    }
})


/**
 * Chỉnh sửa thông tin nhân viên
 * Creator:NDDAT-22/7/2021
 */

// Chọn nhân viên chỉnh sửa

    $('table#table-employee').on('dblclick','tbody tr',function(){
        formMode = 0;
        $('.profile-wrapper').show();
    
    // Hiển thị chi tiết
     employeeId = $(this).attr('employeeid');
    
    $.ajax({
        url:'http://cukcuk.manhnv.net/v1/Employees/'+employeeId,
        method:'GET'
    }).done(res =>{
        var employee = res;
        $('#name').val(employee.FullName);
        $('#code').val(employee.EmployeeCode);
        $('#number').val(employee.PhoneNumber);
        $('#sex').val(employee.GenderName);
        $('#mail').val(employee.Email);
        $('#position').val(employee.PositionName);
        $('#department').val(employee.DepartmentName);
        $('#work-stt').val(employee.WorkStatus);
        $('#date').val(formatDate(employee.DateOfBirth));
        $('#id').val(employee.IdentityNumber);
        $('#date-re').val(formatDate(employee.IdentityDate));
        $('#id-place').val(employee.IdentityPlace);
        $('#tax').val(employee.PersonalTaxCode);
        $('#salary').val(formatMoney(employee.Salary));
        $('#join-date').val(formatDate(employee.JoinDate));
        console.log(employee);
        console.log(employeeId);
    }).fail (res => {
        alert("Không thể lấy thông tin")
    })
});

        //Chỉnh sửa thông tin
        $('#btn-save').click(function () {
            let employee ={};
            // Validate data
            
            employee.FullName = $('#name').val();
            employee.EmployeeCode = $('#code').val();
            employee.PhoneNumber = $('#number').val();
            employee.GenderName = $('#sex').val();
            employee.Email = $('#mail').val();
            employee.PositionName = $('#position').val();
            employee.DepartmentName = $('#department').val();
            employee.WorkStatus = $('#work-stt').val();
            employee.DateOfBirth = $('#date').val();
            // employee.DateOfBirth = new Date(employee.DateOfBirth);
            employee.IdentityNumber = $('#id').val();
            employee.IdentityDate = $('#date-re').val();
            // employee.IdentityDate = new Date(employee.IdentityDate);
            employee.IdentityPlace = $('#id-place').val();
            employee.PersonalTaxCode = $('#tax').val();
            employee.Salary = $('#salary').val().replaceAll('.','');
            employee.Salary = employee.Salary == " " ? null : employee.Salary;
            employee.JoinDate = $('#join-date').val();
            // employee.JoinDate = new Date(employee.JoinDate);   
            console.log(employee);
            if (formMode == 1) {
                var settings = {
        
                    "url" : `http://cukcuk.manhnv.net/v1/Employees/`,
                    "method" : 'POST',  
                    "timeout": 0,
                    "headers": {
                        "Content-Type": "application/json"
                    },
                    "data": JSON.stringify(employee),
                };
            
                $.ajax(settings).done(res => {
                    console.log(res);
                    alert('Thêm thành công');
                    loadData();
                    $('.profile-wrapper').hide();
                }).fail(res => {
                    alert('Đã có lỗi, vui lòng liên hệ MISA')
                })
                
            } else {
                employee.EmployeeId = employeeId; 
                // Gọi đến API để lưu dữ liệu
            // console.log(employeeId);
            var settings = {
            
                "url" : `http://cukcuk.manhnv.net/v1/Employees/`+employeeId,
                "method" : 'PUT',  
                "timeout": 0,
                "headers": {
                    "Content-Type": "application/json"
                },
                "data": JSON.stringify(employee),
            };
        
            $.ajax(settings).done(res => {
                console.log(res);
                alert('Thay đổi thành công');
                loadData();
                $('.profile-wrapper').hide();
            }).fail(res => {
                alert('Đã có lỗi, vui lòng liên hệ MISA')
            })  
            }  
    });

    /**
     * Xóa nhân viên
     * Creator:NDDAT-25-7-2021
     */

    $('#btn-delete').click(function(){

        console.log(employeeId);
        var settings = {
            
            "url" : `http://cukcuk.manhnv.net/v1/Employees/`+employeeId,
            "method" : 'DELETE',  
        };
    
        $.ajax(settings).done(res => {
            console.log(res);
            alert('Xóa thành công');
            loadData();
            $('.profile-wrapper').hide();
        }).fail(res => {
            alert('Xóa không thành công')
        })  
    })

//    var check = [];
//    check = $('.checked:checkbox:checked').parent('td-check').parent().css( "background", "yellow" );
//    console.log(check);
// var arr = [];
// $('.checked:checkbox:checked').each(function () {
//     arr.push(this.value);
// });
// console.log(arr);
// let myArray = (function() {
//     let a = [];
//     $(".checked:checked").each(function() {
//         a.push(this.value);
//     });
//     return a;
// })
// console.log(myArray);

// /**
//  * Validate email
//  * @param {any} email 
//  * @returns 
//  * Creator: NDDAT-21/07/2021
//  */
//  function isEmail(email) {
//     var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
//     if(!regex.test(email)) {
//       return false;
//     }else{
//       return true;
//     }
// }

//   var mail = $('#email').val();
//   var gmail = isEmail(mail);
//   console.log(gmail);