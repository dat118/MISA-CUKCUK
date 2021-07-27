// class Base{
//     constructor(){
//         this.loadData();
        
//     }

//     loadData(){
        
         
//         //Gọi api lấy dữ liệu
        
//         $.ajax({
//             type: "GET",
//             url: "http://cukcuk.manhnv.net/v1/Employees",
            
//             success: function (response) {
//             // Xử lí dữ liệu
            
//             var tableEmployeeData = res;
//             // console.log(res)
//             $.each(tableEmployeeData, function (index, item) {
//                 var dateOfBirth = item.DateOfBirth;
//                 var money = item.Salary;
//                 birthDay = formatDate(dateOfBirth);
//                 money = formatMoney(money);
                
//                 item.EmployeeCode = item.EmployeeCode === null ? " " : item.EmployeeCode;
//                 item.FullName = item.FullName === null ? " " : item.FullName;
//                 item.GenderName = item.GenderName === null ? " " : item.GenderName;
//                 item.PhoneNumber = item.PhoneNumber === null ? " " : item.PhoneNumber;
//                 item.Email = item.Email === null ? " " : item.Email;
//                 item.PositionName = item.PositionName === null ? " " : item.PositionName;
//                 item.DepartmentName = item.DepartmentName === null ? " " : item.DepartmentName;
//                 item.WorkStatus = item.WorkStatus === null ? " " : item.WorkStatus;
//                 var tr = $(`<tr employeeid = '${item.EmployeeId}' >
//             <td> <input type="checkbox"> </td>
//             <td>`+ item.EmployeeCode + `</td>
//             <td>`+ item.FullName + `</td>
//             <td class="text-align-center" >`+ item.GenderName + `</td>
//             <td class="text-align-center">`+ birthDay + `</td>
//             <td class="text-align-center">`+ item.PhoneNumber + `</td>
//             <td>`+ item.Email + `</td>
//             <td>`+ item.PositionName + `</td>
//             <td>`+ item.DepartmentName + `</td>
//             <td class="text-align-right">`+ money + `</td>
//             <td>`+ item.WorkStatus + `</td>
//         </tr>` );
                
//                 $('table tbody').append(tr);
            
//             }
            
//         });
       
//     });
// }