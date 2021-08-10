<template>
        <div class="header">
            <div class="header-left">
                
                <div class="header-left-name">
                    <Dropdown style="z-index: 1;"
                    
                    :items = "restaurant"
                    defaultText="Nhà Hàng biển Đông"
                    />                     
                </div>
            </div>
            <div class="header-right">
                <img class="header-right-option" src="../../assets/icon/option.png" alt="">
                <div class="header-right-name">Nguyễn Văn Mạnh</div>
                <img class="header-right-pic" src="../../assets/icon/avatar-default.png" alt="">
            </div>
        </div>
</template>
<style scoped>
@import '../../css/layout/header.css';
</style>

<script>
import Dropdown from '../../components/base/BaseDropdown.vue'

export default {
  name: 'Header',
  components:{Dropdown},
  data(){
      return{
      restaurant:[{
              itemName:'Nhà Hàng Biển Đông',
              itemId:'0',
          },
          {
              itemName:'Nhà Hàng Biển Tây',
              itemId:'1',
          }]
  }}
}
</script>
