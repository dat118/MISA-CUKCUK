<template>
<div>
    <div class="content">
            <div class="header-content">
                <div class="page-title">Danh sách nhân viên</div>
                <div class="page-feature" > 
                    <div @click="btnDeleteOnClick" style="margin-right: 10px"><ButtonIcon 
                    idButton="btn-delete"
                    iconChoose="icon-delete"
                    buttonText="Xóa nhân viên"
                    />
                    </div>

                    <div @click="btnAddOnClick"><ButtonIcon 
                    idButton="btn-add"
                    iconChoose="icon-add"
                    buttonText="Thêm nhân viên"
                    />
                </div>
                </div>

            </div>
            
            <div class="filter-bar">
                
                    <TextField 
                    idTextField="filter-search"
                    placeHolder="Tìm theo Mã, Tên hoặc Số điện thoại"
                    type="text"
                    />                
                    <div style="margin-right:15px;z-index:1">
                    <Dropdown class="filter-select" 
                    defaultText = "Tất cả phòng ban"
                    :items = "department"
                    />
                    </div>
                    <Dropdown class="filter-select"
                    defaultText="Tất cả vị trí"
                    :items = "position"
                    />
                   
                <div class="filter-right">
                    <button class="button-refresh" @click="loadData"></button>
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
            
            <tr v-for="(employee, index) in employees" :key="employee.EmployeeId"
             @dblclick="dblClickOnRow(employee.EmployeeId)"
             @click="getEmployeeId(employee.EmployeeId)"
             v-bind:class="{
                 'employeeClick': isChecked[index],
                 }"
             >
            <td>
                <div
                class="checkbox"
                :class="{'checked':isChecked[index]}"
                @click="btnCheckedOnClick(index)"
                ></div> 
            </td>
            <td>{{employee.EmployeeCode}}</td>
            <td class="text-overflow" :title = 'employee.FullName'>{{employee.FullName}}</td>
            <td class="text-align-center">{{employee.GenderName}}</td>
            <td class="text-align-center">{{formatDate(employee.DateOfBirth)}}</td>
            <td class="text-align-center">{{employee.PhoneNumber}}</td>
            <td class="text-overflow" :title = 'employee.Email'>{{employee.Email}}</td>
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
                    <div class="paging-arrow">
                        <button class="paging-up"></button>
                        <button class="paging-down"></button>
                    </div>
                </div>
            </div>           
        </div>
        <Profile
        @btnCancelOnClick="btnCancelOnClick"
        v-if='!hide'
        :employeeID='EmployeeId'
        :mode='formMode'
        />
        <Popup
        :hide='hidePopup'
        :subClass="popupType"
        :btnText="btnPopup"
        :popupTitle="popupTitle"
        :popupContent="popupContent"
        @btnPopupCancelOnClick="btnPopupCancelOnClick"
        @btnPopupOnClick="btnDeleteEmployees"
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
import Dropdown from '../../components/base/BaseDropdown.vue'
import Popup from '../../components/base/BasePopUp.vue'
export default {
  name: 'EmployeeList',
  components:{ButtonIcon,TextField,Button,Profile,Dropdown,Popup},
  mounted() {
      var vm = this;
      // Gọi API lấy dữ liệu
        axios.get("http://cukcuk.manhnv.net/v1/Employees").then(res =>{
            // console.log(res.data);
            vm.employees=res.data;
            this.isChecked= new Array(this.employees.length).fill(false);
        }).catch(res =>{
            console.log(res);
        })
  },
  methods: {
      loadData(){
          var vm = this;
      // Gọi API lấy dữ liệu
        axios.get("http://cukcuk.manhnv.net/v1/Employees").then(res =>{
            // console.log(res.data);
            vm.employees=res.data;
            this.isChecked= new Array(this.employees.length).fill(false);
        }).catch(res =>{
            console.log(res);
        })
      },
      btnAddOnClick(){   
            
            this.hide = false; 
            this.formMode = 0; 
            
      },
      getEmployeeId(EmployeeId){
          this.EmployeeId = EmployeeId;
      },
      btnCancelOnClick(){
            this.hide = true;
            this.loadData();
      },
      dblClickOnRow(employeeId){
          this.EmployeeId = employeeId;
          this.hide = false;
          this.formMode = 1;
      },
      btnCheckedOnClick(index){
          this.$set(this.isChecked, index, !this.isChecked[index]);
      },
      btnDeleteOnClick(){
          this.hidePopup = false;
          this.popupType = 'danger';
          this.popupTitle = 'Xóa bản ghi';
          this.popupContent = 'Bạn có muốn xóa bản ghi này không ?';
          this.btnPopup = "Xóa"
      },
      btnDeleteEmployees(){
          let vm = this;
          for (var i=0;i<this.employees.length;i++){
              if(this.isChecked[i]){
                  axios.delete("http://cukcuk.manhnv.net/v1/Employees/"+this.employees[i].EmployeeId).then((res)=>{
                      console.log(res);
                      this.loadData();
                      vm.hidePopup = true;   
                  }).catch({})
              }
             
          }
        //    alert("Xóa thành công");
      },
      
      btnPopupCancelOnClick(){
          this.hidePopup = true;
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
          employeeClick:null,
          isChecked:[],
          hidePopup: true,
          popupType:'',
          btnPopup:'',
          popupTitle:'',
          popupContent:'',
          department:[
              {
              itemName:'Phòng Marketting',
              itemId:'142cb08f-7c31-21fa-8e90-67245e8b283e',
          },
          {
              itemName:'Phòng đào tạo',
              itemId:'17120d02-6ab5-3e43-18cb-66948daf6128',
          },
          {
              itemName:'Phòng Nhân sự',
              itemId:'469b3ece-744a-45d5-957d-e8c757976496',
          },
          {
              itemName:'Phòng Công nghệ',
              itemId:'4e272fc4-7875-78d6-7d32-6a1673ffca7c',
          },
          ],
          position:[
              {
              itemName:'Giám đốc',
              itemId:'30d41e52-5e66-72bc-6c1c-b47866e0b131',
          },
          {
              itemName:'Nhân viên',
              itemId:'548dce5f-5f29-4617-725d-e2ec561b0f41',
          },
          {
              itemName:'Phó phòng',
              itemId:'589edf01-198a-4ff5-958e-fb52fd75a1d4',
          },
          {
              itemName:'Trưởng phòng',
              itemId:'5bd71cda-209f-2ade-54d1-35c781481818',
          },
          ],

      }
  },
  watch:{
      department: function(){
          var vm = this;
      // Gọi API lấy dữ liệu
        axios.get("http://cukcuk.manhnv.net/api/Department").then(res =>{
            vm.department.itemId = res.data.DepartmentId
            vm.department.itemName = res.data.DepartmentName

        }).catch(res =>{
            console.log(res);
        })
      },
      }
  }

</script>