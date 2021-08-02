<template>
<div :class="{'hidden-profile':hidden}" >
  <div class="profile-wrapper" style="display: block;">
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
                    />
                    </div>
                    <div class="employee-name">
                    <label style="display:flex;" for="name">Họ và tên (<b style="color: red;">*</b>)</label>
                    <TextField
                    v-model="employees.FullName"
                    :textContent='employees.FullName'
                    idTextField="name"
                    />
                    </div>
                    </div>
                    <div class="profile-row">
                        <div class="employee-birth" style="padding-right: 15px;">
                        <label style="display:flex;" for="date">Ngày sinh</label> 
                        <input style="width:185 px;" class="text-field" type="date" id="date" :v-model="formatTimeInPut(employees.DateOfBirth)">   
                    </div>
                    <div class="employee-sex">
                        <label style="display:flex;" for="sex">Giới tính</label> 
                        <input class="text-field" type="text" id="sex" v-model="employees.GenderName">   
                    </div>
                    </div>
                    <div class="profile-row">
                        <div class="employee-id" style="padding-right: 15px;">
                        <label style="display:flex;" for="id">Số CMND/CCCD (<b style="color: red;">*</b>)</label>
                        <TextField
                        v-model="employees.IdentityNumber"
                        :textContent='employees.IdentityNumber'
                    idTextField="id"
                    />
    
                    </div>
                    <div class="realease-date">
                        <label style="display:flex;" for="date-re">Ngày cấp</label>
                        <div class="date-of-birth">
                        <input class="text-field" type="date" id="date-re" :v-model='formatTimeInPut(employees.IdentityDate)' >
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
                    />
                    </div>
                    <div class="employee-number">
                        <label style="display:flex;" for="number">Số điện thoại (<b style="color: red;">*</b>)</label>
                        <TextField
                        v-model="employees.Number"
                        :textContent='employees.PhoneNumber'
                    idTextField="number"
                    />
                    </div>
                    </div>

                </div>
                <div class="work-information">
                    <div class="work-infor">
                    <b>A. THÔNG CÔNG VIỆC</b><br>
                    <b style="color: #019160;">__________</b>
                </div>
                    <div class="profile-row">
                        <div class="work-position" style="padding-right: 15px;">
                        <label style="display:flex;" for="position">Vị trí</label> 
                        <input class="text-field" type="text" id="position" v-model="employees.PosiontionName">   
                    </div>
                    <div class="employee-sex">
                        <label style="display:flex;" for="department">Phòng ban</label> 
                        <input class="text-field" type="text" id="department" v-model="employees.DepartmentName">   
                    </div>
                    </div>
                    <div class="profile-row">
                    <div style="padding-right: 15px;">
                    <label style="display:flex;" for="tax">Mã số thuế cá nhân</label>
                    <TextField
                    v-model="employees.PersonalTaxCode"
                    :textContent='employees.PersonalTaxCode'
                    idTextField="tax"
                    />
                </div>
                <div>
                    <label style="display:flex;" for="salary">Mức lương cơ bản</label>
                    <input class="text-field text-align-right" placeholder="VND" type="text" id="salary" v-model="employees.Salary">
                </div>
                    </div>
                    <div class="profile-row">
                        <div class="join-date" style="padding-right: 15px;">
                        <label style="display:flex;" for="join-date">Ngày gia nhập công ty</label>
                        <div>
                        <input class="text-field" type="date" id="join-date" >
                        </div>
                    </div>
                        <div class="work-status">
                        <label style="display:flex;" for="work-stt">Tình trạng công việc</label> 
                        <input class="text-field" type="text" id="work-stt" v-model="employees.WorkSatus">   
                    </div>
                    </div>


                </div>
            </div>    
                        
            <div class="profile-paging">
                <div class="paging-button">
                <button class="paging-cancel" @click="$emit('btnCancelOnClick')">Hủy</button >
                <!-- <button class="button" id="btn-delete"><img src="../../assets/icon/x.svg" alt=""> Xóa</button> -->
                <button v-on:click="btnSaveOnClick" 
                @click="$emit('btnCancelOnClick')"
                class="button" id="btn-save"><img src="../../assets/icon/document-online.png" alt=""> Lưu</button>
                
                </div>
            </div>
    </div>
</div>
</div>
</template>

<script>

import axios from 'axios'
// // import VueAxios from 'vue-axios'
// import ButtonIcon from '../base/BaseButtonIcon.vue'
import TextField from '../../components/base/BaseTextField.vue'
// import Button from '../base/BaseButton.vue'
export default {
name:'Profile',
components:{
    // ButtonIcon,
    TextField,
    // Button,
    
},

props:{
    hidden:{
        type:Boolean,
        default:true,
        required:true,
    },
    employeeID:{
        type:String,
        default:null,
        required:true,
    },
    mode:{
        type:Number,
        default:0,
    }
},
methods:{
    loadData(){
        var vm = this;
      // Gọi API lấy dữ liệu
        axios.get("http://cukcuk.manhnv.net/v1/Employees").then(res =>{
            // console.log(res.data);
            vm.employees=res.data;
        }).catch(res =>{
            console.log(res);
        })
    },
    /***************************
 * Định dạng ngày sinh
 * Creator:NDDAT-31/7/2021
 */
    formatTimeInPut(time) {
    var date = new Date(time);
    if (Number.isNaN(date.getTime())) {
        return " ";
    } else {
        var dd = date.getDate();
        var mm = date.getMonth() + 1;
        var yyyy = date.getFullYear();

        dd = dd < 10 ? '0' + dd : dd;
        mm = mm < 10 ? '0' + mm : mm;

        return yyyy-mm-dd;
    }
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
    btnSaveOnClick(){
        var vm=this;
        if (vm.mode==0) {
            axios.post("http://cukcuk.manhnv.net/v1/Employees",vm.employees).then(res =>{
            console.log(res);
            alert("Thêm mới thành công");
            vm.$emit('btnCancelOnClick');
            vm.loadData();
            
        }).catch({})
        } else {
            axios.put("http://cukcuk.manhnv.net/v1/Employees/"+vm.employeeID,vm.employees).then((res) =>{
            console.log(res);
            alert("Sửa thành công");
            vm.$emit('btnCancelOnClick');
            vm.loadData();

        }).catch({})    
        }
    }
},
data() {
    return {
        employees:{},
        
    }
},
watch:{
    mode: function(){
    if (this.mode == 0){
        var vm = this;
    
        // Gọi API lấy mã nhân viên
        axios.get("http://cukcuk.manhnv.net/v1/Employees/NewEmployeeCode").then(res =>{
            console.log(res.data);
            vm.employees = {};
            vm.employees.EmployeeCode=res.data;
        }).catch({})

    }
}, 
    employeeID: function(){
    // Gọi api lấy dữ liệu
    var vm = this;
    
        // Gọi API lấy dữ liệu
        axios.get("http://cukcuk.manhnv.net/v1/Employees/"+vm.employeeID).then(res =>{
            console.log(res.data);
            vm.employees=res.data;
            vm.birthDay=vm.formatDate(res.data.DateOfBirth);
        
            
        }).catch({})
},

},

}
</script>

<style>
@import '../../css/layout/profile.css';
</style>