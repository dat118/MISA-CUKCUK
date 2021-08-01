<template>
<div>
    <EmployeeList/>
    
</div>
</template>

<style scoped>
@import '../../css/layout/content.css';
</style>

<script>
// import axios from 'axios'
// import VueAxios from 'vue-axios'
// import ButtonIcon from '../base/BaseButtonIcon.vue'
// import TextField from '../base/BaseTextField.vue'
// import Button from '../base/BaseButton.vue'
import EmployeeList from '../../view/employee/Employee.vue'
// import Profile from '../../view/employee/EmployeeProfile.vue'
export default {
  name: 'Content',
  components:{EmployeeList},
  
}
</script>