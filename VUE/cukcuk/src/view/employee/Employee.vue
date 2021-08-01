<template>
<div>
    <div class="content">
            <div class="header-content">
                <div class="page-title">Danh sách nhân viên</div>
                <div class="page-feature" @click="btnAddOnClick"> 
                    <ButtonIcon 
                    idButton="btn-add"
                    iconChoose="icon-add"
                    buttonText="Thêm nhân viên"
                    />
                </div>

            </div>
            
            <div class="filter-bar">
                <div class="filter-left">
                    <TextField
                    idTextField="filter-search"
                    placeHolder="Tìm theo Mã, Tên hoặc Số điện thoại"
                    />
                    
                    <!-- <select class="filter-select" name="" id="">
                        <option value="">Tất cả phòng ban</option>
                        <option value="">aaaa</option>
                        <option value="">bbb</option>
                    </select> 

                    <select class="filter-select" name="" id="">
                        <option value="">Tất cả vị trí</option>
                        <option value="">aaaa</option>
                        <option value="">bbb</option>
                    </select>  -->

                    <!-- <div class="combobox">
                        <input type="text" placeholder="Tất cả phòng ban" class="text-field">
                        <button class="button"></button>
                        <div class="combobox-value">         
                        </div>
                    </div>
                    <div class="combobox">
                        <input type="text" placeholder="Tất cả vị trí" class="text-field">
                        <button class="button"></button>
                        <div class="combobox-value">         
                        </div>
                    </div> -->
                </div>
                <div class="filter-right">
                    <button class="button-refresh"></button>
                </div>

            </div>
            <div class="grid">
                <table id="table-employee">
                    <thead>
                        <tr><th>#</th>
                        <th fieldname="EmployeeCode">Mã nhân viên</th>
                        <th fieldname="FullName">Họ và tên</th>
                        <th fieldname="Gender">Giới tính</th>
                        <th>Ngày sinh</th>
                        <th>Điện thoại</th>
                        <th>Email</th>
                        <th>Chức vụ</th>
                        <th>Phòng Ban</th>
                        <th>Mức lương cơ bản</th>
                        <th>Tình trạng công việc</th>
                    </tr></thead>
                    <tbody id="tbody-employee">
            
            <tr v-for="employee in employees" :key="employee.EmployeeId" @dblclick="dblClickOnRow(employee.EmployeeId)">
            <td class="td-checked"> <input class="checked" type="checkbox" :value="employee.EmployeeId"> </td>
            <td>{{employee.EmployeeCode}}</td>
            <td>{{employee.FullName}}</td>
            <td class="text-align-center">{{employee.GenderName}}</td>
            <td class="text-align-center">{{formatDate(employee.DateOfBirth)}}</td>
            <td class="text-align-center">{{employee.PhoneNumber}}</td>
            <td>{{employee.Email}}</td>
            <td>{{employee.PositionName}}</td>
            <td>{{employee.DepartmentName}}</td>
            <td class="text-align-right">{{formatMoney(employee.Salary)}}</td>
            <td>{{employee.WorkStatus}}</td>
        </tr>
        </tbody> 
                </table>
                    </div>
            
            <div class="paging-bar">
                <div class="paging-left">
                <p>Hiển thị <b>1-10/1000</b> nhân viên</p>
                </div>
                <div class="paging-center">
                    <ButtonIcon
                    shape="rectangle"
                    idButton="first-page"
                    iconChoose="icon-first-page"
                    color="white"
                    />
                    <ButtonIcon
                    shape="rectangle"
                    idButton="prev-page"
                    iconChoose="icon-prev"
                    color="white"
                    />
                    <Button
                    Text="1"
                    shape="circle"
                    color="white"
                    />
                    <Button
                    Text="2"
                    shape="circle"
                    color="white"
                    />
                    <Button
                    Text="3"
                    shape="circle"
                    color="white"
                    />
                    <Button
                    Text="4"
                    shape="circle"
                    color="white"
                    />
                    <ButtonIcon
                    shape="rectangle"
                    idButton="next-page"
                    iconChoose="icon-next"
                    color="white"
                    />
                    <ButtonIcon
                    shape="rectangle"
                    idButton="last-page"
                    iconChoose="icon-last-page"
                    color="white"
                    />
                </div>
                <div class="paging-right">
                    <p>10 nhân viên 1 trang</p>
                </div>
            </div>           
        </div>
        <Profile
        @btnCancelOnClick="btnCancelOnClick"
        :hidden='hide'
        :employeeID='EmployeeId'
        :mode='formMode'
        />
</div>
</template>

<style scoped>
@import '../../css/layout/content.css';
@import '../../css/layout/profile.css';
</style>

<script>
import axios from 'axios'
// import VueAxios from 'vue-axios'
import ButtonIcon from '../../components/base/BaseButtonIcon.vue'
import TextField from '../../components/base/BaseTextField.vue'
import Button from '../../components/base/BaseButton.vue'
import Profile from '../../view/employee/EmployeeProfile.vue'
export default {
  name: 'EmployeeList',
  components:{ButtonIcon,TextField,Button,Profile},
  mounted() {
      var vm = this;
      // Gọi API lấy dữ liệu
        axios.get("http://cukcuk.manhnv.net/v1/Employees").then(res =>{
            // console.log(res.data);
            vm.employees=res.data;
        }).catch(res =>{
            console.log(res);
        })
  },
  methods: {
      btnAddOnClick(){   
            
            this.hide = false; 
            this.formMode = 0; 
            
      },
      btnCancelOnClick(){
            this.hide = true;
            this.formMode = 1;

      },
      dblClickOnRow(employeeId){
          this.EmployeeId = employeeId;
          this.hide = false;
      },
      /***************************
 * Định dạng ngày sinh
 * Creator:NDDAT-31/7/2021
 */
    formatDate(time) {
    var date = new Date(time);
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
},
/**************************
 * Định dạng tiền lương
 * Creator:NDDAT-19/7/2021
 */

    formatMoney(money) {
    if (money === null) {
        return " ";
    } else {
        var num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
        return num;
    }
},
  },
  data() {
      return {
          employees:[],
          hide: true,
          EmployeeId:'',
          formMode:1,
      }
  },
}
</script>