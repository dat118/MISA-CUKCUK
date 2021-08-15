<template>
<div  >
  <div class="profile-wrapper" style="display: block;z-index: 6;" >
        <div class="profile">
            <div class="profile-header">
                <p class="profile-name">Thông tin nhân viên</p>
                <button class="button-cancel" @click="$emit('btnCancelOnClick')"></button>
            </div>
            <div class="profile-pic">
                <div class="employee-pic"><img src="../../assets/img/default-avatar.jpg" alt=""></div>
                <div class="requirement"><p>(Vui lòng chọn ảnh có định dạng</p>
                                        <p>.jpg,.jpeg,.png,.gif )</p>
                </div>
            </div>
            <div class="profile-content">
                <div class="person-information">
                    <div class="person-infor">
                    <b>A. THÔNG TIN CHUNG</b><br>
                    <b style="color: #019160;">__________</b>
                    </div>
                    <div class="profile-row">
                    <div class="person-code" style="padding-right: 15px;">
                    <label style="display:flex;" for="code">Mã nhân viên (<b style="color: red;">*</b>)</label>
                    <TextField
                    v-model="employees.EmployeeCode"
                    :textContent='employees.EmployeeCode'
                    idTextField="code"
                    type="text"
                    required="required"
                    tooltipWarning="Mã nhân viên không được bỏ trống"
                    dataType="code"
                    ref="neededValidate1" 
                    />
                    </div>
                    <div class="employee-name">
                    <label style="display:flex;" for="name">Họ và tên (<b style="color: red;">*</b>)</label>
                    <TextField
                    v-model="employees.FullName"
                    :textContent='employees.FullName'
                    idTextField="name"
                    type="text"
                    required="required"
                    tooltipWarning="Họ và tên không được bỏ trống"
                    dataType="name"
                    ref="neededValidate2" 
                    />
                    </div>
                    </div>
                    <div class="profile-row">
                        <div class="employee-birth" style="padding-right: 15px;">
                        <label style="display:flex;" for="date">Ngày sinh</label> 
                        <TextField
                        type="date"
                        v-model="employees.DateOfBirth"
                        :textContent="employees.DateOfBirth"
                       />
                    </div>
                    <div class="employee-sex">
                        <label style="display:flex;" for="sex">Giới tính</label> 
                        <Dropdown
                        :items = "gender"
                        :selectedId = "employees.Gender"
                        id = "sex"
                        :defaultText = "employees.GenderName"
                        v-model = "employees.Gender"
                        />
                    </div>
                    </div>
                    <div class="profile-row">
                        <div class="employee-id" style="padding-right: 15px;">
                        <label style="display:flex;" for="id">Số CMND/CCCD (<b style="color: red;">*</b>)</label>
                        <TextField
                        v-model="employees.IdentityNumber"
                        :textContent='employees.IdentityNumber'
                        idTextField="id"
                        type="text"
                        dataType="number"
                        required="required"
                        tooltipWarning="CMND/CCCD không được bỏ trống"
                        
                        ref="neededValidate3" 
                    />
    
                    </div>
                    <div class="realease-date">
                        <label style="display:flex;" for="date-re">Ngày cấp</label>
                        <div class="date-of-birth">
                        
                        <TextField
                        type="date"
                        v-model="employees.IdentityDate"
                        :textContent="employees.IdentityDate"
                        />
                        </div>
                    </div>
                    </div>
                    <div class="profile-row">
                        <div class="person-id-place" style="padding-right: 15px;">
                    <label style="display:flex;" for="id-place">Nơi cấp</label>
                        <TextField
                        v-model="employees.IdentityPlace"
                        :textContent='employees.IdentityPlace'
                        idTextField="id-place"
                        type="text"
                    />
                </div>
                    </div>
                    <div class="profile-row">
                        <div class="employee-email" style="padding-right: 15px;">
                        <label style="display:flex;" for="mail">Email (<b style="color: red;">*</b>)</label>
                        <TextField
                        v-model="employees.Email"
                        :textContent='employees.Email'
                        idTextField="mail"
                        type="text"
                        dataType='email'
                        required="required"
                        ref="neededValidate4" 
                        tooltipWarning="Email không hợp lệ"
                    />
                    </div>
                    <div class="employee-number">
                        <label style="display:flex;" for="number">Số điện thoại (<b style="color: red;">*</b>)</label>
                        <TextField
                        v-model= "employees.PhoneNumber"
                        :textContent='employees.PhoneNumber'
                        idTextField="number"
                        type="text"
                        dataType="number"
                        required="required"
                        tooltipWarning="Số điện thoại không được bỏ trống"
                        ref="neededValidate1" 
                    />
                    </div>
                    </div>

                </div>
                <div class="work-information">
                    <div class="work-infor">
                    <b>B. THÔNG TIN CÔNG VIỆC</b><br>
                    <b style="color: #019160;">__________</b>
                </div>
                    <div class="profile-row">
                        <div class="work-position" >
                        <label style="display:flex;" for="position">Vị trí</label> 
                        <Dropdown
                        :items = "position"
                        :selectedId = "employees.PositionId"
                        id = "position"
                        :defaultText = "employees.PositionName"
                        v-model = "employees.PositionId"
                        />
                    </div>
                    <div class="work-department">
                        <label style="display:flex;" for="department">Phòng ban</label> 
                          <Dropdown
                        :items = "department"
                        :selectedId = "employees.DepartmentId"
                        id = "department"
                        :defaultText = "employees.DepartmentName"
                        v-model = "employees.DepartmentId"
                        /> 
                    </div>
                    </div>
                    <div class="profile-row">
                    <div style="padding-right: 15px;">
                    <label style="display:flex;" for="tax">Mã số thuế cá nhân</label>
                    <TextField
                    v-model="employees.PersonalTaxCode"
                    :textContent='employees.PersonalTaxCode'
                    idTextField="tax"
                    type="text"
                    
                    />
                </div>
                <div>
                    <!-- <label style="display:flex;" for="salary">Mức lương cơ bản</label> -->
                    <TextField
                        textLabel="Mức lương cơ bản "
                        type="text"
                        isMoney = true
                        v-model="employees.Salary"
                        :textContent="employees.Salary"
                        dataType="money"
                        moneyCurrency="VND"
                        />
                    <!-- <input class="text-field text-align-right" placeholder="VND" type="text" id="salary" v-model="employees.Salary"> -->
                </div>
                    </div>
                    <div class="profile-row">
                        <div class="join-date" style="padding-right: 15px;">
                        <label style="display:flex;" for="join-date">Ngày gia nhập công ty</label>
                       <TextField
                        type="date"
                        v-model="employees.JoinDate"
                        :textContent="employees.JoinDate"
                        />
                    </div>
                        <div class="work-status">
                        <label style="display:flex;" for="work-stt">Tình trạng công việc</label> 
                        <Dropdown
                        v-model= "employees.WorkStatus"
                        :defaultText = 'employees.WorkStatus'
                        id="work-stt"
                        :items = "status"
                        :selectedId = "employees.WorkStatus"
                    />   
                    </div>
                    </div>


                </div>
            </div>    
                        
            <div class="profile-paging">
                <div class="paging-button">
                <button class="paging-cancel" @click="$emit('btnCancelOnClick')" style="width: 100px; margin-right:10px">Hủy</button >
                
                <div v-on:click="checkValidation" >
                <ButtonIcon
                idButton="btn-save"
                iconChoose='icon-save'
                buttonText="Lưu"
                @click="$emit('btnCancelOnClick')"
                />
                </div>
                
                </div>
            </div>
    </div>
    <Popup
        :hide='hidePopup'
        :subClass="popupType"
        :btnText="btnPopup"
        :popupTitle="popupTitle"
        :popupContent="popupContent"
        @btnPopupCancelOnClick="btnPopupCancelOnClick"
        @btnPopupOnClick="btnSaveOnClick"
        />
</div>
</div>
</template>

<script>

import axios from 'axios'
// // import VueAxios from 'vue-axios'
import ButtonIcon from '../../components/base/BaseButtonIcon.vue'
import TextField from '../../components/base/BaseTextField.vue'
// import Button from '../base/BaseButton.vue'
import dayjs from 'dayjs'
import Dropdown from '../../components/base/BaseDropdown.vue'
import Popup from '../../components/base/BasePopUp.vue'

export default {
name:'Profile',
components:{
    ButtonIcon,
    TextField,
    Dropdown,
    Popup,
  
},

props:{

    employeeID:{
        type:String,
        default:null,
        required:true,
    },
    mode:{
        type:Number,
        default:1,
    }
},
methods:{
    loadData(){
        var vm = this;
      // Gọi API lấy dữ liệu
        axios.get("http://cukcuk.manhnv.net/v1/Employees").then(res =>{
            
            vm.employees=res.data;

        }).catch(res =>{
            console.log(res);
        })
    },
    checkValidation(){
        let vm = this,
        validateResult = true;

      for (let [key] of Object.entries(vm.$refs)) {
        if (key.includes("neededValidate") && !vm.$refs[key].inputValidation()) {
          validateResult = false; 
        }
        if(validateResult==true){
            this.btnPopupAppear();
        }
      }
    },
    btnPopupAppear(){
        this.hidePopup = false;
        this.popupType = 'message';
        this.popupTitle = 'Lưu bản ghi';
        this.popupContent = 'Bạn có muốn lưu bản ghi này không ?';
        this.btnPopup = "Lưu"
    },
    btnPopupCancelOnClick(){
        this.hidePopup = true;
    },
    toastMessShow(){
          this.toastHidden=false
          this.toastText = "Lưu thành công"
          this.toastType = 'message'
      }  ,
    
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
/***************************
 * Định dạng ngày
 * Creator:NDDAT-31/7/2021
 */
    formatDateYMD(date) {
      if (date == null) {
        return null;
      }
      return dayjs(date).format("YYYY-MM-DD");
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
    btnSaveOnClick(){
        var vm = this;
        
        if (vm.mode == 0) {
            axios.post("http://cukcuk.manhnv.net/v1/Employees",vm.employees).then(res =>{
            console.log(res);
            vm.$emit('btnCancelOnClick');
            vm.loadData();
            vm.hidePopup=true;
            vm.$emit('toastMessShow');
        }).catch({})
        } else {
            axios.put("http://cukcuk.manhnv.net/v1/Employees/"+vm.employeeID,vm.employees).then((res) =>{
            console.log(res);
            vm.$emit('btnCancelOnClick');
            vm.loadData();
            vm.hidePopup = true;
            vm.$emit('toastMessShow');
        }).catch({})    
        }
    }
},
data() {
    return {
        hidePopup: true,
        popupType:'',
        btnPopup:'',
        popupTitle:'',
        popupContent:'',
        employees:{},
        toastHidden:true,
        toastText:'',
        toastType:'',
        department:[{
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
          position:[{
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
          gender:[{
              itemName:'Nữ',
              itemId:'0',
          },
          {
              itemName:'Nam',
              itemId:'1',
          },
          {
              itemName:'Không xác định',
              itemId:'2',
          }

          ],
          status:[{
              itemName:'Đang làm việc',
              itemId:'1',
          },
          {
              itemName:'Đang thử việc',
              itemId:'2',
          },
          {
              itemName:'Đã nghỉ việc',
              itemId:'3',
          }

          ],

        
    }
},
mounted() {
   var vm = this;
        if (vm.mode == 0){
        // Gọi API lấy mã nhân viên
        axios.get("http://cukcuk.manhnv.net/v1/Employees/NewEmployeeCode").then(res =>{
            console.log(res.data);
            vm.employees = {};
            vm.employees.EmployeeCode = res.data;
        }).catch({})

    } else {
        // Gọi API lấy dữ liệu
        axios.get("http://cukcuk.manhnv.net/v1/Employees/"+vm.employeeID).then(res =>{
            console.log(res.data);
            var em = res.data;
            em.IdentityDate = vm.formatDateYMD(em.IdentityDate);
            em.JoinDate = vm.formatDateYMD(em.JoinDate);
            em.DateOfBirth = vm.formatDateYMD(em.DateOfBirth);
            vm.employees=em;
            
        }).catch({}) 
    }
},

}
</script>

<style>
@import '../../css/layout/profile.css';

</style>