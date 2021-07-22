$(document).ready(function () {

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
            console.log(res)
            $.each(tableEmployeeData, function (index, item) {
                var dateOfBirth = item.DateOfBirth;
                var money = item.Salary;
                birthDay = formatDate(dateOfBirth);
                money = formatMoney(money);
                item.EmployeeCode = item.EmployeeCode === null ? " " : item.EmployeeCode;
                item.FullName = item.FullName === null ? " " : item.FullName;
                item.GenderName = item.GenderName === null ? " " : item.GenderName;
                item.PhoneNumber = item.PhoneNumber === null ? " " : item.PhoneNumber;
                item.Email = item.Email === null ? " " : item.Email;
                item.PositionName = item.PositionName === null ? " " : item.PositionName;
                item.DepartmentName = item.DepartmentName === null ? " " : item.DepartmentName;
                item.WorkStatus = item.WorkStatus === null ? " " : item.WorkStatus;
                var tr = $(`<tr>
            <td>`+ item.EmployeeCode + `</td>
            <td>`+ item.FullName + `'</td>
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
});


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
    $('.profile-wrapper').show();
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
// Thêm thông tin
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
    employee.DateOfBirth = new Date(employee.DateOfBirth);
    employee.IdentityNumber = $('#id').val();
    employee.IdentityDate = $('#date-re').val();
    employee.IdentityDate = new Date(employee.IdentityDate);
    employee.IdentityPlace = $('#id-place').val();
    employee.PersonalTaxCode = $('#tax').val();
    employee.Salary = $('#salary').val();
    employee.JoinDate = $('#join-date').val();
    employee.JoinDate = new Date(employee.JoinDate);   
    console.log(JSON.stringify(employee));
    // Gọi đến API để lưu dữ liệu

    // let employee = {
    //     "createdDate": "2021-07-21T16:27:54.509Z",
    //     "createdBy": "string",
    //     "employeeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    //     "employeeCode": "NVf123444",
    //     "fullName": "string",
    //     "gender": 0,
    //     "dateOfBirth": "2021-07-21T16:27:54.509Z",
    //     "phoneNumber": "string",
    //     "email": "string@strudfs.cjsha",
    //     "identityNumber": "string",
    //     "identityDate": "2021-07-21T16:27:54.509Z",
    //     "identityPlace": "string",
    //     "joinDate": "2021-07-21T16:27:54.509Z",
    //     "departmentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    //     "positionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    //     "workStatus": 0,
    //     "personalTaxCode": "string",
    //     "salary": 0
    // };

    var settings = {
        "url": `http://cukcuk.manhnv.net/v1/Employees/`,
        "method": 'POST',
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify(employee),
    };

    $.ajax(settings).done(res => {
        console.log(res);
        alert('Them thanh cong');

    }).fail(res => {
        alert('Đã có lỗi, vui lòng liên hệ MISA')
    })
})





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