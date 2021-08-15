<template>
  <div class="baseDropDown" style="z-index: 1" :id="id">
    <div
      class="dropDown"
      @click="isOpen = !isOpen"
      v-on-clickaway="dropDownHide"
    >
      <div class="divText">{{ currentName }}</div>
      <div :class="['arrow', isOpen ? 'arrowUp' : 'arrowDown']"></div>
    </div>
    <transition name="openDropDown" appear>
      <div class="dropDownItem" v-if="isOpen">
        <div
          v-for="item in itemList"
          :key="item.itemId"
          :value="item.itemId"
          :class="['item', item.itemId == currentId ? 'selected' : '']"
          @click="clickItem(item.itemId, item.itemName)"
        >
          {{ item.itemName }}
        </div>
      </div>
    </transition>
  </div>
</template>

 <script>
import { mixin as clickaway } from 'vue-clickaway';
export default {
  mixins: [ clickaway ],
  name:'DropDown',
  
  props:{
    defaultText:{},
    items:[],
    selectedId:{},
    id : String,
    
  },
  data(){
    return{
      isOpen:false,
      itemList:[],
      currentId:'-1',
      currentName:'',
      defaultId:'-1',

    };
  },
  methods:{
    dropDownHide(){
      this.isOpen=false;
    },
    clickItem(id,name){
      this.currentId=id,
      this.currentName=name,
      this.isOpen=false,
      this.$emit("input",id)
    },   
  },
  created() {
      this.itemList = this.items;
      this.currentName = this.defaultText;
    },
    mounted() {
      this.itemList = this.items;
      this.currentName = this.defaultText;
    },
  watch: {
    selectedId: function(){
      this.currentId = this.selectedId;
      this.itemList.forEach(item => {
        if(this.currentId == item.itemId)
        {
          this.currentName = item.itemName;
        }
      });
    }
    },
    // currentName: function(){
    //   this.itemList = this.items;
    //   this.currentName = this.defaultText;
    // }
  }

</script>

<style>
.dropDown {
  height: 38px;
  border: 1px solid #bbbbbb;
  border-radius: 4px;
  color: #000000;
  background-color: #ffffff;
  padding: 0px;
  width: 220px;
  text-align: left;
  display: flex;
  cursor: pointer;
  /* margin-right:15px ; */
  line-height: 40px;
}
.dropDownItem {
  box-shadow: rgba(255, 255, 255, 0.1) 0px 1px 1px 0px inset,
    rgba(50, 50, 93, 0.25) 0px 50px 100px -20px,
    rgba(0, 0, 0, 0.3) 0px 30px 60px -30px;
  border-radius: 4px;
  margin-top: 4px;
}

.dropDown:focus {
  border: 1px solid #019160;
}
.arow {
  width: 10px;
  background-color: #000000;
}
.divText {
  width: 160px;
  height: 100%;
  text-align: left;
  padding-left: 16px;
  line-height: 40px;
}
.arrow {
  width: 44px;
  height: 100%;
}
.item {
  height: 40px;
  width: 220px;
  background-color: #ffffff;
  line-height: 40px;
  z-index: 99999;
  text-align: center;
  margin: 0px;
  cursor: pointer;
}
.item:hover {
  background-color: #e9ebee;
}
.item:focus {
  background-color: #019160;
  color: #ffffff;
}
.arrowDown {
  background-image: url(../../assets/icon/dropdown-arrow-icon-15.jpg);
  background-size: 50%;
  background-position: center;
  background-repeat: no-repeat;
}
.arrowUp {
  background-image: url(../../assets/icon/dropdown-arrow-icon-up-15.jpg);
  background-size: 50%;
  background-position: center;
  background-repeat: no-repeat;
}
.selected {
  background-color: #019160;
  color: #ffffff;
  background-image: url(../../assets/icon/pngaaa.com-382611.png);
  background-position: 16px center;
  background-repeat: no-repeat;
  background-size: 7%;
}
</style>